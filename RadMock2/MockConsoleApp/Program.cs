using MockConsoleApp.Data;
using MockLibrary.Models;

class Program
{
    static void Main(string[] args)
    {
        List_All_Students();
        Console.WriteLine("\n----------------\n");

        List_Grades_Under_60();
        Console.WriteLine("\n----------------\n");

        List_Student_FName_LName_SubjectTitle_GradeOver60();
        Console.WriteLine("\n----------------\n");

        Add_New_Student_And_Grades();
        Console.WriteLine("New student added!");

        static void List_All_Students()
        {
            using (var context = new FE23())
            {
                var students = context.Students.ToList();
                foreach (var student in students)
                {
                    Console.WriteLine($"Student ID: {student.StudentID}, Name: {student.FirstName} {student.LastName}, Date of Birth: {student.DateOfBirth}");
                }
            }
        }

        static void List_Grades_Under_60()
        {
            using (var context = new FE23())
            {
                var grades = context.Grades.Where(g => g.Grade < 60).ToList();
                foreach (var grade in grades)
                {
                    Console.WriteLine($"Student ID: {grade.StudentID}, Subject: {grade.SubjectTitle}, Grade: {grade.Grade}");
                }
            }
        }

        static void List_Student_FName_LName_SubjectTitle_GradeOver60()
        {
            using (var context = new FE23())
            {
                var students = context.Students.ToList();
                foreach (var student in students)
                {
                    var grades = context.Grades.Where(g => g.StudentID == student.StudentID && g.Grade > 60).ToList();
                    foreach (var grade in grades)
                    {
                        Console.WriteLine($"Student ID: {student.StudentID}, Name: {student.FirstName} {student.LastName}, Subject: {grade.SubjectTitle}, Grade: {grade.Grade}");
                    }
                }
            }
        }

        static void Add_New_Student_And_Grades()
        {
            using (var context = new FE23())
            {
                var student = new Students
                {
                    StudentID = "S00000004",
                    FirstName = "John",
                    LastName = "Doe",
                    DateOfBirth = new DateTime(2000, 01, 01)
                };
                context.Students.Add(student);
                var grade1 = new Grades
                {
                    SubjectTitle = "Rich Application Development 1",
                    Grade = 55,
                    DateEntered = new DateTime(2024, 12, 10),
                    StudentID = "S00000001"
                };
                context.Grades.Add(grade1);
                var grade2 = new Grades
                {
                    SubjectTitle = "DataBase Systems 2",
                    Grade = 70,
                    DateEntered = new DateTime(2024, 12, 10),
                    StudentID = "S00000001"
                };
                context.Grades.Add(grade2);
                context.SaveChanges();
            }
        }
    }
}