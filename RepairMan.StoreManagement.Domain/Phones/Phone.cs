using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepairMan.StoreManagement.Domain.Parts;
using RepairMan.StoreManagement.Localization;

namespace RepairMan.StoreManagement.Domain.Phones
{
    public class Phone:EntityId<int>
    {
        #region Constructor

        private Phone()
        {
            
        }

        public Phone(string brand,
            string model,
            string? description,
            int qty)
        {
            this.Brand = brand;
            this.Model = model;
            this.Description = description;
            this.Qty = qty;
        }

        #endregion

        #region Properties

        public string Brand { get; set; }
        public string Model { get; set; }
        public string? Description { get; set; }
        public int Qty { get; set; } = 1;

        #endregion

        #region Methods

        public Phone Update(string brand,
                            string model,
                            string? description,
                            int qty)
        {
            this.Brand = brand;
            this.Model = model;
            this.Description = description;
            this.Qty = qty;

            return this;
        }

        public Phone UsePhone()
        {
            this.Qty = this.Qty - 1;

            return this;
        }

        #endregion
    }
}
