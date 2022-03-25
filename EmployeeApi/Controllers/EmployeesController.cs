using EmployeeApi.Daos;
using EmployeeApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeApi.Controllers
{
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly EmployeeDao _employeeDao;
        public EmployeesController(EmployeeDao employeeDao)
        {
            _employeeDao = employeeDao;
        }

        [HttpGet]
        [Route("employees")]
        public async Task<IActionResult> GetEmployees()
        {
            try
            {
                var employees = await _employeeDao.GetEmployees();
                return Ok(employees);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        [Route("employee/{id}")]
        public async Task<IActionResult> GetEmployeeById([FromRoute] int id)
        {
            try
            {
                var employee = await _employeeDao.GetEmployeesById(id);
                if (employee == null)
                {
                    return StatusCode(404);
                }
                return Ok(employee);

            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete]
        [Route("employees/{id}")]
        public async Task<IActionResult> DeleteEmployeeById([FromRoute] int id)
        {
            try
            {
                var employee = GetEmployeeById(id);
                if (employee == null)
                {
                    return StatusCode(404);
                }

                await _employeeDao.DeleteEmployeesById(id);
                return StatusCode(200);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut]
        [Route("employees")]
        public async Task<IActionResult> UpdateEmployeeById([FromBody] Employee updateRequest)
        {
            try
            {
                var employee = await _employeeDao.GetEmployeesById(updateRequest.Id);
                if (employee == null)
                {
                    return StatusCode(404);
                }

                await _employeeDao.UpdateEmployeeById(updateRequest);
                return StatusCode(204);

            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }            
        }
    }
}
