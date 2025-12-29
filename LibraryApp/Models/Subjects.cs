using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LibraryApp.Models
{
    public class Subject
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<ExamResult> ExamResults { get; set; }
    }
}