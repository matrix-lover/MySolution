using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LibraryApp.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string FullName { get; set; }

        public List<ExamResult> ExamResults { get; set; }
    }
}