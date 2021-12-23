using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MontyHall.Application.DoorCalculation;

namespace MontyHall.Test.Application.DoorCalculation
{
    [TestClass]
    public class CalculateDoorsTest
    {
        private readonly ICalculateDoors _calculateDoors;
        private readonly CalculateDoors _calculateDoorsInstance = new CalculateDoors();
        public CalculateDoorsTest()
        {
            _calculateDoors = _calculateDoorsInstance;
        }

        

        [TestMethod]
        public void GetDoorsTest()
        {
            var sut = _calculateDoors.GetDoors(3);
            var sut2 = _calculateDoors.GetDoors(10);
            var sut3 = _calculateDoors.GetDoors(1000);

            Assert.IsNotNull(sut);
            Assert.AreEqual(3, sut.Count());
            Assert.AreEqual(10, sut2.Count());
            Assert.AreEqual(1000, sut3.Count());
            Assert.AreNotEqual(1000, sut2.Count());
        }

        [TestMethod]
        public void GetDoorsZeroResultTest()
        {
            var sut = _calculateDoors.GetDoors(-1);
            Assert.AreEqual(0, sut.Count());
        }

        [TestMethod]
        public void GetDoorsReturnOneCarTest()
        {
            var sut = _calculateDoors.GetDoors(10);
            var sut2 = _calculateDoors.GetDoors(100);
            var sut3 = _calculateDoors.GetDoors(1000);

            var car = sut.Where(x => x.Car == true);
            var count = car.Count();
            Assert.AreEqual(1, count);

            car = sut2.Where(x => x.Car == true);
            count = car.Count();
            Assert.AreEqual(1, count);

            car = sut3.Where(x => x.Car == true);
            count = car.Count();
            Assert.AreEqual(1, count);
        }

        [TestMethod]
        public void GetDoorsReturnGoatsTest()
        {
            var sut = _calculateDoors.GetDoors(10);
            var sut2 = _calculateDoors.GetDoors(100);
            var sut3 = _calculateDoors.GetDoors(1000);
            var sut4 = _calculateDoors.GetDoors(10000);

            var goats = sut.Where(x => x.Goat == true);
            var count = goats.Count();
            Assert.AreEqual(9, count);

            goats = sut2.Where(x => x.Goat == true);
            count = goats.Count();
            Assert.AreEqual(99, count);

            goats = sut3.Where(x => x.Goat == true);
            count = goats.Count();
            Assert.AreEqual(999, count);

            goats = sut4.Where(x => x.Goat == true);
            count = goats.Count();
            Assert.AreEqual(9999, count);
        }

        [TestMethod]
        public void GetDoorsRevealdHostGoatsTest()
        {
            var sut = _calculateDoors.GetDoors(10);
            var sut2 = _calculateDoors.GetDoors(100);
            var sut3 = _calculateDoors.GetDoors(1000);
            var sut4 = _calculateDoors.GetDoors(10000);

            var goats = sut.Where(x => x.Goat == true && x.RevealGoat == true);
            var count = goats.Count();
            Assert.AreEqual(8, count);
            Assert.AreNotEqual(9, count);

            goats = sut2.Where(x => x.Goat == true && x.RevealGoat == true);
            count = goats.Count();
            Assert.AreEqual(98, count);
            Assert.AreNotEqual(99, count);

            goats = sut3.Where(x => x.Goat == true && x.RevealGoat == true);
            count = goats.Count();
            Assert.AreEqual(998, count);
            Assert.AreNotEqual(999, count);

            goats = sut4.Where(x => x.Goat == true && x.RevealGoat == true);
            count = goats.Count();
            Assert.AreEqual(9998, count);
            Assert.AreNotEqual(9999, count);
        }

        [TestMethod]
        public void GetSimulationTest()
        {
            var sut = _calculateDoors.SimulateMontyHallGame(10, true);

            Assert.IsNotNull(sut);
            Assert.AreEqual(true, sut.IsSwtichedDoor);
        }

        [TestMethod]
        public void GetSimulationProbabilityIfSwitchedDoorTest()
        {
            var sut = _calculateDoors.SimulateMontyHallGame(100, true);
            var sut2 = _calculateDoors.SimulateMontyHallGame(1000, true);
            var sut3 = _calculateDoors.SimulateMontyHallGame(10000, true);

            var counts = sut.Wins;
            Assert.IsNotNull(sut);
            Assert.AreEqual(true, sut.IsSwtichedDoor);

            Assert.IsTrue(counts > 60);
            Assert.IsFalse(counts < 50);

            counts = sut2.Wins;
            Assert.IsTrue(counts > 600);
            Assert.IsFalse(counts < 500);

            counts = sut3.Wins;
            Assert.IsTrue(counts > 6000);
            Assert.IsFalse(counts < 5000);
        }

        [TestMethod]
        public void GetSimulationProbabilityIfNotSwitchedDoorTest()
        {
            var sut = _calculateDoors.SimulateMontyHallGame(100, false);
            var sut2 = _calculateDoors.SimulateMontyHallGame(1000, false);
            var sut3 = _calculateDoors.SimulateMontyHallGame(10000, false);

            var counts = sut.Wins;
            Assert.IsNotNull(sut);
            Assert.AreEqual(false, sut.IsSwtichedDoor);

            Assert.IsTrue(counts > 25);
            Assert.IsTrue(counts < 50);
            Assert.IsFalse(counts > 50);

            counts = sut2.Wins;
            Assert.IsTrue(counts > 250);
            Assert.IsTrue(counts < 500);
            Assert.IsFalse(counts > 500);

            counts = sut3.Wins;
            Assert.IsTrue(counts > 2500);
            Assert.IsTrue(counts < 5000);
            Assert.IsFalse(counts > 5000);
        }
    }
}

