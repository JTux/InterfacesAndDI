using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _02_DependencyInjection
{
    //Dependency Injection allows us to build out what can be referred to as loosely coupled code.
    //By providing interfaces as parameters (dependencies) we are allowing for more options with one
    //method instead of being restricted to a specific type or object.

    //Here we have built out an interface called ICurrency that we'll use as the "template"
    //We're able to have multiple different classes implement ICurrency that can be used later
    public interface ICurrency
    {
        string Name { get; }
        decimal Value { get; }
    }

    public class Penny : ICurrency
    {
        public string Name => "Penny";
        public decimal Value => 0.01m;
    }
    public class Dime : ICurrency
    {
        public string Name => "Dime";
        public decimal Value => 0.10m;
    }
    public class Dollar : ICurrency
    {
        public string Name => "Dollar";
        public decimal Value => 1.00m;
    }
    //This ElectronicPayment class implements the interface but does not have a fixed value
    public class ElectronicPayment : ICurrency
    {
        private decimal _value;

        public ElectronicPayment(decimal value)
        {
            _value = value;
        }

        public string Name => "Electronic Payment";
        public decimal Value => _value;
    }

    [TestClass]
    public class DIExamples
    {
        [TestMethod]
        public void DIMethodExample()
        {
            decimal debt = 9000.01m;

            //Here we have a method that allows a payment to be made
            //The method is built to take any type of ICurrency and pay it towards the debt
            //This way the method is not dependent on any specific type of currency
            void Pay(ICurrency payment)
            {
                debt -= payment.Value;
                Console.WriteLine($"You have paid ${payment.Value} towards your debt.");
            }

            //Here we can inject any object that implements ICurrency
            Pay(new Dollar());
            Pay(new ElectronicPayment(315.52m));

            Console.WriteLine($"Remaining debt is ${debt}.");
        }
    }
}
