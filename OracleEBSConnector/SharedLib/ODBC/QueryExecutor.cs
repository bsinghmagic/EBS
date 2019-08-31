using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ODBC
{
    public class QueryExecutor
    {
        public static readonly DataTable EmptyDataTable = GetEmptyDataTable();

        private static DataTable GetEmptyDataTable()
        {
            DataTable table = new DataTable();
            table.Columns.Add("There are no results...");
            return table;
        }

        private readonly OracleConnection connection;

        public QueryExecutor(OracleConnection connection)
        {
            this.connection = connection ?? throw new ArgumentNullException(nameof(connection));
        }

        public TimeSpan Timeout { get; set; }

        public async Task<DataTable> ExecuteQueryAsync(string commandText, CancellationToken token)
        {
            //await Task.Delay(TimeSpan.FromSeconds(5), token);
            if (connection.State != ConnectionState.Open)
            {
                await connection.OpenAsync(token);
            }
            using (var command = connection.CreateCommand())
            {
                command.CommandTimeout = (int)Timeout.TotalSeconds;
                command.CommandText = commandText;

                using (var reader = await command.ExecuteReaderAsync(token))
                {
                    DataTable table = new DataTable();

                   await Task.Run(() =>
                    {
                        if (reader.HasRows)
                        {
                            table.Load(reader);
                        }
                     }, token);                    
                    return table;
                }
            }
        }
        public async Task<Boolean> ExecuteNonQueryAsync(string commandText, CancellationToken token)
        {
            bool InsertedStatus = false;
            //await Task.Delay(TimeSpan.FromSeconds(5), token);
            if (connection.State != ConnectionState.Open)
            {
                await connection.OpenAsync(token);
            }
            //connection.Open();
            using (var command = connection.CreateCommand())
            {
                command.CommandTimeout = (int)Timeout.TotalSeconds;
                command.CommandText = commandText;

                if (await command.ExecuteNonQueryAsync(token)>=1) {
                    return InsertedStatus = true;
                }
                //else
                //{
                //    return InsertedStatus;
                //}                            
            }
            return InsertedStatus;

        }
    }

}
