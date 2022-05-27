using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class Employee
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string EmployeeID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        //[BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        //public string DepartmentID { get; set; }

        //[ForeignKey(nameof(DepartmentID))]
        //public Department Department { get; set; }
        public string DateOfJoining { get; set; }
        public string PhotoFileName { get; set; }
    }
}
