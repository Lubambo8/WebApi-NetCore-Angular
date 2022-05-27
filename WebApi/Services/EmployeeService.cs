using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Model.Interface;
using WebApi.Models;

namespace WebApi.Services
{
    public class EmployeeService
    {
        private readonly IMongoCollection<Employee> _employee;
        public EmployeeService(IAngularDatabaseSettings setting)
        {
            var client = new MongoClient(setting.ConnectionString);
            var db = client.GetDatabase(setting.DatabaseName);
            _employee = db.GetCollection<Employee>(setting.EmployeeCollectionName);
        }

        public async Task<List<Employee>> GetAllEmployees()
        {
            return await _employee.Find(x => true).ToListAsync();
        }

        public async Task<Employee> GetEmployeeById(string Id)
        {
            return await _employee.Find(x => x.EmployeeID == Id).FirstOrDefaultAsync();
        }

        public async Task<Employee> CreateEmployee(Employee employee)
        {
            await _employee.InsertOneAsync(employee);
            return employee;
        }

        public async Task UpdateEmployee(string id, Employee employee)
        {
            await _employee.ReplaceOneAsync(x => x.EmployeeID == id, employee);

        }

        public async Task DeleteEmployee(string id)
        {
            await _employee.DeleteOneAsync(x => x.EmployeeID == id);

        }
    }
}
