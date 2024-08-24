using Domains;
using LapShop.BL;
using LapShop.Models;
namespace LapShop.BL
{

    public interface IClsContact
    {
        public List<TbContact> GetAll();
        public TbContact GetById(int id);
        public bool Save(TbContact category);

    }

    public class ClsContact : IClsContact
    {
        LapShop2Context context;
        public ClsContact(LapShop2Context ctx)
        {

            context = ctx;

        }
        public List<TbContact> GetAll()
        {
            try
            {

                var lstCategories = context.TbContacts.Where(a => a.CurrentState == 1).ToList();
                return lstCategories;
            }
            catch
            {
                return new List<TbContact>();

            }

        }

        public TbContact GetById(int id)
        {
            try
            {

                var category = context.TbContacts.FirstOrDefault(a => a.ContactId == id && a.CurrentState == 1);
                return category;

            }
            catch
            {
                return new TbContact();

            }
        }

        public bool Save(TbContact category)
        {
            try
            {

                if (category.ContactId == 0)
                {

                    category.CreatedDate = DateTime.Now;

                    context.TbContacts.Add(category);

                }
                else


                { 
                    context.Entry(category).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

                }

                context.SaveChanges();
                return true;

            }
            catch
            {
                return false;
            }


        }

        //public bool Delete(int id)
        //{
        //    try
        //    {
        //        LapShop2Context context = new LapShop2Context();
        //        var category = GetById(id);
        //        //context.TbCategories.Remove(category);

        //        category.CurrentState = 0;
        //        context.SaveChanges();

        //        return true;

        //    }
        //    catch
        //    {
        //        return false;

        //    }
        //}

    }
}



