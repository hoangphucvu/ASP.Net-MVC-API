using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;
using System.Web;

namespace KMS.EmployeeManagement.Models
{
    public class Employee
    {
        /// <summary>
        /// Increment id
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// Employee First name(required)
        /// </summary>
        [Required(ErrorMessage ="Firstname is required")]
        [Display(Name = "First Name: ")]
        public string FirstName { get; set; }
        /// <summary>
        /// Employee Middle name(optional)
        /// </summary>
        [Display(Name = "Middle Name: ")]
        public string MiddleName { get; set; }
        /// <summary>
        /// Employee Last name(required)
        /// </summary>
        [Required(ErrorMessage = "Lastname is required")]
        [Display(Name = "Last Name: ")]
        public string LastName { get; set; }
        /// <summary>
        /// Employee Birthdate(required)
        /// </summary>
        [Required(ErrorMessage = "Date of brith is required")]
        [Display(Name = "Date of Brith: ")]
        [Column(TypeName = "Date")]
        public DateTime DOB { get; set; }
        /// <summary>
        /// Employee Gender(required)
        /// </summary>
        [Required]
        [Display(Name = "Gender: ")]
        public bool Gender { get; set; }
        /// <summary>
        /// Employee Start Working date(required)
        /// </summary>
        [Required(ErrorMessage = "Start date is required")]
        [MiminumAge]
        [Display(Name = "Start Date: ")]
        [Column(TypeName = "Date")]
        public DateTime StartDate { get; set; }

        /// <summary>
        /// convert date of brith and start working date 
        /// </summary>
        public string StartDateShort
        {
            get { return StartDate.ToShortDateString(); }
        }
        public string BirthDayShort
        {
            get { return DOB.ToShortDateString(); }
        }
    }

}