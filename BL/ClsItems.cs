using LapShop.Models;
using Microsoft.IdentityModel.Tokens;

namespace LapShop.BL
{
 

    public interface IClsItems
    {
        public List<TbItem> GetAll();
        public List<VwItem> GetAllItemData(int? CategoryId);

        public List<VwItem> GetRecommendedItems(int itemId);
        public TbItem GetById(int id);
        public VwItem GetItemById(int id);
        public bool Save(TbItem item);
        public bool Delete(int id);

    }
    public class ClsItems:IClsItems
    {
        LapShop2Context context ;
        public ClsItems(LapShop2Context ctx)
        {

           context= ctx ;   

        }
        public List<TbItem> GetAll()
        {
            try
            {
               
                var lstItems = context.TbItems.ToList();
                return lstItems;
            }
            catch
            {
                return new List<TbItem>();

            }

        }

        public List<VwItem> GetAllItemData(int? CategoryId)
        {
            try
            {
                //to not view item delete 
                //لعدم عرض الصور الغير موجودة او قيمتها فاضية !string.IsNullOrEmpty(a.ItemName))

                var lstItems = context.VwItems.Where(a=>(a.CategoryId== CategoryId
                || CategoryId == null|| CategoryId == 0&& a.CurrentState==1&&!string.IsNullOrEmpty(a.ItemName)))
                    .OrderByDescending(a=>a.CreatedDate)
                    .ToList();
                return lstItems;
            }
            catch
            {
                return new List<VwItem>();

            }

        }


        public List<VwItem> GetRecommendedItems(int  itemId)
        {
            try
            {
                var item = GetById(itemId);
                //to not view item delete 
                //لعدم عرض الصور الغير موجودة او قيمتها فاضية !string.IsNullOrEmpty(a.ItemName))

                var lstItems = context.VwItems.Where(a => (a.SalesPrice > item.SalesPrice-150
                && a.SalesPrice < item.SalesPrice + 150 &&
                a.CurrentState == 1 ))
                    .OrderByDescending(a => a.CreatedDate)
                    .ToList();
                return lstItems;
            }
            catch
            {
                return new List<VwItem>();

            }

        }

        public TbItem GetById(int id)
        {
            try
            {
     
                var item= context.TbItems.FirstOrDefault(a => a.ItemId == id && a.CurrentState == 1);
                return item;

            }
            catch
            {
                return new TbItem();

            }
        }

        public VwItem GetItemById(int id)

        {
            try
            {

                var item = context.VwItems.FirstOrDefault
                    (a => a.ItemId == id && a.CurrentState == 1);
                return item;

            }
            catch
            {
                return new VwItem();

            }
        }
        public bool Save(TbItem item)
        {
            try
            {


   


                if (item.ItemId == 0)
                {
                    item.CurrentState = 1;
                    item.CreatedBy = "1";
                    item.CreatedDate = DateTime.Now;

                    context.TbItems.Add(item);

                }
                else
                {
                    item.UpdatedBy = "1";
                    item.UpdatedDate = DateTime.Now;
                    context.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

                }

                context.SaveChanges();
                return true;

            }
            catch
            {
                return false;
            }


        }

        public bool Delete(int id)
        {
            try
            {
             
                var item = GetById(id);
                item.CurrentState = 0;
                context.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.Remove(item);
                context.SaveChanges();

                return true;

            }
            catch
            {
                return false;

            }
        }



    }
}
