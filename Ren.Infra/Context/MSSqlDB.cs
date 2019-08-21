using System.Data;
using System.Data.SqlClient;

namespace Ren.Infra.Context
{
    public class MSSqlDB : IDB
    {
        private SqlConnection _db;

        public IDbConnection Connection()
        {
            _db = new SqlConnection(Settings.ConnectionString);
            return _db;
        }

        public void Dispose()
        {
            if (_db.State != ConnectionState.Closed)
                _db.Close();
        }
    }
}