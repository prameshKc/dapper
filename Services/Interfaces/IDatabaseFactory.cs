using System.Data;

namespace Jumbotron.Services.Interfaces
{
    public interface IDatabaseFactory
    {
        string ConnectionString { get; }
        IDbConnection Connection { get; }
        IDbTransaction Transaction { get; }
        void ChangeConnection(IDbConnection toConnection);
        void ChangeTransaction(IDbTransaction toTransaction);
    }
}
