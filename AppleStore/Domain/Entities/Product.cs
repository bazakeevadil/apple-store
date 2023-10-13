using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Product
{
    public Guid ProductId { get; set; }

    [DisplayName("Название продукта")]
    [Required(ErrorMessage = "{0} является обязательным полем")]
    [StringLength(200)]
    public required string Name { get; set; }
    public Guid CategoryId { get; set; }

    public Category? Category { get; set; }
}
