using Data;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryLayer.Services
{
    public class BrandService : IEntityService<Brand>
    {
        private UnitOfWork _uof;

        public BrandService()
        {
            _uof = SingletonUnitOfWork.UOW;
        }

        public bool Delete(Brand entity)
        {
            _uof.BrandRepository.Delete(entity);
            return _uof.ApplyChanges();
        }

        public Brand GetById(int entityID)
        {
            return _uof.BrandRepository.List(entityID);
        }

        public List<Brand> GetList()
        {
            return _uof.BrandRepository.ListAll().ToList();
        }

        public bool Insert(Brand entity)
        {
            _uof.BrandRepository.Add(entity);
            return _uof.ApplyChanges();
        }

        public bool Update(Brand entity)
        {
            _uof.BrandRepository.Update(entity);
            return _uof.ApplyChanges();
        }
    }
}
