using Dapper;
using Microsoft.Data.Sqlite;
using SQLLite_Database.Database;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace SQLLite_Database.Model
{

    public class CoderProvider : ICoderProvider
    {
        private readonly DatabaseConfig databaseConfig;

        public CoderProvider(DatabaseConfig databaseConfig)
        {
            this.databaseConfig = databaseConfig;
        }

        public async Task<IEnumerable<Coder>> Get()
        {
            using var connection = new SqliteConnection(databaseConfig.DatabaseConnectionConfiguration);

            return await connection.QueryAsync<Coder>("SELECT rowid AS Id, Email, FirstName, LastName, IdNumber, Description FROM Coder;");
        }
    }
}