using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web_API_Demo_Dev_Day.Models
{
    public class Employee
    {
        /// <summary>
        /// Employee id
        /// </summary>
        [Key]
        public int ID { get; set; }

        /// <summary>
        /// Employee name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Employee date of birth
        /// </summary>
        public DateTime DateOfBirth { get; set; }
    }
}