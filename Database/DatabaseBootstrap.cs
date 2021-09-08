using Dapper;
using Microsoft.Data.Sqlite;
using SQLLite_Database.Model;
using System.Linq;
using System.Threading.Tasks;

namespace SQLLite_Database.Database
{

    public class DatabaseBootstrap : IDatabaseBootstrap
    {
        private readonly ICoderRepository coderRepository;
        private readonly DatabaseConfig databaseConfig;

        public DatabaseBootstrap(DatabaseConfig databaseConfig, ICoderRepository coderRepository)
        {
            this.databaseConfig = databaseConfig;
            this.coderRepository = coderRepository;
        }

        public void Setup()
        {
            using var connection = new SqliteConnection(databaseConfig.DatabaseConnectionConfiguration);

            var table = connection.Query<string>("SELECT name FROM sqlite_master WHERE type='table' AND name = 'Coder';");
            var tableName = table.FirstOrDefault();
            if (!string.IsNullOrEmpty(tableName) && tableName == "Coder")
                // connection.Execute("DROP TABLE Coder");
                return;

            connection.Execute("Create Table Coder (" +
                "UserName VARCHAR(100) NOT NULL," +
                "FirstName VARCHAR(100) NOT NULL," +
                "LastName VARCHAR(100) NOT NULL," +
                "IdNumber VARCHAR(100) NOT NULL," +
                "Description VARCHAR(1000) NULL);"
            );

            int i = 0;
            while (i <= 200000)
            {
                var coderData = new Coder(){
                    UserName = Faker.Internet.UserName(),
                    FirstName = Faker.Name.First(),
                    LastName = Faker.Name.Last(),
                    IdNumber = Faker.Identification.UsPassportNumber(),
                    Description = Faker.Lorem.Sentence(3),
                };
                Task.Run(async () =>
                {
                    await coderRepository.Create(coderData);
                    // Do any async anything you need here without worry
                }).GetAwaiter().GetResult();
                i++;
            }

            
        }
    }
}