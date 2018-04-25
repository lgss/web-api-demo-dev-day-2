using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web_API_Demo_Dev_Day.Models
{
    public class Employee
    {
        [Key]
        public int ID { get; set; }

        public string Name { get; set; }

        public DateTime DateOfBirth { get; set; }
    }
}