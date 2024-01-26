using RepairMan.StoreManagement.Localization.Utility.Extentions.Datetime;

namespace RepairMan.StoreManagement.Application.Contract.Dto.Repairs
{
    public class RepairListDto : BaseListDto<int>
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public string? Description { get; set; }

        public DateTime RepairDate { get; set; }
        public string RepairDateFa => RepairDate.ToFa();

        public Int64 RepairCost { get; set; }
        public Int64 StoreShareCost { get; set; }
        public Int64 TotalCost => RepairCost + StoreShareCost;
    }
}
