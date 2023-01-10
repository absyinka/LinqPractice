using System;


namespace LinqPractice
{
    class Program
    {
        static void Main()
        {
            var Query = (from std in Student.GetStudents()
                         select new
                         {
                             Id = std.Id,
                             FirstName = std.FirstName,
                             LastName = std.LastName
                         });

            foreach (var std in Query)
            {
                Console.WriteLine($" Id: {std.Id} Name : {std.FirstName} {std.LastName} ");
            }
            var Exquery = (from std in Student.GetStudents()
                           select new { std.Id, std.FirstName, std.LastName }).Except(ExceptStd.ExceptStudents().Select(y => new { y.Id, y.FirstName, y.LastName }));
            Console.WriteLine("--------Not in the second datasource------------");
            foreach (var item in Exquery)
            {
                Console.WriteLine($" Id = {item.Id},FulName = {item.FirstName} {item.LastName}");
            }
            var Intquery = (from std in Student.GetStudents()
                            select new { std.FirstName, std.LastName }).Intersect(IntStd.IntStudents().Select(x => new { x.FirstName, x.LastName }));
            Console.WriteLine("--------In both datasource------------");
            foreach (var item in Intquery)
            {
                Console.WriteLine($"FulName = {item.FirstName} {item.LastName}");
            }
            var Orderquery = (from std in Student.GetStudents()
                              orderby std.LastName ascending
                              select std);
            Console.WriteLine("------------Order By Ascending-------------");

            foreach (var item in Orderquery)
            {
                Console.WriteLine($" Id = {item.Id},FulName = {item.FirstName} {item.LastName}");
            }
            var anotherall = (from stdi in StudentInfo.GetAllStudnets()
                              select stdi).All(x => x.TotalMarks > 250);


            var allquery = (from stdi in StudentInfo.GetAllStudnets()
                            where stdi.Subjects.All(x => x.Marks > 70)
                            select stdi);
            Console.WriteLine("-------------AllQuery-----------------");
            foreach (var item in allquery)
            {
                Console.WriteLine($"Name = {item.Name} Marks = {item.TotalMarks}");
            }
            var anyquery = (from stdi in StudentInfo.GetAllStudnets()
                            where stdi.Subjects.Any(x => x.Marks > 70)
                            select stdi);

            foreach (var item in anyquery)
            {
                Console.WriteLine($"Name = {item.Name}: Marks = {item.TotalMarks}");
            }
            var distinquery = (from diststd in DistincStd.GetStudents()
                               select new { diststd.ID, diststd.Name }).Distinct().Select(y => new { y.ID, y.Name });
            Console.WriteLine("-------------------------Distinc student----------------------");
            foreach (var item in distinquery)
            {
                Console.WriteLine($"Id = {item.ID}, Name = {item.Name} ");
            }
            var innerjoinquery = (from work in Workers.GetAllWorkers()
                                  join add in Address.GetAllAddresses() on work.AddressId equals add.ID
                                  join dept in Department.GetAllDepartments() on work.DepartmentId equals dept.ID
                                  select new { Name = work.Name, AddressLine = add.AddressLine, Department = dept.Name });
            Console.WriteLine("---------------InnerJoin----------------");
            foreach (var item in innerjoinquery)
            {
                Console.WriteLine($"Name = {item.Name}, AddressLine = {item.AddressLine} Department ={item.Department}");
            }
            var sequencequery = (from std in Student.GetStudents()
                                 select new { std.FirstName, std.LastName }).SequenceEqual(ExceptStd.ExceptStudents().Select(y => new { y.FirstName, y.LastName }));
            Console.WriteLine(sequencequery);
            var leftjoin = (from work in Workers.GetAllWorkers()
                            join add in Address.GetAllAddresses() on work.AddressId equals add.ID into EmployeeAddress
                            from address in EmployeeAddress.DefaultIfEmpty()
                            select new { Name = work.Name, AddressLine = address == null ? "NA" : address.AddressLine });
            foreach (var item in leftjoin)
            {
                Console.WriteLine($"Name = {item.Name}, Address = {item.AddressLine}");
            }
            var intersectquery = (from std in Student.GetStudents()
                                  select new { std.Id, std.FirstName }).Intersect(IntStd.IntStudents().Select(y => new { y.Id, y.FirstName }));
            foreach (var item in intersectquery)
            {
                Console.WriteLine("Id = " + item.Id + ", Name = " + item.FirstName);
            }

            var anotherallquery = (from std in Student.GetStudents() select std).Any(y => y.Id == 5);

            Console.WriteLine(anotherallquery);
            List<int> lisint = new List<int>
            {1,2,3,4,5,6,7,8,9};
            var takequery = (from num in lisint
                             where num<3 select num).Take(4);

            foreach (var item in takequery)
            {
          Console.WriteLine(item);
            }



        }

    }
}