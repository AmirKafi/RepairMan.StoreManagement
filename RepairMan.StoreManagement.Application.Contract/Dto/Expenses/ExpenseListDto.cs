using RepairMan.StoreManagement.Localization.Utility.Extentions.Datetime;

namespace RepairMan.StoreManagement.Application.Contract.Dto.Expenses
{
    public class ExpenseListDto:BaseListDto<int>
    {

        public string Title { get; set; }
        public string? Description { get; set; }
        public Int64 Cost { get; set; }
        public DateTime PurchaseDate { get; set; }
        public string PurchaseDateFa => PurchaseDate.ToFa();
    }
}
