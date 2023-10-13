using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Category
{
    public Guid Id { get; set; }

    [DisplayName("Название категории продукта")]
    [Required(ErrorMessage = "{0} является обязательным полем")]
    [StringLength(200)]
    public required string Name { get; set; }
}
