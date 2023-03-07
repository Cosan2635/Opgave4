using Opgave1;
using System.Xml.Linq;

namespace Opgave4.Repository
{
    public class CarRepository
    {
        private int _nextId;
        private List<Car> _cars;

        public CarRepository()
        {
            _nextId = 1;
            _cars = new List<Car>()
            {
                new Car() { Id = _nextId++, LicensePlate ="Zx36434", Model= "Mazda 3", Price = 250000 },
                new Car() { Id = _nextId++, LicensePlate="By80401", Model = "Mazda 6", Price = 45000},
                new Car() { Id = _nextId++, LicensePlate = "Mo2635", Model = "Cupra Formentor", Price = 50000 },
                
            };
        }
        public List<Car> GetAll()
        {
            return new List<Car>(_cars);

        }


        public Car? GetById(int id)
        {
            return _cars.Find(car => car.Id == id);
        }

        public Car? Add(Car newCar)
        {
            newCar.Id = _nextId++;
            _cars.Add(newCar);
            return newCar;
        }
        public Car? Delete(int id)
        {
            Car? foundCar = GetById(id);
            if (foundCar == null)
            {
                return null;
            }
            _cars.Remove(foundCar);
            return foundCar;
        }
        public Car? Update(int id, Car updates)
        {
            Car? foundCar = GetById(id);
            if (foundCar == null)
            {
                return null;
            }
            foundCar.LicensePlate = updates.LicensePlate;
            foundCar.Model = updates.Model;
            foundCar.Price = updates.Price;
            return foundCar;
        }
    }

}

