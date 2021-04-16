using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ResultPlusPlus.Models
{
    public class Marks
    {
        public int Id { get; set; }
        [ForeignKey(nameof(Student))]
        public int StudentId { get; set; }
        [ForeignKey(nameof(Exam))]
        public int ExamId { get; set; }
        [ForeignKey(nameof(subject))]
        public int SubjectId { get; set; }
        public double TotalMarks{ get; set; }
        public  Student Student { get; set; }
        public Exam Exam { get; set; }
        public Subject subject { get; set; }
    }
}