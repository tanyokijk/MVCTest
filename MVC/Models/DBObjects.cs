namespace MVC.Models;

public class DBObjects
{
    public static void Initial(AppDBContext context)
    {



        if (!context.Category.Any())
        {
            context.Category.AddRange(Categories.Select(c => c.Value));
        }
        if (!context.Car.Any())
        {
            context.AddRange(
                new Car
                {
                    Name = "Tesla Model S",
                    Description = "Швидкий автомобіль",
                    Image = "/img/Tesla.jpg",
                    Price = 45000,
                    IsFavourite = true,
                    Available = true,
                    Category = Categories["Електромобілі"]
                },
                new Car
                {
                    Name = "Ford Fiesta",
                    Description = "Тихій та спокійний",
                    Image = "/img/Ford.jpg",
                    Price = 11000,
                    IsFavourite = false,
                    Available = true,
                    Category = Categories["Класичні авто"]
                },
                new Car
                {
                    Name = "BMW M3",
                    Description = "Зухвалий та стильний",
                    Image = "/img/BMW.jpg",
                    Price = 65000,
                    IsFavourite = true,
                    Available = true,
                    Category = Categories["Класичні авто"]
                },
                new Car
                {
                    Name = "Mercedes C class",
                    Description = "Затишний та великий",
                    Image = "/img/Mercedes.jpg",
                    Price = 40000,
                    IsFavourite = false,
                    Available = false,
                    Category = Categories["Класичні авто"]
                },
                new Car
                {
                    Name = "Nissan Leaf",
                    Description = "Тихий та економний",
                    Image = "/img/Nissan.jpg",
                    Price = 14000,
                    IsFavourite = true,
                    Available = true,
                    Category = Categories["Електромобілі"]
                }
            );
        }
        context.SaveChanges();
    }

    private static Dictionary<string, Category> category;

    public static Dictionary<string, Category> Categories
    {
        get
        {
            if (category == null)
            {
                var list = new Category[]
                {
                    new Category{Name = "Електромобілі"},
                    new Category{Name = "Класичні авто"}
                };
                category = new Dictionary<string, Category>();
                foreach (Category el in list)
                    category.Add(el.Name, el);
            }
            return category;
        }
    }
}

