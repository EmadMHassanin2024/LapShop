namespace LapShop.Models
{
    public class VmHomePages
    {
        public VmHomePages()
        {
            lstAllItems = new List<VwItem>();
            lstRecommendedItems = new List<VwItem>();
            lstNewItems = new List<VwItem>();
            lstFreeDelivry = new List<VwItem>();
            lstCategories = new List<TbCategory>();
            lstSlider=new List<TbSlider>();     


        }

        public List<VwItem> lstAllItems { get; set; }
        public List<VwItem> lstRecommendedItems { get; set; }
        public List<VwItem> lstNewItems { get; set; }
        public List<VwItem> lstFreeDelivry { get; set; }
        public List<TbCategory> lstCategories { get; set; }
        public List<TbSlider> lstSlider { get; set; }
    }
}
