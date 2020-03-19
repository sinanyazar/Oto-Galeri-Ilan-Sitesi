using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Entities;

namespace FactoryLayer.Services
{
    public class CarService : IEntityService<Car>
    {
        private UnitOfWork _uof;

        public CarService()
        {
            _uof = SingletonUnitOfWork.UOW;
        }

        public bool Delete(Car entity)
        {
            _uof.CarRepository.Delete(entity);
            return _uof.ApplyChanges();
        }

        public Car GetById(int entityID)
        {
            return _uof.CarRepository.List(entityID);
        }

        public List<Car> GetList()
        {
            return _uof.CarRepository.ListAll().ToList();
        }

        public bool Insert(Car entity)
        {
            _uof.CarRepository.Add(entity);
            return _uof.ApplyChanges();
        }

        public bool Update(Car entity)
        {
            _uof.CarRepository.Update(entity);
            return _uof.ApplyChanges();
        }
    }
}
