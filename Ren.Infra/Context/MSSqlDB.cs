using System.Data;
using System.Data.SqlClient;

namespace Ren.Infra.Context
{
    public class MSSqlDB : IDB
    {
        private SqlConnection db;

        public IDbConnection Connection()
        {
            db = new SqlConnection(Settings.ConnectionString);
            return db;
        }

        public void Dispose()
        {
            if (db.State != ConnectionState.Closed)
                db.Close();
        }
    }
}