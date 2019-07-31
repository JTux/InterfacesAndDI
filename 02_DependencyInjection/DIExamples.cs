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
        public string Name
        {
            get { return "Penny"; }
        }
        public decimal Value
        {
            get { return 0.01m; }
        }
    }
    public class Dime : ICurrency
    {
        public string Name
        {
            get { return "Dime"; }
        }
        public decimal Value
        {
            get { return 0.10m; }
        }
    }
    public class Dollar : ICurrency
    {
        public string Name
        {
            get { return "Dollar"; }
        }
        public decimal Value
        {
            get { return 1.00m; }
        }
    }
    //This ElectronicPayment class implements the interface but does not have a fixed value
    public class ElectronicPayment : ICurrency
    {
        public string Name
        {
            get { return "Electronic Payment"; }
        }

        public decimal Value { get; }

        public ElectronicPayment(decimal value)
        {
            Value = value;
        }
    }

    //In this class we are utilizing an interface inside of the Constructor
    //This allows us to create a Transaction class regardless of the type of currency
    //Note this is simply a way to see it being used I know it might seem redundant at this time
    public class Transaction
    {
        //We declare our field of type ICurrency
        //This will be assigned a value when the class is constructed
        private ICurrency _amount;

        //We created a constructor that requires an ICurrency to be injected upon creation
        public Transaction(ICurrency amount)
        {
            _amount = amount;
            DateOfTransaction = DateTimeOffset.Now;
        }

        public DateTimeOffset DateOfTransaction { get; set; }

        //These methods allow us to access the values without dealing with the ICurrency object
        public decimal GetTransactionAmount()
        {
            return _amount.Value;
        }
        public string GetTypeOfTransaction()
        {
            return _amount.Name;
        }
    }

    [TestClass]
    public class DIExamples
    {
        [TestMethod]
        public void DIMethodExample()
        {
            _debt = 9000.01m;

            //Here we can inject any object that implements ICurrency
            PayDebt(new Dollar());
            PayDebt(new ElectronicPayment(315.52m));

            Console.WriteLine($"Remaining debt is ${_debt}.");
        }

        private decimal _debt;

        //Here we have a method that allows a payment to be made
        //The method is built to take any type of ICurrency and pay it towards the debt
        //This way the method is not dependent on any specific type of currency
        private void PayDebt(ICurrency payment)
        {
            _debt -= payment.Value;
            Console.WriteLine($"You have paid ${payment.Value} towards your debt.");
        }

        [TestMethod]
        public void InjectingIntoConstructors()
        {
            //We declare our objects that implement ICurrency
            var dollar = new Dollar();
            var ePayment = new ElectronicPayment(243.71m);

            //We pass them through into the new Transaction class
            var firstTransaction = new Transaction(dollar);
            var secondTransaction = new Transaction(ePayment);

            //We can now call the methods in the class we passed them into
            //Now regardless of what was passed into the Transaction we can call the same methods
            Console.WriteLine(firstTransaction.GetTypeOfTransaction());
            Console.WriteLine(secondTransaction.GetTransactionAmount());
        }

        //Here's another quick example that shows a list of Transactions being made
        //We can call the same method regardless of what has been passed into the constructor
        [TestMethod]
        public void MoreExamples()
        {
            var list = new List<Transaction>
            {
                new Transaction(new Dollar()),
                new Transaction(new ElectronicPayment(231.95m)),
                new Transaction(new Dime()),
                new Transaction(new Dollar()),
                new Transaction(new Penny())
            };

            foreach (var t in list)
            {
                var type = t.GetTypeOfTransaction();
                var amount = t.GetTransactionAmount();

                Console.WriteLine($"{type} ${amount} {t.DateOfTransaction}");
            }
        }
    }
}
