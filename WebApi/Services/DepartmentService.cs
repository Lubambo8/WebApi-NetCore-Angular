using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Model.Interface;
using WebApi.Models;

namespace WebApi.Services
{
    public class DepartmentService
    {
        private readonly IMongoCollection<Department> _department;
        public DepartmentService(IAngularDatabaseSettings setting)
        {
            var client = new MongoClient(setting.ConnectionString);
            var db = client.GetDatabase(setting.DatabaseName);
            _department = db.GetCollection<Department>(setting.DepartmentCollectionName);
        }

        public async Task<List<Department>> GetAllDepartments()
        {
            return await _department.Find(x => true).ToListAsync();
        }

        public async Task<Department> GetDepartmentById(string Id)
        {
            return await _department.Find(x => x.DepartmentId == Id).FirstOrDefaultAsync();
        }

        public async Task<Department> CreateDepartment(Department department)
        {
            await _department.InsertOneAsync(department);
            return department;
        }

        public async Task UpdateDepartment(string id, Department department)
        {
            await _department.ReplaceOneAsync(x => x.DepartmentId == id, department);

        }

        public async Task DeleteDepartment(string id)
        {
            await _department.DeleteOneAsync(x => x.DepartmentId == id);

        }
    }
}
