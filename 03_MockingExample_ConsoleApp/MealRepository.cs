using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_MockingExample_ConsoleApp
{
    public class MealRepository
    {
        private List<Meal> _menuList;
        public int itemCount = 0;

        public MealRepository()
        {
            _menuList = new List<Meal>();
            SeedMenu();
        }

        public void AddItem(Meal newItem)
        {
            itemCount++;
            newItem.MealNumber = itemCount;
            _menuList.Add(newItem);
        }

        public void RemoveItem(Meal item)
        {
            _menuList.Remove(item);
            itemCount--;
        }

        public List<Meal> GetList() => _menuList;

        private void SeedMenu()
        {
            AddItem(new Meal { MealName = "Cheese Burger", Description = "Burger with Cheese", Ingredients = "Bun, Patty, and Cheese", Price = 5m });
            AddItem(new Meal { MealName = "Hamburger", Description = "Burger", Ingredients = "Bun with \"Beef\" Patty", Price = 4m });
            AddItem(new Meal { MealName = "Fries", Description = "Fried Potato Strips", Ingredients = "Potatoes, Salt, and Happiness", Price = 2.99m });
        }
    }
}
