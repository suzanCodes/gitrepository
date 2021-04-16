using ResultPlusPlus.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ResultPlusPlus.Data_Access
{
    public class DataContext:DbContext
    {
        public DataContext() : base("newtest") { }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> subjects { get; set; }
        public DbSet<Exam> exams { get; set; }
    }
}