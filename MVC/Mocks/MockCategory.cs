using MVC.Interfaces;
using MVC.Models;

namespace MVC.Mocks;

public class MockCategory : ICarsCategory
{
    public IEnumerable<Category> AllCategories
    {
        get
        {
            return new List<Category>
            {
                new Category{Name = "Електромобілі"},
                new Category{Name = "Класичні авто"}
            };
        }
    }
}
