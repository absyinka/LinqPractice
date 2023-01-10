namespace LinqPractice
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

        public static List<Student> GetStudents()
        {
           List<Student> students = new List<Student>
           {
            new Student {Id = 1,FirstName="Olarewaju",LastName="Muhammed"},
            new Student {Id=2,FirstName="Oboh",LastName="Effiong"},
            new Student {Id=3,FirstName="Precious",LastName="Chimdi"},
            new Student {Id=4,FirstName="Olayemi",LastName="Haleemah"},
            new Student {Id=5,FirstName="Olalekan",LastName="AbdulRaheem"},
           };
           return students;
        }
    }
}