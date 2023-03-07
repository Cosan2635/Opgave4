using Microsoft.VisualStudio.TestTools.UnitTesting;
using Opgave4.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Opgave1;

namespace Opgave4.Repository.Tests
{
    [TestClass()]
    public class CarRepositoryTests
    {
        public Car car = new Car() { Id = 1, LicensePlate = "Zx36434", Model = "Mazda 3", Price = 250000 };
        public Car ModelMindreend4 = new Car() { Id = 2, LicensePlate = "By80401", Model = "Mazda 6", Price = 45000 };
        public Car NegCarPrice = new Car() { Id = 3, LicensePlate = "Mo2635", Model = "Cupra Formentor", Price = -250 };


        [TestMethod()]
        public void ValidateModelTest()
        {
            ModelMindreend4.ValidateModel();
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => ModelMindreend4.ValidateModel());
        }

        [TestMethod()]
        public void ValidatePriceTest()
        {
            NegCarPrice.ValidatePrice();
            Assert.ThrowsException<ArgumentOutOfRangeException>(NegCarPrice.ValidatePrice);
        }
    }
}