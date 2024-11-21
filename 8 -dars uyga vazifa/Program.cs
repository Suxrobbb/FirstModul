using _8__dars_uyga_vazifa.Models;
using _8__dars_uyga_vazifa.Services;

namespace _8__dars_uyga_vazifa
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RunFrontEnd();
        }
        public static void RunFrontEnd()
        {
            var studentServices = new StudentServices();

            while (true)
            {
                Console.WriteLine("1. Add student");
                Console.WriteLine("2. Update student");
                Console.WriteLine("3. Delete student");
                Console.WriteLine("4. Get student");
                Console.WriteLine("5. GetByID student");

                Console.Write("Enter choose: ");
                var option = int.Parse(Console.ReadLine());

                if (option == 1)
                {
                    var student = new Student();
                    Console.Write("First Name: ");
                    student.StudentName = Console.ReadLine();
                    Console.Write("Age: ");
                    student.StudentAge = int.Parse(Console.ReadLine());
                    Console.Write("Phone Number: ");
                    student.StudentPhoneNumber = Console.ReadLine();

                    studentServices.AddStudent(student);
                }
                else if (option == 2)
                {
                    var student = new Student();
                    Console.Write("Enter id to update: ");
                    student.StudentId = Guid.Parse(Console.ReadLine());
                    Console.Write("First Name: ");
                    student.StudentName = Console.ReadLine();

                    Console.Write("Age: ");
                    student.StudentAge = int.Parse(Console.ReadLine());
                    Console.Write("Phone Number: ");
                    student.StudentPhoneNumber = Console.ReadLine();

                    var result = studentServices.UpdateStudent(student);

                    if (result is true)
                    {
                        Console.WriteLine("Updated");
                    }
                    else
                    {
                        Console.WriteLine("Not updated");
                    }
                }
                else if (option == 3)
                {
                    Console.Write("Enter Id to delete: ");
                    var id = Guid.Parse(Console.ReadLine());
                    var requestDelete = studentServices.DeleteStudent(id);
                    if (requestDelete is true)
                    {
                        Console.WriteLine("Deleted");
                    }
                    else
                    {
                        Console.WriteLine("Not deleted");
                    }
                }
                else if (option == 4)
                {
                    var students = studentServices.GetAllStudents();
                    foreach (var student in students)
                    {
                        var info = $"Id: {student.StudentId}, First Name: {student.StudentName}, Age: {student.StudentAge}, Phone Number: {student.StudentPhoneNumber}";
                        Console.WriteLine($"{info}");
                    }
                }
                else if (option == 5)
                {
                    Console.Write("Enter id to getId: ");
                    var id = Guid.Parse(Console.ReadLine());
                    var student = studentServices.GetById(id);
                    var info = $"Id: {student.StudentId}, First Name: {student.StudentName}, Age: {student.StudentAge}, Phone Number: {student.StudentPhoneNumber}";
                    Console.WriteLine($"{info}");
                }

                Console.ReadLine();
                Console.Clear();
            }
        }
    }
}


