using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KMS.EmployeeManagement.Models
{
    public class Employee
    {
        public int ID { get; set; }
        [Display(Name = "First Name: ")]
        public string FirstName { get; set; }
        [Display(Name = "Middle Name: ")]
        public string MiddleName { get; set; }
        [Display(Name = "Last Name: ")]
        public string LastName { get; set; }
        [Display(Name = "Date of Brith: ")]
        [Column(TypeName = "Date")]
        public DateTime DOB { get; set; }
        [Display(Name = "Gender: ")]
        public bool Gender { get; set; }
        [Display(Name = "Start Date: ")]
        [Column(TypeName = "Date")]
        public DateTime StartDate { get; set; }

    }

}