using MVC.Models;

namespace MVC.Interfaces;

public interface ICarsCategory
{
    IEnumerable<Category> AllCategories { get; }
}
