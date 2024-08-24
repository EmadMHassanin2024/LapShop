using LapShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace  LapShop.BL
{
    public interface IItemImages
    {
        public List<TbItemImage> GetByItemId(int id);
    }
    public class ClsItemImages: IItemImages
    {
        LapShop2Context context;
        public ClsItemImages(LapShop2Context ctx)
        {
            context = ctx;
        }

        public List<TbItemImage> GetByItemId(int id)
        {
            try
            {
                var item = context.TbItemImages.Where(a => a.ItemId == id).ToList();
                return item;
            }
            catch
            {
                return new List<TbItemImage>();
            }
        }
    }
}
