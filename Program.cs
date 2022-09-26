using System;

namespace EntitySetOperationProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (AppContext app = new())
            {
                app.Database.EnsureDeleted();
                app.Database.EnsureCreated();

                List<Group> groups = new List<Group>();
                groups.Add(new Group() { Title = "PV121" });
                groups.Add(new Group() { Title = "SPD221" });
                app.Groups.AddRange(groups);

                List<Student> students = new List<Student>();
                students.Add(new Student() { Name = "Bob", Age = 23, Group = groups[0] });
                students.Add(new Student() { Name = "Tim", Age = 44, Group = groups[0] });
                students.Add(new Student() { Name = "Joe", Age = 31, Group = groups[1] });
                students.Add(new Student() { Name = "Sam", Age = 28, Group = groups[1] });
                students.Add(new Student() { Name = "Pit", Age = 36, Group = groups[1] });
                students.Add(new Student() { Name = "Tim", Age = 26, Group = groups[1] });
                app.Students.AddRange(students);

                app.SaveChanges();
            }

            using (AppContext app = new())
            {
                //var users30 = app.Students.Where(s => s.Age > 30)
                //                            .Union(app.Students.Where(s => s.Name == "Bob"));

                //var users30 = app.Students.Select(s => new { Name = s.Name })
                //                            .Union(app.Groups.Select(g => new { Name = g.Title }));

                //var users30 = app.Students.Where(s => s.Age > 30)
                //                .Intersect(app.Students.Where(s => s.Name == "Tim"));

                //var select1 = app.Students.Where(s => s.Age > 30)
                //              .Except(app.Students.Where(s => s.Name == "Tim"));


                //foreach (var user in select1)
                //    Console.WriteLine($"{user.Name} {user.Age}");

                var result1 = app.Students.Any(s => s.Group!.Title == "PV111");

                var result2 = app.Students.All(s => s.Age > 36);

                var result3 = app.Students.Count(s => s.Age > 30);

                var result4 = app.Students.Where(s => s.Group!.Title == "SPD221").Max(s => s.Age);

                var result5 = app.Students.Min(s => s.Age);

                var result6 = app.Students.Average(s => s.Age);

                var result7 = app.Students.Sum(s => s.Age);

                //Console.WriteLine(result2 ? "Yes" : "No");
                Console.WriteLine(result7);
            }



        }
    }
}