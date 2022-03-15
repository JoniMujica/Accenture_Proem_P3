using Repository.Interfaces;
using Repository.SQLServer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork.Interface;

namespace UnitOfWork.SQLServer
{
    public class UnitOfWorkRepository : IUnitOfWorkRepository
    {
        public UnitOfWorkRepository(SqlConnection context,SqlTransaction transaction)
        {
            this.Clientes = new ClienteRepository(context, transaction);
            this.Direcciones = new DireccionesRepository(context, transaction);
        }
        public IClienteRepository Clientes { get; }
        public IDireccionesRepository Direcciones { get; }
    }
}
