using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__Project
{
    using System;
    using System.Collections.Generic;

    class Student
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }

    class Program
    {
        static List<Student> students = new List<Student>();

        static void Main()
        {
            int choice;
            do
            {
                Console.WriteLine("\n--- Student Management System ---");
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. View All Students");
                Console.WriteLine("3. Search Student by ID");
                Console.WriteLine("4. Delete Student");
                Console.WriteLine("5. Exit");
                Console.Write("Choose an option: ");
                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AddStudent();
                        break;
                    case 2:
                        ViewStudents();
                        break;
                    case 3:
                        SearchStudent();
                        break;
                    case 4:
                        DeleteStudent();
                        break;
                    case 5:
                        Console.WriteLine("Exiting..."); break;
                    default:
                        Console.WriteLine("Invalid choice!");
                        break;
                }
            } while (choice != 5);
        }

        static void AddStudent()
        {
            Console.Write("Enter Student ID: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Student Name: ");
            string name = Console.ReadLine();

            students.Add(new Student { ID = id, Name = name });
            Console.WriteLine("Student added successfully!");
        }

        static void ViewStudents()
        {
            Console.WriteLine("\nList of Students:");
            foreach (var student in students)
            {
                Console.WriteLine($"ID: {student.ID}, Name: {student.Name}");
            }
        }

        static void SearchStudent()
        {
            Console.Write("Enter ID to search: ");
            int id = Convert.ToInt32(Console.ReadLine());
            var student = students.Find(s => s.ID == id);

            if (student != null)
                Console.WriteLine($"Found: ID = {student.ID}, Name = {student.Name}");
            else
                Console.WriteLine("Student not found!");
        }

        static void DeleteStudent()
        {
            Console.Write("Enter ID to delete: ");
            int id = Convert.ToInt32(Console.ReadLine());
            var student = students.Find(s => s.ID == id);

            if (student != null)
            {
                students.Remove(student);
                Console.WriteLine("Student deleted.");
            }
            else
            {
                Console.WriteLine("Student not found!");
            }
        }
    }


}
