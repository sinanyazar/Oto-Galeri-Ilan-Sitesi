using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Entities;

namespace FactoryLayer.Services
{
    public class ModelService : IEntityService<Model>
    {
        private UnitOfWork _uof;

        public ModelService()
        {
            _uof = SingletonUnitOfWork.UOW;
        }

        public bool Delete(Model entity)
        {
            _uof.ModelRepository.Delete(entity);
            return _uof.ApplyChanges();
        }

        public Model GetById(int entityID)
        {
            return _uof.ModelRepository.List(entityID);
        }

        public List<Model> GetList()
        {
            return _uof.ModelRepository.ListAll().ToList();
        }

        public bool Insert(Model entity)
        {
            _uof.ModelRepository.Add(entity);
            return _uof.ApplyChanges();
        }

        public bool Update(Model entity)
        {
            _uof.ModelRepository.Update(entity);
            return _uof.ApplyChanges();
        }
    }
}
