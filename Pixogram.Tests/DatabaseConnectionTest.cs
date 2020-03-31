using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Pixogram.Tests
{
  public  class DatabaseConnectionTest
    {
        string _dbLocation = "./ pixogram.db";
        //private readonly IDbConnectionFactory _dbConnectionFactory;

        //public DatabaseConnectionTests(IDbConnectionFactory dbConnectionFactory)
        //{
        //    _dbConnectionFactory = dbConnectionFactory;

        //}

        public async Task<IDbConnection> CreateConnectionAsync()
        {
            var connection = new SqliteConnection($"Data Source={_dbLocation}");
            await connection.OpenAsync();
            return connection;
        }

        [Fact]
        public void Test_For_DatabaseConnection()
        {
            var connection = CreateConnectionAsync();
            Assert.NotNull(connection);
        }
    }
}
