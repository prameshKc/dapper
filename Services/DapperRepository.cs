using Dapper;
using Jumbotron.Services.Interfaces;
using System.Data;

namespace Jumbotron.Services
{
    public class DapperRepository : IDapperRepository
    {
        private readonly IDatabaseFactory _databaseFactory;
        public DapperRepository(IDatabaseFactory databaseFactory)
        {
            _databaseFactory = databaseFactory;
        }

        public void ExecuteStoredProc(string storedProcName, object parameters, int? timeout = null)
        {
            _databaseFactory.Connection.Execute(storedProcName, param: parameters, transaction: _databaseFactory.Transaction, commandType: CommandType.StoredProcedure);

        }
        public IEnumerable<T> ExecuteStoredProc<T>(string storedProcName, object _parameters, int? timeout = null)
        {
            return _databaseFactory.Connection.Query<T>(storedProcName, _parameters, commandTimeout: timeout, commandType: CommandType.StoredProcedure, transaction: _databaseFactory.Transaction);
        }

        public int Execute(string query, object _parameters, int? timeout = null)
        {
            return _databaseFactory.Connection.Execute(query, _parameters, transaction: _databaseFactory.Transaction);
        }

        public IEnumerable<T> ExecuteQuery<T>(string query, object _parameters, int? timeout = null)
        {
            return _databaseFactory.Connection.Query<T>(query, _parameters, transaction: _databaseFactory.Transaction, commandTimeout: timeout);
        }
        public Task ExecuteStoreProcAsync(string storedProcName, object parameters, int? timeout = null)
        {
            return _databaseFactory.Connection.ExecuteAsync(storedProcName, param: parameters, transaction: _databaseFactory.Transaction, commandTimeout: timeout, commandType: CommandType.StoredProcedure);
        }
        public Task<IEnumerable<T>> ExecuteStoredProcAsync<T>(string storedProcName, object _parameters, int? timeout = null)
        {
            return _databaseFactory.Connection.QueryAsync<T>(storedProcName, _parameters, commandType: CommandType.StoredProcedure, transaction: _databaseFactory.Transaction, commandTimeout: timeout);
        }
        public Task<int> ExecuteAsync(string query, object _parameters, int? timeout = null)
        {
            return _databaseFactory.Connection.ExecuteAsync(query, _parameters, transaction: _databaseFactory.Transaction, commandTimeout: timeout);
        }
        public Task<IEnumerable<T>> ExecuteQueryAsync<T>(string query, object _parameters, int? timeout = null)
        {
            return _databaseFactory.Connection.QueryAsync<T>(query, _parameters, transaction: _databaseFactory.Transaction, commandTimeout: timeout);
        }

        public T ExecuteQueryFirstOrDefault<T>(string query, object _parameters)
        {
            return _databaseFactory.Connection.QueryFirstOrDefault<T>(query, _parameters, transaction: _databaseFactory.Transaction);
        }
        public Task<T> ExecuteQueryFirstOrDefaultAsync<T>(string query, object _parameters)
        {
            return _databaseFactory.Connection.QueryFirstOrDefaultAsync<T>(query, _parameters, transaction: _databaseFactory.Transaction);

        }
    }
}
