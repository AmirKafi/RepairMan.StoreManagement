using RepairMan.StoreManagement.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairMan.StoreManagement.Domain.Expenses
{
    public class Expense:EntityId<int>
    {
        #region Constructor

        private Expense()
        {
            
        }

        public Expense(string title,
                       string? description,
                       Int64 cost,
                       DateTime purchaseDate)
        {
            this.Title = title;
            this.Description = description;
            this.Cost = cost;
            this.PurchaseDate = purchaseDate;
        }

        #endregion

        #region Properties

        public string Title { get; set; }
        public string? Description { get; set; }
        public Int64 Cost { get; set; }
        public DateTime PurchaseDate { get; set; }

        #endregion

        #region Methods

        public Expense Update(string title,
                                 string? description,
                                 Int64 cost,
                                 DateTime purchaseDate)
        {
            this.Title = title;
            this.Description = description;
            this.Cost = cost;
            this.PurchaseDate = purchaseDate;

            return this;
        }

        #endregion
    }
}
