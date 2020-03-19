using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Data;

namespace FactoryLayer.Services
{
    public class UserService : IEntityService<User>
    {
        private UnitOfWork _uof;

        public UserService()
        {
            _uof = SingletonUnitOfWork.UOW;
        }

        public bool Delete(User entity)
        {
            _uof.UserRepository.Delete(entity);
            return _uof.ApplyChanges();
        }

        public User GetById(int entityID)
        {
            return _uof.UserRepository.List(entityID);
        }

        public List<User> GetList()
        {
            return _uof.UserRepository.ListAll().ToList();
        }

        public bool Insert(User entity)
        {
            _uof.UserRepository.Add(entity);
            return _uof.ApplyChanges();
        }

        public bool Update(User entity)
        {
            _uof.UserRepository.Update(entity);
            return _uof.ApplyChanges();
        }
    }
}
