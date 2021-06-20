using Microsoft.Azure.Cosmos.Table;

namespace azure_table_Storage{
    public class Employee : TableEntity
    {
        public string EmployeeName {get; set;}

        public Employee(string _employeeName,string _employeeCity, string _eid)
        {
            PartitionKey = _employeeCity;
            RowKey = _eid;
            EmployeeName = _employeeName;        
        }
    }
}