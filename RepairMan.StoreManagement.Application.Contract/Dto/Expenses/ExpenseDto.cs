using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairMan.StoreManagement.Application.Contract.Dto.Expenses
{
    public class ExpenseDto:BaseDto
    {
        public string? Title { get; set; }
        public string? PurchaseDateLocal { get; set; }
    }
}
