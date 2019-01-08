using System;
using System.Collections.Generic;

namespace _03_MockingExample_ConsoleApp
{
    public class ProgramUI
    {
        readonly IConsole _console;
        readonly MealRepository _menuRepo;

        public ProgramUI(IConsole console)
        {
            _console = console;
            _menuRepo = new MealRepository();
        }

        public void Run()
        {
            while (Menu());
        }
        public bool Menu()
        {
            PrintMenu();
            int choice = ParseIntput(null);

            switch (choice)
            {
                case 1:
                    AddItem();
                    return true;
                case 2:
                    ShowList();
                    return true;
                case 3:
                    RemoveItem();
                    return true;
                case 4:
                    return false;
                default:
                    return true;
            }
        }
        private void PrintMenu()
        {
            _console.Clear();
            _console.Write($"What action would you like to do?\n" +
                $"1. Add Item to Menu\n" +
                $"2. View List\n" +
                $"3. Remove Item\n" +
                $"4. Exit\n" +
                $"   ");
        }

        private void AddItem()
        {
            var newMeal = new Meal();

            _console.Clear();
            _console.Write("Enter the name of the item: ");
            newMeal.MealName = _console.ReadLine();

            _console.Write($"Enter the description for the {newMeal.MealName}: ");
            newMeal.Description = _console.ReadLine();

            _console.Write($"Enter the list of ingredients for the {newMeal.MealName}: ");
            newMeal.Ingredients = _console.ReadLine();

            _console.Write($"Enter the price for the {newMeal.MealName}: ");
            while (true)
            {
                if (decimal.TryParse(_console.ReadLine(), out decimal newPrice))
                {
                    newMeal.Price = newPrice;
                    break;
                }
                else
                    _console.Write("Invalid input, please enter a number: ");
            }

            _menuRepo.AddItem(newMeal);
        }

        private void ShowList()
        {
            var menu = _menuRepo.GetList();

            _console.Clear();
            foreach (var item in menu)
            {
                _console.WriteLine($"{item.MealNumber}. {item.MealName}\n" +
                    $"   Description: {item.Description}\n" +
                    $"   Ingredients: {item.Ingredients}\n" +
                    $"   Price: ${item.Price}\n");
            }
            if (menu.Count == 0)
                _console.WriteLine("The Menu is currently empty.");
            _console.ReadKey();
        }

        private void RemoveItem()
        {
            var menu = _menuRepo.GetList();

            _console.Clear();
            if (menu.Count != 0)
            {
                var num = ParseIntput("Enter the menu item number you want to remove: ");
                foreach (var item in menu)
                {
                    if (num == item.MealNumber)
                    {
                        _console.Write($"Are you sure you would like to delete {item.MealName} from the menu?\n" +
                            $"(Y/N): ");
                        var delResponse = _console.ReadLine().ToLower();
                        if (delResponse == "y")
                        {
                            num--;
                            _menuRepo.RemoveItem(menu[num]);

                            foreach (var oldItem in menu)
                            {
                                int spot = menu.IndexOf(oldItem);
                                oldItem.MealNumber = ++spot;
                            }
                        }
                        else if (delResponse != "n")
                        {
                            _console.WriteLine("Invalid input. Item not deleted.");
                            _console.ReadKey();
                        }
                        break;
                    }
                }
            }
            else
            {
                _console.WriteLine("The Menu is currently empty.");
                _console.ReadKey();
            }
        }

        private int ParseIntput(string textInput)
        {
            _console.WriteLine(textInput);
            while (true)
            {
                if (int.TryParse(_console.ReadLine(), out int choice))
                    return choice;
                else
                    _console.Write("Invalid input, please enter a number: ");
            }
        }
    }
}