namespace RepairMan.StoreManagement.Application.Contract.Dto.Repairs.PartsUsed
{
    public class PartsUsedListDto : BaseListDto<int>
    {
        public int PartUsedId { get; set; }
        public string Title { get; set; }
        public Int64 Cost { get; set; }
        public string CategoryTitle { get; set; }
    }
}
