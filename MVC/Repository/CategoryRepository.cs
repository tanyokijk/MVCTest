using MVC.Interfaces;
using MVC.Models;

namespace MVC.Repository;

public class CategoryRepository : ICarsCategory
{

    private readonly AppDBContext appDBContext;

    public CategoryRepository(AppDBContext appDBContext)
    {
        this.appDBContext = appDBContext;
    }
    public IEnumerable<Category> AllCategories => appDBContext.Category;
}
