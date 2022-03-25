using Dapper;
using EmployeeApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeApi.Daos
{
    public class EmployeeDao
    {
        private readonly DapperContext _context;

        public EmployeeDao(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            var query = "SELECT * FROM Employee";
            using (var connection = _context.CreateConnection())
            {
                var employees = await connection.QueryAsync<Employee>(query);

                return employees.ToList();
            }
        }

        public async Task<Employee> GetEmployeesById(int id)
        {
            //var query = "SELECT * FROM Employee WHERE Id = @Id"; ---Alternative method
            var query = $"SELECT * FROM Employee WHERE Id = {id}";
            using (var connection = _context.CreateConnection())
            {
               //var employee = await connection.QueryFirstOrDefaultAsync<Employee>(query, new { id }); ---Alternative method
               var employee = await connection.QueryFirstOrDefaultAsync<Employee>(query);

                return employee;
            }
        }

        public async Task DeleteEmployeesById(int id)
        {
            var query = $"DELETE FROM Employee WHERE Id = {id}";
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query);
            }
        }

        public async Task UpdateEmployeeById(Employee updateRequest)
        {
            var query = $"UPDATE Employee SET " +
                $"FirstName ='{updateRequest.FirstName}', " +
                $"LastName = '{updateRequest.LastName}', " +
                $"Email = '{updateRequest.Email}', " +
                $"PhoneNumber = '{updateRequest.PhoneNumber}'," +
                $"HireDate = '{updateRequest.HireDate}', " +
                $"ProjectId='{updateRequest.ProjectId}'," +
                $"DepartmentId = '{updateRequest.DepartmentId}', " +
                $"Salary = '{updateRequest.Salary}' " +
                $"WHERE Id = '{updateRequest.Id}'";
            
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query);
            }
        }

        /*
        public async Task UpdateEmployeeById(Employee updateRequest)
        {
            var query = "UPDATE Employee SET " +
                "FirstName=@FirstName" +
                "LastName=@LastName" +
                "Email=@Email" +
                "PhoneNumber=@PhoneNumber" +
                "HireDate=@HireDate" +
                "ProjectId=@ProjectId" +
                "DepartmentId=@DepartmentId" +
                "Salary=@Salary" +
                "WHERE Id = @Id";

            var parameters = new DynamicParameters();
            parameters.Add("Id", updateRequest.Id, System.Data.DbType.Int32);
            parameters.Add("FirstName", updateRequest.FirstName, System.Data.DbType.String);
            parameters.Add("LastName", updateRequest.LastName, System.Data.DbType.String);
            parameters.Add("Email", updateRequest.Email, System.Data.DbType.String);
            parameters.Add("PhoneNumber", updateRequest.PhoneNumber, System.Data.DbType.String);
            parameters.Add("HireDate", updateRequest.HireDate, System.Data.DbType.DateTime);
            parameters.Add("ProjectId", updateRequest.ProjectId, System.Data.DbType.Int32);
            parameters.Add("DepartmentId", updateRequest.DepartmentId, System.Data.DbType.String);
            parameters.Add("Salary", updateRequest.Salary, System.Data.DbType.String);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        */
    }
    
}
