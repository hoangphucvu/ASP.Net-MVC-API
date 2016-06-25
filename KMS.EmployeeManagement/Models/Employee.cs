using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KMS.EmployeeManagement.Models
{
    public class Employee
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }

        [Column(TypeName = "Date")]
        public DateTime DOB { get; set; }
        public bool Gender { get; set; }

        [Column(TypeName = "Date")]
        public DateTime StartDate { get; set; }
    }
}