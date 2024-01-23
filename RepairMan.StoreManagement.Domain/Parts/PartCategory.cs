using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepairMan.StoreManagement.Domain.Categories;
using RepairMan.StoreManagement.Localization;

namespace RepairMan.StoreManagement.Domain.Parts
{
    public class PartCategory:EntityId<int>
    {
        public PartCategory(int partId, 
                            int categoryId)
        {
            this.PartId = partId;
            this.CategoryId = categoryId;
        }

        public int PartId { get; set; }
        public virtual Part Part { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
