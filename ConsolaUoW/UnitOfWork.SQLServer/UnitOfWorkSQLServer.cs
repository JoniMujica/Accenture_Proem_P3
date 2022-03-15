using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork.Interface;

namespace UnitOfWork.SQLServer
{
    public class UnitOfWorkSQLServer : IUnitOfWork
    {
        public IUnitOfWorkAdapter Create()
        {
            return new UnitOfWorkAdapter("Server=.;Database=.NET-PROEM;Trusted_Connection=True");
        }
    }
}
