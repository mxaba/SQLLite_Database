using Dapper;
using Microsoft.Data.Sqlite;
using SQLLite_Database.Database;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace SQLLite_Database.Model
{

    public class DeleteUpdate : IDeleteUpdate
    {
        private readonly DatabaseConfig databaseConfig;

        public DeleteUpdate(DatabaseConfig databaseConfig)
        {
            this.databaseConfig = databaseConfig;
        }

        public async Task Update(Coder coder)
        {

            using var connection = new SqliteConnection(databaseConfig.DatabaseConnectionConfiguration);

            IEnumerable<Coder> coderDB = await connection.QueryAsync<Coder>("SELECT rowid AS Id, Email, FirstName, LastName, IdNumber, Description" +
            "FROM Coder WHERE Email=@email;", coder);

            await connection.ExecuteAsync("UPDATE Coder Email=@Email, FirstName=@FirstName, LastName=@LastName, IdNumber=@IdNumber, Description=@Description" +
                "WHERE Email=@Email;", coder);
        }

        public async Task<string> Delete(EmailDelete delete)
        {

            using var connection = new SqliteConnection(databaseConfig.DatabaseConnectionConfiguration);
            Console.WriteLine(delete.Email);
            var value = await connection.ExecuteAsync("DELETE FROM Coder WHERE Email=@Email AND IdNumber=@IdNumber", delete);
            string message = "";

            if (value != 0){
                message = $"Deleted {delete.Email} successfully!";
            } else {
                message = $"This email ({delete.Email} / {delete.IdNumber}) was not found!";
            }
            return message;
        }
    }
}