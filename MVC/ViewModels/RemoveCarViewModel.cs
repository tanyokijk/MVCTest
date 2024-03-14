using System.ComponentModel.DataAnnotations;

namespace MVC.ViewModels;

public class RemoveCarViewModel
{
    [Required(ErrorMessage = "Введіть назву автомобіля")]
    public string CarName { get; set; }
}
