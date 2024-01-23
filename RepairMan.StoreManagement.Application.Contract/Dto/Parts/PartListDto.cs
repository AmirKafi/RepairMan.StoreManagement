namespace RepairMan.StoreManagement.Application.Contract.Dto.Parts;

public class PartListDto:BaseListDto<int>
{
    public string Brand { get; set; }
    public string Model { get; set; }
    public string? Description { get; set; }
    public int QTY { get; set; }

    public string CategoriesTitle { get; set; }
    public List<int> CategoriesId { get; set; }

}