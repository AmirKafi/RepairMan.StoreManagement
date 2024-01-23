using System.ComponentModel.DataAnnotations;

namespace RepairMan.StoreManagement.Application.Contract.Dto.Categories;

public class CategoryUpdateDto
{

    public int Id { get; set; }

    [Display(Name = "عنوان")]
    [Required(ErrorMessage = "این فیلد اجباری می باشد")]
    public string Title { get; set; }

}