﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeApi.Models
{
    public class Employee
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public DateTime HireDate { get; set; }
        [Required]
        public int ProjectId { get; set; }
        [Required]
        public int DepartmentId { get; set; }
        [Required]
        public string Salary { get; set; }
    }
}
