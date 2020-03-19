using Data;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryLayer.Services
{
    public class AdvertisementService : IEntityService<Advertisement>
    {
        private UnitOfWork _uof;

        public AdvertisementService()
        {
            _uof = SingletonUnitOfWork.UOW;
        }

        public bool Delete(Advertisement entity)
        {
            _uof.AdvertisementRepository.Delete(entity);
            return _uof.ApplyChanges();
        }

        public Advertisement GetById(int entityID)
        {
            return _uof.AdvertisementRepository.List(entityID);
        }

        public List<Advertisement> GetList()
        {
            return _uof.AdvertisementRepository.ListAll().ToList();
        }

        public bool Insert(Advertisement entity)
        {
            _uof.AdvertisementRepository.Add(entity);
            return _uof.ApplyChanges();
        }

        public bool Update(Advertisement entity)
        {
            _uof.AdvertisementRepository.Update(entity);
            return _uof.ApplyChanges();
        }
    }
}
