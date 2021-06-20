using System;
using Microsoft.Azure.Cosmos.Table;
namespace azure_table_Storage
{
    class Program
    {
        private static string connection_string ="DefaultEndpointsProtocol=https;AccountName=azuredemos;AccountKey=1UnsiyBnMus5A+ZwniokQxzRWoQX90Qyk3/YluGWveO9AYqsGgklPzW7sHRZJP/bljY17dPfzJKfaxAMbaTbbg==;EndpointSuffix=core.windows.net";
        private static string table_name ="archivedata";

        static void Main(string[] args)
        {
            try{
                Console.WriteLine("Started Table Storage demo");
                CloudStorageAccount _account = CloudStorageAccount.Parse(connection_string);
                CloudTableClient _tableClient = _account.CreateCloudTableClient();
                CloudTable _table = _tableClient.GetTableReference(table_name);
                _table.CreateIfNotExists();
                Console.WriteLine("Table created succecssfully");
            
                 Console.WriteLine("Started Table Entity.");

                 Employee _employee = new Employee("Potti", "Kakinada", "SN");
                 TableOperation _tableOperation = TableOperation.Insert(_employee);

                 TableResult _result = _table.Execute(_tableOperation);

                 Console.WriteLine("Ended Table Entity.");

                Console.WriteLine("Ended Table Storage demo");
            
                Console.ReadKey();
            }
            catch(Exception ex){
                Console.WriteLine("Issue while creating a table.");
                throw ex;
            }
        }
    }
}
