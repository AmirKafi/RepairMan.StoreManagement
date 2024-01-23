using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepairMan.StoreManagement.Domain.Categories;
using RepairMan.StoreManagement.Localization;

namespace RepairMan.StoreManagement.Domain.Parts
{
    public class Part:EntityId<int>
    {
        #region Constructor

        private Part()
        {
            
        }
        public Part(string brand,
                    string model,
                    string? description,
                    int qty,
                    List<int> partCategories)
        {
            Brand = brand;
            Model = model;
            Description = description;
            QTY = qty;
            _partCategories = partCategories.Select(x=> new PartCategory(Id,x)).ToList();
        }

        #endregion

        #region Properties

        public string Brand { get; set; }

        public string Model { get; set; }

        public string? Description { get; private set; }

        public int QTY { get; private set; } = 1;


        public List<PartCategory> _partCategories { get; private set; } = new List<PartCategory>();
        public ICollection<PartCategory> PartCategories => _partCategories;

        #endregion

        #region Methods

        public Part Update(string brand,
                           string model,
                           string? description,
                           int qty,
                           List<int> partCategories)
        {
            Brand = brand;
            Model = model;
            Description = description;
            QTY = qty;

            _partCategories.Clear();
            _partCategories = partCategories.Select(x => new PartCategory(Id, x)).ToList();

            return this;
        }

        public Part UsePart()
        {
            this.QTY = this.QTY - 1;

            return this;
        }

        #endregion
    }
}
