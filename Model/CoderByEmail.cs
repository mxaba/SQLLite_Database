using Dapper;
using Microsoft.Data.Sqlite;
using SQLLite_Database.Database;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace SQLLite_Database.Model
{
    public class CoderByEmail : ICoderByEmail
    {
        private readonly DatabaseConfig databaseConfig;

        public CoderByEmail(DatabaseConfig databaseConfig)
        {
            this.databaseConfig = databaseConfig;
        }

        public async Task<IEnumerable<Coder>> GetByEmail(string email)
        {
            using var connection = new SqliteConnection(databaseConfig.DatabaseConnectionConfiguration);

            return await connection.QueryAsync<Coder>("SELECT rowid AS Id, Email, FirstName, LastName, IdNumber, Description FROM Coder WHERE Email=@email;", new{email=email} );
        }

        public async Task<IEnumerable<Coder>> GetById(string IdNumber)
        {
            using var connection = new SqliteConnection(databaseConfig.DatabaseConnectionConfiguration);

            return await connection.QueryAsync<Coder>("SELECT rowid AS Id, Email, FirstName, LastName, IdNumber, Description FROM Coder WHERE IdNumber=@IdNumber;", new{IdNumber=IdNumber});
        }

        public async Task<IEnumerable<Coder>> GetByEmailExplain(string Email)
        {
            using var connection = new SqliteConnection(databaseConfig.DatabaseConnectionConfiguration);

            return await connection.QueryAsync<Coder>("EXPLAIN QUERY PLAN SELECT rowid AS Id, Email, FirstName, LastName, IdNumber, Description FROM Coder WHERE Email=@Email;", new{Email=Email});
        }

        public async Task<IEnumerable<Coder>> GetByIdExplain(string IdNumber)
        {
            using var connection = new SqliteConnection(databaseConfig.DatabaseConnectionConfiguration);

            return await connection.QueryAsync<Coder>("EXPLAIN QUERY PLAN SELECT rowid AS Id, Email, FirstName, LastName, IdNumber, Description FROM Coder WHERE IdNumber=@IdNumber;", new{IdNumber=IdNumber});
        }
    }
}