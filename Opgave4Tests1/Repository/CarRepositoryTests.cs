using Microsoft.VisualStudio.TestTools.UnitTesting;
using Opgave4.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Opgave1;

namespace Opgave4.Repository.Tests
{
    [TestClass()]
    public class CarRepositoryTests
    {
        [TestMethod()]
        public void GetAllTest()
        {
            CarRepository repository = new CarRepository();

            List<Car> cars = repository.GetAll();

            Assert.IsNotNull(cars);
            Assert.IsTrue(cars.Count() > 0);
        }

        [TestMethod()]
        public void GetByIdTest()
        {
            CarRepository repository = new CarRepository();
            Car? car = repository.GetById(1);
            Assert.IsNotNull(car);
            Assert.AreEqual(car.Id, 1);
            Assert.AreEqual(car.LicensePlate, "Zx36434");
            Assert.AreEqual(car.Model, "Mazda 3");
            Assert.AreEqual(car.Price, 250000);
        }

        [TestMethod()]
        public void AddTest()
        {
            Car newCar = new Car() { Id = 1, Model = "Aygo12", LicensePlate = "Mo1233", Price = 45000 };
            CarRepository repository = new CarRepository();

            Car car = repository.Add(newCar);

            Assert.IsNotNull(car);
            Assert.AreEqual(car.Id, 4);
            Assert.IsTrue(car.Model.Length > 4);
            Assert.IsTrue(car.LicensePlate.Length > 2 || car.LicensePlate.Length < 7);
            Assert.IsTrue(car.Price > 0);
        }

        //        [TestMethod()]
        //        public void DeleteTest()
        //        {
        //            Assert.Fail();
        //        }

        //        [TestMethod()]
        //        public void UpdateTest()
        //        {
        //            Assert.Fail();
    }
}