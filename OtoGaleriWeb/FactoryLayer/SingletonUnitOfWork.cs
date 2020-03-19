using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryLayer
{
    class SingletonUnitOfWork
    {
        private static UnitOfWork _uof;

        private SingletonUnitOfWork()
        {

        }

        public static UnitOfWork UOW
        {
            get
            {
                if (_uof == null)
                {
                    _uof = new UnitOfWork();
                }
                return _uof;
            }
        }
    }
}
