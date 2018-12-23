using Npgsql;
using System.Configuration;
using System.Data;

namespace Persistance
{
    public class Repository
    {
        internal IDbConnection Connection
        {
            get
            {
                return new NpgsqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            }
        }
    }
}