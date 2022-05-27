using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Model.Interface
{
    public interface IAngularDatabaseSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string EmployeeCollectionName { get; set; }
        public string DepartmentCollectionName { get; set; }
    }
}
