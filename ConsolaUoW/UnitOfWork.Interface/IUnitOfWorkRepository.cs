using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitOfWork.Interface
{
    public interface IUnitOfWorkRepository
    {
        IClienteRepository Clientes { get; }
    }
}
