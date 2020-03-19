using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Repositories;
using Entities;

namespace Data
{
    public class UnitOfWork
    {
        private GaleriDBEntities _dbContext;
        private DbContextTransaction _transaction;

        // Repositoryler
        private AdvertisementRepository advertisementRepository;
        private BrandRepository brandRepository;
        private CarRepository carRepository;
        private ModelRepository modelRepository;
        private UserRepository userRepository;

        public UnitOfWork()
        {
            _dbContext = new GaleriDBEntities();
        }

        public bool ApplyChanges()
        {
            bool success = false;
            _transaction = _dbContext.Database.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);

            try
            {
                _dbContext.SaveChanges();
                _transaction.Commit();
                success = true;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                _transaction.Rollback();
                success = false;
            }
            finally
            {
                _transaction.Dispose();
            }

            return success;
        }

        public AdvertisementRepository AdvertisementRepository => advertisementRepository ?? new AdvertisementRepository(_dbContext);
        public BrandRepository BrandRepository => brandRepository ?? new BrandRepository(_dbContext);
        public CarRepository CarRepository => carRepository ?? new CarRepository(_dbContext);
        public ModelRepository ModelRepository => modelRepository ?? new ModelRepository(_dbContext);
        public UserRepository UserRepository => userRepository ?? new UserRepository(_dbContext);
    }
}
