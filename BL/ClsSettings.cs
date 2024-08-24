using LapShop.Models;
using System.Runtime;

namespace LapShop.Bl
{
    public interface ISettings
    {
        public TbSetting GetAll();
        public bool Save(TbSetting setting);
    }

    public class ClsSettings : ISettings
    {
        LapShop2Context context;
        public ClsSettings(LapShop2Context ctx)
        {
            context = ctx;
        }
        public TbSetting GetAll()
        {
            try
            {
                var lstCategories = context.TbSettings.FirstOrDefault();
                return lstCategories;
            }
            catch
            {
                return new TbSetting();
            }
        }

        public bool Save(TbSetting setting)
        {
            try
            {
                context.Entry(setting).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
