using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using Dapper;
using System.Threading;

namespace DBModel.Utils
{
    public static class SqliteDataAccess
    {
        // TODO: fix connection string
        private static readonly string ConnectionString = "Data Source=./Thesis.db;Version=3;";

        public static async Task<List<T>> LoadModel<T>(string tableName) where T : DBModel
        {
            using (IDbConnection cnn = new SQLiteConnection(ConnectionString))
            {
                var output = await cnn.QueryAsync<T>($"select * from {tableName}", new DynamicParameters());
                return output.ToList();
            }
        }


        // TODO: add specific save function for each model


    }
}
