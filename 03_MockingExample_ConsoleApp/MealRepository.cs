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

        public MealRepository() => _menuList = new List<Meal>();

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
    }
}
