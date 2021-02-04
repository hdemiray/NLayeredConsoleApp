using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{Id=1,BrandId=1,ColorId=3, ModelYear=2021,DailyPrice=2500,Description="Volkswagen Passat"},
                new Car{Id=2,BrandId=1,ColorId=5, ModelYear=2020,DailyPrice=1300,Description="Opel Insignia"},
                new Car{Id=3,BrandId=2,ColorId=2, ModelYear=2019,DailyPrice=500,Description="Dacia Duster"},
                new Car{Id=4,BrandId=2,ColorId=6, ModelYear=2018,DailyPrice=760,Description="Ford Focus"},
                new Car{Id=5,BrandId=2,ColorId=7, ModelYear=2017,DailyPrice=350,Description="Hyundai i30"}
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carsToDelete = _cars.SingleOrDefault(c => car.Id == car.Id);
            _cars.Remove(car);
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            return _cars;
        }

        public List<Car> GetById(int brandId)
        {
            return _cars.Where(p => p.BrandId == brandId).ToList();
        }

        public Car GetById(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carsToUpdate = _cars.SingleOrDefault(c => car.Id == car.Id);
            carsToUpdate.ModelYear = car.ModelYear;
            carsToUpdate.ColorId = car.ColorId;
            carsToUpdate.BrandId = car.BrandId;
            carsToUpdate.DailyPrice = car.DailyPrice;
            carsToUpdate.Description = car.Description;
        }
    }
}
