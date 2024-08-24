﻿namespace LapShop.Models
{
    public class vwItemCategories
    {

        public int ItemId { get; set; }

        public string ItemName { get; set; } = null!;
        public string CategoryName { get; set; } = null!;

        public decimal SalesPrice { get; set; }

        public decimal PurchasePrice { get; set; }

        public int CategoryId { get; set; }

        public string? ImageName { get; set; }



        public string? Description { get; set; }

        public string? Gpu { get; set; }

        public string? HardDisk { get; set; }

        public int ItemTypeId { get; set; }

        public string? Processor { get; set; }

        public int RamSize { get; set; }

        public string? ScreenReslution { get; set; }

        public string? ScreenSize { get; set; }

        public string? Weight { get; set; }

        public int OsId { get; set; }

        public virtual TbCategory Category { get; set; } = null!;

        public virtual TbItemType ItemType { get; set; } = null!;

        public virtual TbO Os { get; set; } = null!;


    }
}
