using Jumbotron.Services.Interfaces;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Jumbotron.Services
{
    public class DatabaseFactory : IDatabaseFactory
    {
        private IDbConnection _connection;
        private IDbTransaction _dbTransaction;
        private IConfiguration _configuration;
        public DatabaseFactory(IConfiguration configuration)
        {
            _configuration = configuration;
            ConnectionString = _configuration.GetConnectionString("DefaultConnection");
        }
        public string ConnectionString { get; set; }

        public IDbConnection Connection
        {
            get
            {
                if (_connection == null)
                {
                    _connection = new SqlConnection(ConnectionString);
                }
                return _connection;
            }
        }

        public IDbTransaction Transaction
        {
            get
            {
                return _dbTransaction;
            }
        }

        public void ChangeConnection(IDbConnection toConnection)
        {
            _connection = toConnection;
        }

        public void ChangeTransaction(IDbTransaction toTransaction)
        {
            _dbTransaction = toTransaction;
        }
    
}
}
