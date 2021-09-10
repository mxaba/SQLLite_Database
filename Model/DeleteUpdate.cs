using Dapper;
using Microsoft.Data.Sqlite;
using SQLLite_Database.Database;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SQLLite_Database.Model
{

    public class DeleteUpdate : IDeleteUpdate
    {
        private readonly DatabaseConfig databaseConfig;

        public DeleteUpdate(DatabaseConfig databaseConfig)
        {
            this.databaseConfig = databaseConfig;
        }

        public async Task Update(Coder Coder)
        {

            using var connection = new SqliteConnection(databaseConfig.DatabaseConnectionConfiguration);

            IEnumerable<Coder> coderDB = await connection.QueryAsync<Coder>("SELECT rowid AS Id, Email, FirstName, LastName, IdNumber, Description" +
            "FROM Coder WHERE Email=@email;", new { email = Coder.Email });

            await connection.ExecuteAsync("UPDATE Coder Email=@Email, FirstName=@FirstName, LastName=@LastName, IdNumber=@IdNumber, Description=@Description" +
                "WHERE Email=@Email;", Coder);
        }

        public async Task<string> Delete(string Email)
        {

            using var connection = new SqliteConnection(databaseConfig.DatabaseConnectionConfiguration);

            await connection.ExecuteAsync("DELETE FROM Coder WHERE Email=@Email;", new { Email = Email });
            return $"Deleted{Email}";
        }
    }
}