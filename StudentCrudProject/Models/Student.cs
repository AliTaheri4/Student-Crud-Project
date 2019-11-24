using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentCrudProject.Models
{
    public class Student
    {

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Average { get; set; }
        public DateTime RegisterDate { get; set; }
        public int Age { get; set; }
        public bool Sex { get; set; }
    }
}
