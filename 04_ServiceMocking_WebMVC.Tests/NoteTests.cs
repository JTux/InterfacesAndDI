using System;
using _04_ServiceMocking_Services.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _04_ServiceMocking_WebMVC.Tests
{
    [TestClass]
    public class NoteTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            //-- Arrange
            var guid = new Guid();
            var service = new NoteService(guid);

            //-- Act


            //-- Assert

        }
    }
}
