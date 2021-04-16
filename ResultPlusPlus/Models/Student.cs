using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ResultPlusPlus.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public string Class { get; set; }

        public string Email { get; set; }

        public Nullable<System.DateTime> DOB { get; set; }
        public int Rollno { get; set; }
         
       
       
    }
}