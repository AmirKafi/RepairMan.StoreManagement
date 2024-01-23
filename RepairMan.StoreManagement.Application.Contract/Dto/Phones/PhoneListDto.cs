namespace RepairMan.StoreManagement.Application.Contract.Dto.Phones;

public class PhoneListDto:BaseListDto<int>
{
    public string Brand { get; set; }
    public string Model { get; set; }
    public string? Description { get; set; }
    public int Qty { get; set; }
}