using System.ComponentModel.DataAnnotations;

namespace RepairMan.StoreManagement.Application.Contract.Dto.Parts;

public class PartUpdateDto
{
    public int Id { get; set; }

    [Display(Name = "برند")]
    [Required(ErrorMessage = "این فیلد اجباری می باشد")]
    public string Brand { get; set; }

    [Display(Name = "مدل")]
    [Required(ErrorMessage = "این فیلد اجباری می باشد")]
    public string Model { get; set; }

    [Display(Name = "توضیحات")]
    [Required(ErrorMessage = "این فیلد اجباری می باشد")]
    public string? Description { get; set; }

    [Display(Name = " تعداد")]
    public int QTY { get; set; } = 1;

    [Display(Name = "دسته بندی")]
    [Required(ErrorMessage = "این فیلد اجباری می باشد")]
    public List<int> CategoriesId { get; set; }

    public string Categories => string.Join(',', CategoriesId.ToList());
}