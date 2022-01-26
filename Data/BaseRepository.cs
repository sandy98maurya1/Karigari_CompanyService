using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class BaseRepository : IDisposable
    {
        public IDbConnection connection;
        public BaseRepository()
        {
            string connectionString = "Data Source=****;Initial Catalog=DataManagement;Integrated Security=True";
            connection = new SqlConnection(connectionString);
        }
        public void Dispose()
        {
            //throw new NotImplementedException();  
        }
    }
}