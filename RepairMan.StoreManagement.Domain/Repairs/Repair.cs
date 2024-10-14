using RepairMan.StoreManagement.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairMan.StoreManagement.Domain.Repairs
{
    public class Repair:EntityId<int>
    {
        #region Constructor

        private Repair()
        {
                
        }
        public Repair(string brand,
                      string model,
                      string? description,
                      DateTime repairDate,
                      Int64 repairCost,
                      Int64 storeShareCost)
        {
            this.Brand = brand;
            this.Model = model;
            this.Description = description;
            this.RepairDate = repairDate;
            this.RepairCost = repairCost;
            this.StoreShareCost = storeShareCost;
        }

        #endregion

        #region Properties

        public string Brand { get; set; }
        public string Model { get; set; }
        public string? Description { get; set; }
        public DateTime RepairDate { get; set; }
        public Int64 RepairCost { get; set; }
        public Int64 StoreShareCost { get; set; }
        public Int64 TotalCost => RepairCost + StoreShareCost;

        #endregion

        #region Methods

        public Repair Update(string brand,
                                string model,
                                string? description,
                                DateTime repairDate,
                                Int64 repairCost,
                                Int64 storeShareCost)
        {
            this.Brand = brand;
            this.Model = model;
            this.Description = description;
            this.RepairDate = repairDate;
            this.RepairCost = repairCost;
            this.StoreShareCost = storeShareCost;

            return this;
        }

        #endregion
    }
}
