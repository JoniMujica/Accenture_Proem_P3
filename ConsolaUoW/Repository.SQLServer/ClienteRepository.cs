using Entidades;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.SQLServer
{
    public class ClienteRepository : Repository, IClienteRepository
    {
        public ClienteRepository(SqlConnection context, SqlTransaction transaction) : base(context, transaction)
        {

        }

        public void Add(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public Cliente Get(int id)
        {
            SqlCommand cmd = base.CreateCommand("SELECT * FROM Clientes where ID = @id");
            cmd.Parameters.AddWithValue("id", id);
            using(SqlDataReader reader = cmd.ExecuteReader())
            {
                reader.Read();
                return new Cliente(reader.GetString(1), reader.GetString(2), reader.GetInt32(4));
            }
        }
    }
}
