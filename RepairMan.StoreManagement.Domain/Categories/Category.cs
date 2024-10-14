using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepairMan.StoreManagement.Domain.Parts;
using RepairMan.StoreManagement.Localization;

namespace RepairMan.StoreManagement.Domain.Categories
{
    public class Category : EntityId<int>
    {
        private Category()
        {
            
        }
        public Category(string title)
        {
            this.Title = title;
        }

        public string Title { get; set; }


        public virtual ICollection<PartCategory> PartCategories { get; set; }
    }
}
