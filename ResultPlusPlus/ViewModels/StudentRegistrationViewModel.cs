using ResultPlusPlus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ResultPlusPlus.ViewModels
{
    public class StudentRegistrationViewModel
    {
        public int Id { get; set; }
        public Student student { get; set; }
        public IEnumerable<Class> Classes { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
    }
}