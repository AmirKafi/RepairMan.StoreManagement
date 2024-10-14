using System.ComponentModel.DataAnnotations;

namespace RepairMan.StoreManagement.Application.Contract.Dto.Categories;

public class CategoryCreateDto
{
    [Display(Name = "عنوان")]
    [Required(ErrorMessage = "این فیلد اجباری می باشد")]
    public string Title { get; set; }
}