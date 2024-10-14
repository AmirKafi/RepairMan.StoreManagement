using RepairMan.StoreManagement.Localization.Utility.Extentions.Datetime;

namespace RepairMan.StoreManagement.Application.Contract.Dto;

public class BaseListDto<T>
{
    public T Id { get; set; }
    public DateTime CreatedOn { get; set; }
    public string CreatedOnFa => CreatedOn.ToFa();
}