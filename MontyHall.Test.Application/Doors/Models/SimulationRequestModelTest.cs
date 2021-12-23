using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MontyHall.Application.Doors.Models;

namespace MontyHall.Test.Application.Doors.Models
{
	[TestClass]
	public class SimulationRequestModelTest
	{
        [TestMethod]
        public void RequestModelExceptionTest()
        {
            try
            {
                var sut = new SimulationRequestModel(-1, true);
                Assert.Fail("exception should have been thrown");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                StringAssert.Contains("Request cannot be less then 0 (Parameter 'simulations')", ex.Message);
            }

        }

        [TestMethod]
        public void RequestModelExpectedResultTest()
        {
            var sut = new SimulationRequestModel(100, true);
            var sut2 = new SimulationRequestModel(100, false);

            Assert.AreEqual(true, sut.IsSwitchedDoor);
            Assert.AreEqual(false, sut2.IsSwitchedDoor);
            Assert.AreNotEqual(true, sut2.IsSwitchedDoor);
        }
    }
}

