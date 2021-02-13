//using DataAccess.Abstract;
//using Entities.Concrete;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

//namespace DataAccess.Concrete.InMemory
//{
//    public class InMemoryCarDal : ICarDal
//    {
//        List<Car> _car;
//        public InMemoryCarDal()
//        {
//            _car = new List<Car>
//            {
//                new Car {Id=1, BrandId=1, ColorId=1, DailyPrice=200, ModelYear=2009, Description="Araba 1"},
//                new Car {Id=2, BrandId=2, ColorId=3, DailyPrice=400, ModelYear=2010, Description="Araba 2"},
//                new Car {Id=3, BrandId=3, ColorId=4, DailyPrice=300, ModelYear=2013, Description="Araba 3"},
//                new Car {Id=4, BrandId=4, ColorId=7, DailyPrice=600, ModelYear=2017, Description="Araba 4"},
//                new Car {Id=5, BrandId=5, ColorId=9, DailyPrice=550, ModelYear=2015, Description="Araba 5"},
//            };
//        }

//        public void Add(Car car)
//        {
//            _car.Add(car);
//        }

//        public void Delete(Car car)
//        {
//            Car carToDelete = _car.SingleOrDefault(c=> c.Id == car.Id);
//            _car.Remove(carToDelete);
//        }

//        public List<Car> GetAll()
//        {
//            return _car;
//        }

//        public List<Car> GetById(int CarId)
//        {
//            return _car.Where(c => c.Id == CarId).ToList();
//        }

//        public void Update(Car car)
//        {
//            Car carToUpdate = _car.SingleOrDefault(c => c.Id == car.Id);
//            carToUpdate.Id = car.Id;
//            carToUpdate.BrandId = car.BrandId;
//            carToUpdate.ColorId = car.ColorId;
//            carToUpdate.DailyPrice = car.DailyPrice;
//            carToUpdate.ModelYear = car.ModelYear;
//            carToUpdate.Description = car.Description;
//        }
//    }
//}
