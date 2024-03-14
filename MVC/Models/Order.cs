using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace MVC.Models;

public class Order
{
    [BindNever]
    public int Id { get; set; }
    [Display(Name = "Ім’я")]
    [StringLength(25)]
    [Required(ErrorMessage = "Довжина імені не менше 5 символів")]
    public string Name { get; set; }

    [Display(Name = "Прізвище")]
    [StringLength(25)]
    [Required(ErrorMessage = "Довжина імені не менше 5 символів")]
    public string Surname { get; set; }

    [Display(Name = "Адреса")]
    [StringLength(35)]
    [Required(ErrorMessage = "Довжина імені не менше 5 символів")]
    public string Adress { get; set; }

    [Display(Name = "Телефон")]
    [StringLength(20)]
    [DataType(DataType.PhoneNumber)]
    [Required(ErrorMessage = "Довжина імені не менше 10 символів")]
    public string Phone { get; set; }

    [Display(Name = "E-mail")]
    [DataType(DataType.EmailAddress)]
    [StringLength(30)]
    [Required(ErrorMessage = "Довжина імені не менше 15 символів")]
    public string Email { get; set; }

    [BindNever]
    [ScaffoldColumn(false)]
    public DateTime OrderTime { get; set; }
    [BindNever]
    [ScaffoldColumn(false)]
    public List<OrderDetail> OrderDetails { get; set; }
}
