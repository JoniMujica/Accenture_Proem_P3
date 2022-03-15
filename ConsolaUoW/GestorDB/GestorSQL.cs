using Entidades;
using System;
using UnitOfWork.Interface;

namespace GestorDB
{
    public class GestorSQL
    {
        private IUnitOfWork unitOfWork;
        public GestorSQL(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public Cliente GetCliente(int id)
        {
            using(IUnitOfWorkAdapter context = this.unitOfWork.Create())
            {
                return context.Repositories.Clientes.Get(id);
            }
        }
    }
}
