using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lab1.Models
{
    public class Student
    {
        [Key()]
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        [Range(1, 10, ErrorMessage = "The average should be between 1 and 10.")]
        public float Average { get; set; }

        public DateTime Birthday { get; set; }

        [RegularExpression("^(M|F)$", ErrorMessage = "The gender should be either M (male) or F (female).")]
        public char Gender { get; set; }
    }
}
