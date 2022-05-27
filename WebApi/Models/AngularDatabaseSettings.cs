using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Model.Interface;

namespace WebApi.Models
{
    public class AngularDatabaseSettings : IAngularDatabaseSettings
    {
        public string EmployeeCollectionName { get; set; }
        public string DepartmentCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
