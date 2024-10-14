using System.ComponentModel.DataAnnotations;
using RepairMan.StoreManagement.Domain.Categories;

namespace RepairMan.StoreManagement.Application.Contract.Dto.Parts;

public class PartCreateDto
{
    [Display(Name = "برند")]
    [Required(ErrorMessage = "این فیلد اجباری می باشد")]
    public string Brand { get; set; }

    [Display(Name = "مدل")]
    [Required(ErrorMessage = "این فیلد اجباری می باشد")]
    public string Model { get; set; }

    [Display(Name = "توضیحات")]
    public string? Description { get; set; }

    [Display(Name = " تعداد")]
    public int QTY { get; set; } = 1;

    [Display(Name = "دسته بندی")]
    [Required(ErrorMessage = "این فیلد اجباری می باشد")]
    public List<int> CategoriesId { get; set; }

}