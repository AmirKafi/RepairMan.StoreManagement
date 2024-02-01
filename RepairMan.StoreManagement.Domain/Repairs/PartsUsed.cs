using RepairMan.StoreManagement.Domain.Categories;
using RepairMan.StoreManagement.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairMan.StoreManagement.Domain.Repairs
{
    public class PartsUsed:EntityId<int>
    {

        #region Constructor

        private PartsUsed()
        {
            
        }

        public PartsUsed(string title,
                         Int64 cost,
                         int repairId,
                         int categoryId)
        {
            this.Title = title;
            this.Cost = cost;
            this.RepairId = repairId;
            this.CategoryId = categoryId;
        }

        #endregion

        #region Properties

        public string Title { get; set; }
        public Int64 Cost { get; set; }

        public Repair Repair { get; set; }
        public int RepairId { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        #endregion

        #region Methods

        public PartsUsed Update(string title,
                         Int64 cost,
                         int repairId,
                         int categoryId)
        {
            this.Title = title;
            this.Cost = cost;
            this.RepairId = repairId;
            this.CategoryId = categoryId;

            return this;
        }

        #endregion
    }
}
