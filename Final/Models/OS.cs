using System;

namespace Final.Models
{
    public class OS
    {

        public int OSId { get; set; }

        public string OSName { get; set; }

        public int DictCategoryId { get; set; }

        public string InventoryNumber { get; set; }

        public decimal OSCount { get; set; }

        public DateTime UsedFrom { get; set; }

        public decimal Cost { get; set; }

        public DateTime Purchased { get; set; }

        public DateTime Charged { get; set; }

        public int DictBudgetId { get; set; }

        public int DictTypeId { get; set; }

        public string OSSerial { get; set; }

        public int DictBillId { get; set; }

        public int DictOsUsageId { get; set; }

        public int Visible { get; set; }

        public DateTime LastUpdate { get; set; }


    }
}
