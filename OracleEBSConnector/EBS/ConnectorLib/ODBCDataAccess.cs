using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ODBC;
using Oracle.ManagedDataAccess.Client;
using log4net;
using log4net.Config;
using Utility;

namespace EBS
{
    public class ODBCDataAccess
    {
        private static QueryExecutor executor;
        private static CancellationTokenSource tokenSource;
        private static readonly ILog Log = LogManager.GetLogger(typeof(ODBCDataAccess));
        public static QueryModel Model { get; set; }
        private static async Task<DataTable> ExecuteQuery(string commandText, CancellationToken token)
        {
            if (String.IsNullOrWhiteSpace(commandText))
            {
                return QueryExecutor.EmptyDataTable;
            }
            try
            {
                var dataTable = await executor.ExecuteQueryAsync(Model.CommandText, token);

                return dataTable;
            }
            catch (OperationCanceledException)
            {
                return QueryExecutor.EmptyDataTable;
            }
            catch (Exception exception)
            {
        throw exception;
            }
        }
        private static async Task<Boolean> ExecuteNonQuery(string commandText, CancellationToken token)
        {
            if (String.IsNullOrWhiteSpace(commandText))
            {
                return false;
            }

            try
            {
                bool dataTable = await executor.ExecuteNonQueryAsync(Model.CommandText, token);
                return dataTable;
            }
            catch (OperationCanceledException)
            {
                return false;
            }
            catch (Exception exception)
            {
                return false;

            }
        }
        public static async Task<List<string>> GetResult(string connectionString, string commandText,string LastSync = "")
        {
            commandText = commandText.Replace("[[LastSync]]", LastSync);
            
            Log.Info(string.Format("commandText afer lastsync replace :: {0}", commandText));
            List<string> list = new List<string>();
            var connection = new OracleConnection(connectionString);
            executor = new QueryExecutor(connection) { Timeout = TimeSpan.FromSeconds(30) };
            Model = new QueryModel();
            Model.CommandText = commandText;
            if (Model.IsExecuting)
            {
                tokenSource?.Cancel();
                return null;
            }
            try
            {
                Model.IsExecuting = true;
                tokenSource?.Dispose();
                tokenSource = new CancellationTokenSource();
                var dataTable = await ExecuteQuery(Model.CommandText, tokenSource.Token);

                var dataRows = dataTable.AsEnumerable().ToChunks(225)
                    .Select(rows => rows.CopyToDataTable());
                foreach (var row in dataRows)
                {                                      
                    list.Add(DatatableToJSON(row));                  
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                Model.IsExecuting = false;
            }

            return list;
        }

        public static async Task<string> GetResultNonQuery(string connectionString, string commandText)
        {
            var connection = new OracleConnection(connectionString);
            executor = new QueryExecutor(connection) { Timeout = TimeSpan.FromSeconds(30) };
            Model = new QueryModel();
            Model.CommandText = commandText;
            if (Model.IsExecuting)
            {
                tokenSource?.Cancel();
                return "";
            }
            try
            {
                Model.IsExecuting = true;
                tokenSource?.Dispose();
                tokenSource = new CancellationTokenSource();
                var dataTable = await ExecuteNonQuery(Model.CommandText, tokenSource.Token);
                //return DatatableToJSON(dataTable);
                if (dataTable) {
                    return "true";
                }
                else
                {
                    return "false";
                }            

            }
            finally
            {
                Model.IsExecuting = false;
            }
        }

        public static string DatatableToJSON(DataTable dataTable)
        {
            return JsonConvert.SerializeObject(dataTable);

        }

    }
}
