using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinqPractice
{
    public class DistincStd
    {
        
        public int ID { get; set; }
        public string Name { get; set; } = string.Empty;
        public static List<DistincStd> GetStudents()
        {
            List<DistincStd> students = new List<DistincStd>()
            {
                new DistincStd {ID = 101, Name = "Preety" },
                new DistincStd {ID = 102, Name = "Sambit" },
                new DistincStd {ID = 103, Name = "Hina"},
                new DistincStd {ID = 104, Name = "Anurag"},
                new DistincStd {ID = 102, Name = "Sambit"},
                new DistincStd {ID = 103, Name = "Hina"},
                new DistincStd {ID = 101, Name = "Preety" },
            };
            return students;
        }
    }
}