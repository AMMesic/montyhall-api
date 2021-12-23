using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MontyHall.Application.Doors.Models;

namespace MontyHall.Test.Application.Doors.Models
{
    [TestClass]
    public class DoorRequestModelTest
    {
        [TestMethod]
        public void RequestModelExceptionTest()
        {
            try
            {
                var sut = new DoorRequestModel(-1);
                Assert.Fail("exception should have been thrown");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                StringAssert.Contains("Request cannot be less than 0 (Parameter 'doorsRequest')", ex.Message);
            }

        }

        [TestMethod]
        public void RequestModelExpectedResultTest()
        {
            var sut = new DoorRequestModel(1);
            Assert.AreEqual(1, sut.DoorsRequest);


        }
    }
}

