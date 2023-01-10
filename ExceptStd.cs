using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinqPractice
{
    public class ExceptStd
    {

        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

        public static List<Student> ExceptStudents()
        {
            List<Student> exstudents = new List<Student>
           {
            new Student {Id = 1,FirstName="Olarewaju",LastName="Muhammed"},
            new Student {Id=2,FirstName="Oboh",LastName="Effiong"},
            new Student {Id=3,FirstName="Precious",LastName="Chimdi"},

        };
        return  exstudents;
        }
    }
}