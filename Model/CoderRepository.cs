using Dapper;
using Microsoft.Data.Sqlite;
using SQLLite_Database.Database;
using System.Threading.Tasks;

namespace SQLLite_Database.Model
{
    public class CoderRepository : ICoderRepository
    {
        private readonly DatabaseConfig databaseConfig;

        public CoderRepository(DatabaseConfig databaseConfig)
        {
            this.databaseConfig = databaseConfig;
        }

        public async Task Create(Coder Coder)
        {
            using var connection = new SqliteConnection(databaseConfig.DatabaseConnectionConfiguration);

            await connection.ExecuteAsync("INSERT INTO Coder (Email, FirstName, LastName, IdNumber, Description)" +
                "VALUES (@Email, @FirstName, @LastName, @IdNumber, @Description);", Coder);
        }
    }
}