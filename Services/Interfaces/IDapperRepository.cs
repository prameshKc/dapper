namespace Jumbotron.Services.Interfaces
{
    public interface IDapperRepository
    {
        Task ExecuteStoreProcAsync(string storedProcName, object parameters, int? timeout = null);
        void ExecuteStoredProc(string storedProcName, object parameters, int? timeout = null);
        IEnumerable<T> ExecuteStoredProc<T>(string storedProcName, object _parameters, int? timeout = null);
        Task<IEnumerable<T>> ExecuteStoredProcAsync<T>(string storedProcName, object _parameters, int? timeout = null);
        int Execute(string query, object _parameters, int? timeout = null);
        Task<int> ExecuteAsync(string query, object _parameters, int? timeout = null);
        IEnumerable<T> ExecuteQuery<T>(string query, object _parameters, int? timeout = null);
        T ExecuteQueryFirstOrDefault<T>(string query, object _parameters);
        Task<T> ExecuteQueryFirstOrDefaultAsync<T>(string query, object _parameters);
        Task<IEnumerable<T>> ExecuteQueryAsync<T>(string query, object _parameters, int? timeout = null);
    }
}
