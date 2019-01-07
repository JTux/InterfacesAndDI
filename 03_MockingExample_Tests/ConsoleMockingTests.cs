using System;
using System.Collections.Generic;
using _03_MockingExample_ConsoleApp;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _03_MockingExample_Tests
{
    [TestClass]
    public class ConsoleMockingTests
    {
        [TestMethod]
        public void MealRepository_GetList_ShouldSeeList()
        {
            //-- Arrange
            var commandList = new List<string> { "2", "4" };
            MockConsole console = new MockConsole(commandList);
            var program = new ProgramUI(console);

            //-- Act
            program.Run();
            Console.WriteLine(console.Output);

            //-- Assert
            Assert.IsTrue(console.Output.Contains("Potatoes, Salt, and Happiness"));
        }

        [TestMethod]
        public void MealRepository_AddToList_ShouldSeeItemInList()
        {
            //-- Arrange
            var commandList = new List<string> { "1", "name", "description", "ingredients for test", "35.23", "2", "4" };
            MockConsole console = new MockConsole(commandList);
            var program = new ProgramUI(console);

            //-- Act
            program.Run();
            Console.WriteLine(console.Output);

            //-- Assert
            Assert.IsTrue(console.Output.Contains("ingredients for test"));
        }
    }
}
