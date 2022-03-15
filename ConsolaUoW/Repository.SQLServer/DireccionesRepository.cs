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
    public class DireccionesRepository : Repository, IDireccionesRepository
    {
        public DireccionesRepository(SqlConnection context, SqlTransaction transaction) : base(context, transaction)
        {

        }

        public void Add(Direccion direccion)
        {
            throw new NotImplementedException();
        }

        public Direccion Get(int id)
        {
            SqlCommand cmd = base.CreateCommand("SELECT * FROM Direccion where ID = @Id");
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                reader.Read();
                return new Direccion(reader.GetString(1), reader.GetString(2), reader.GetString(2));
            }
        }

        public List<Direccion> GetDireccions()
        {
            throw new NotImplementedException();
        }
    }
}
