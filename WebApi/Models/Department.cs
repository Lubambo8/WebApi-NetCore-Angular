using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class Department
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string DepartmentId { get; set; }
        public string DepartmentName { get; set; }

        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public List<string> Employees { get; set; }

        [BsonIgnore]
        public List<Employee> EmployeeList { get; set; }
    }
}
