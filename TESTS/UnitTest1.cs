using System;
using System.Runtime.Remoting.Messaging;
using lab9;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace lab9test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ConstructorEmptyValues()
        {
            Car car = new Car();
            Assert.AreEqual(car.FuelFlow, 0);
            Assert.AreEqual(car.FuelVolume, 0);
        }

        [TestMethod]
        public void ConstructorSetValues()
        {
            double flow = 10.6;
            double volume = 5.3;
            Car car = new Car(flow, volume);
            Assert.AreEqual(flow, car.FuelFlow);
            Assert.AreEqual(volume, car.FuelVolume);
        }

        [TestMethod]
        public void Copy()
        {
            Car car = new Car(5.5, 4.4);
            Car copy = new Car(car);
            Assert.AreEqual(copy.FuelFlow, car.FuelFlow);
            Assert.AreEqual(copy.FuelVolume, car.FuelVolume);
        }

        [TestMethod]
        public void DeepCopy()
        {
            Car car = new Car(1.1, 1.0);
            Car copy = new Car(car);
            car.FuelFlow = 2.2;
            car.FuelVolume = 3.3;
            Assert.AreNotEqual(copy.FuelFlow, car.FuelFlow);
            Assert.AreNotEqual(copy.FuelVolume, car.FuelVolume);
        }

        [TestMethod]
        public void CalculateFunction()
        {
            Car car = new Car(1, 5);
            Assert.AreEqual(car.Calculate(), Car.Calculate(car));
        }

        [TestMethod]
        public void CarCount()
        {
            Car.ResetCount();
            Car car1 = new Car();
            Car car2 = new Car();
            Car car3 = new Car();
            Assert.AreEqual(Car.Count, 3);
        }

        [TestMethod]
        public void CarCountReset()
        {
            Car car1 = new Car();
            Car car2 = new Car();
            Car car3 = new Car();
            Car.ResetCount();
            Assert.AreEqual(Car.Count, 0);
        }

        [TestMethod]
        public void CarFuelOperator()
        {
            Car car = new Car();
            ++car;
            Assert.AreEqual(car.FuelFlow, 0.1);
        }

        [TestMethod]
        public void CarVolumeOperator()
        {
            Car car = new Car(1, 1);
            --car;
            Assert.AreEqual(car.FuelVolume, 0);
        }

        [TestMethod]
        public void CarExplicitTrue()
        {
            Car car = new Car(1, 6);
            Assert.IsTrue((bool)car);
        }

        [TestMethod]
        public void CarExplicitFalse()
        {
            Car car = new Car(1, 3);
            Assert.IsFalse((bool)car);
        }

        [TestMethod]
        public void CarImplicitValid()
        {
            Car car = new Car(1, 10);
            double distance = car;
            Assert.AreEqual(distance, 5);
        }

        [TestMethod]
        public void CarImplicitInvalid()
        {
            Car car = new Car(1, 4);
            double distance = car;
            Assert.AreEqual(distance, -1);
        }

        [TestMethod]
        public void CarLeftSideOperator()
        {
            Car car = new Car();
            car = car + 10;
            Assert.AreEqual(car.FuelVolume, 10);
        }

        [TestMethod]
        public void CarRightSideOperator()
        {
            Car car = new Car();
            car = 10 + car;
            Assert.AreEqual(car.FuelFlow, 10);
        }

        [TestMethod]
        public void CarEqualityTrue()
        {
            Car car = new Car(1, 1);
            Car car1 = new Car(1, 1);
            Assert.IsTrue(car == car1);
        }

        [TestMethod]
        public void CarEqualityFalse()
        {
            Car car = new Car(1, 1);
            Car car1 = new Car(1, 0);
            Assert.IsFalse(car == car1);
        }

        [TestMethod]
        public void CarUnequalityTrue()
        {
            Car car = new Car(1, 1);
            Car car1 = new Car(1, 0);
            Assert.IsTrue(car != car1);
        }

        [TestMethod]
        public void CarUnequalityFalse()
        {
            Car car = new Car(1, 1);
            Car car1 = new Car(1, 1);
            Assert.IsFalse(car != car1);
        }

        // CarArray tests ----------------------------------------------------------------------

        [TestMethod]
        public void CarArrayInitEmpty()
        {
            CarArray arr = new CarArray();
            Assert.AreEqual(arr.Length, 0);
        }

        [TestMethod]
        public void CarArraySetRandom()
        {
            CarArray arr = new CarArray(4, "random");
            Assert.AreEqual(arr.Length, 4);
        }

        //[TestMethod]
        //public void CarArraySet()
        //{
        //    CarArray arr = new CarArray(2, "a");
        //    arr[0] = new Car(1, 1);
        //    arr[1] = new Car(0, 0);
        //    Assert.AreEqual(arr.Length, 4);
        //}

        [TestMethod]
        public void CarArrayCount()
        {
            CarArray.CountReset();
            CarArray arr1 = new CarArray();
            CarArray arr2 = new CarArray(3, "random");
            Assert.AreEqual(CarArray.Count, 2);
        }

        [TestMethod]
        public void CarArrayCountReset()
        {
            CarArray arr1 = new CarArray(4, "random");
            CarArray arr2 = new CarArray();
            CarArray.CountReset();
            Assert.AreEqual(CarArray.Count, 0);
        }

        [TestMethod]
        public void CarArrayCopy()
        {
            CarArray arr = new CarArray(2, "random");
            CarArray copy = new CarArray(arr);
            Assert.IsTrue(arr[1] == copy[1]);
        }

        [TestMethod]
        public void CarArrayDeepCopy()
        {
            CarArray arr = new CarArray(2, "random");
            CarArray copy = new CarArray(arr);
            arr[1] = new Car(100000000, 100000000);
            Assert.IsTrue(arr[1] != copy[1]);
        }

        [TestMethod]
        public void CarArrayException()
        {
            CarArray arr = new CarArray();
            IndexOutOfRangeException exception1 = Assert.ThrowsException<IndexOutOfRangeException>(() => arr[10000] = new Car());
            IndexOutOfRangeException exception2 = Assert.ThrowsException<IndexOutOfRangeException>(() => arr[10000].FuelFlow);
            String message = "Index is out of range";
            Assert.AreEqual(message, exception1.Message);
            Assert.AreEqual(message, exception2.Message);
        }

        [TestMethod]
        public void CarArrayIndex()
        {
            CarArray arr = new CarArray(3, "random");
            Car comp = new Car(100, 100);
            arr[1] = new Car(100, 100);
            Assert.IsTrue(comp == arr[1]);
        }

        // Program func test

        [TestMethod]
        public void FindLowestFunc()
        {
            CarArray arr = new CarArray(2, "random");
            arr[0] = new Car(1, 500);
            arr[1] = new Car(500, 1);
            Assert.AreEqual(arr[1], Program.FindLowest(arr));
        }
    }
}
