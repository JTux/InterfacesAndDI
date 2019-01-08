using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _01_Introduction
{
    //Here we declared our Interface called IFruit
    //Interfaces are prefixed with the letter I
    public interface IFruit
    {
        //We can give interfaces properties and methods
        //Note: they do not take access modifiers (public, private, etc.)
        string Name { get; }        //Property with only get
        bool Peeled { get; set; }   //Property with get and set
        string Peel();              //Method with return type
    }

    //Classes must implement all of the interface components
    //Here we implement our IFruit interface on a class
    public class Banana : IFruit
    {
        public string Name { get => "Banana"; }
        public bool Peeled { get; set; }
        public string Peel()
        {
            Peeled = true;
            return "You peel the banana.";
        }
    }

    public class Orange : IFruit
    {
        public string Name { get => "Orange"; }
        public bool Peeled { get; set; }
        public string Peel()
        {
            Peeled = true;
            return "You peel the orange.";
        }

        //Classes that implement the interface can still have their own unique methods and properties
        public string Squeeze() => "You squeeze the orange and juice comes out.";
    }

    public class Grape : IFruit
    {
        public string Name { get => "Grape"; }
        public bool Peeled { get; set; }
        public string Peel() => "Who peels grapes?";
    }

    [TestClass]
    public class IntroducingInterfaces
    {
        [TestMethod]
        public void CallingInterfaceMethods()
        {
            //Here we're creating a new instance of IFruit of type Banana
            IFruit banana = new Banana();

            //If you hover over banana you can see it's being seen as type IFruit, not Banana
            var output = banana.Peel();
            Console.WriteLine(output);

            Console.WriteLine("The banana is peeled: " + banana.Peeled);
        }

        [TestMethod]
        public void InterfacesInCollections()
        {
            var orange = new Orange();

            //Collections can take in Interfaces as their type that they hold
            //This allows you to collect anything that implements that specific interface
            //Here we are adding a Banana object, Grape object, and Orange object to a single list of IFruit
            var fruitList = new List<IFruit>
            {
                new Banana(),
                new Grape(),
                orange
            };

            //We're only able to call the methods and properties that are part of IFruit
            //Notice we're not able to call fruit.Squeeze() even though there's an Orange object in the list
            foreach (var fruit in fruitList)
            {
                Console.WriteLine(fruit.Name);
                Console.WriteLine(fruit.Peel());

                //If you uncomment this method call you will see an error thrown
                //This is because the IFruit interface does not have a Squeeze method
                //This happens even though there is an Orange in the list that has a Squeeze method
                //fruit.Squeeze();
            }

            Console.WriteLine(orange.Squeeze());
        }

        [TestMethod]
        public void InterfacesInMethods()
        {
            //You can set parameters in methods the same way that you can use Interfaces in a list
            //Here we have a method that takes in anything that implements IFruit
            //It then returns a string that includes the name of the IFruit object
            string GetFruitName(IFruit fruit)
            {
                return $"This fruit is called {fruit.Name}.";
            }

            var grape = new Grape();

            var output = GetFruitName(grape);

            Console.WriteLine(output);
        }

        //Not directly related to interfaces but something you can do is utilize object types
        //Here we have a list of IFruit objects and we want to iterate over them
        //As we iterate over them we want to perform a different action for each type
        [TestMethod]
        public void TypeOfInstance()
        {
            var list = new List<IFruit>
            {
                new Orange{ Peeled=true },
                new Orange(),
                new Grape(),
                new Orange(),
                new Banana(),
                new Grape()
            };

            Console.WriteLine("Is the orange peeled?");
            foreach (var fruit in list)
            {
                //Here we use the keyword is to check if the fruit is a certain type
                if (fruit is Orange)
                    Console.WriteLine("Is a peeled Orange");
                //Here we use typeof to check the current fruit's type
                else if (fruit.GetType() == typeof(Grape))
                    Console.WriteLine("Is a Grape");
                else
                    Console.WriteLine("Is a Banana");
            }
        }
    }
}
