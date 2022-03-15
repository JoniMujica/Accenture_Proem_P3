using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork.Interface;

namespace UnitOfWork.SQLServer
{
    public class UnitOfWorkAdapter : IUnitOfWorkAdapter
    {
        private SqlConnection context;
        private SqlTransaction transaction;
        public UnitOfWorkAdapter(string connectionString)
        {
            this.context = new SqlConnection(connectionString);
            this.context.Open();
            this.transaction = context.BeginTransaction();
            this.Repositories = new UnitOfWorkRepository(context, transaction);
        }

        public IUnitOfWorkRepository Repositories { get; set; }

        public void Dispose()
        {
            if(this.transaction != null)
            {
                this.transaction.Dispose();
            }
            if(this.context != null)
            {
                this.context.Close();
                this.context.Dispose();
            }
        }

        public void SaveChanges()
        {
            this.transaction.Commit();
        }
    }
}
