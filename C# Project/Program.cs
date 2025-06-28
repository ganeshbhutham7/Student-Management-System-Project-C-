using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace C__Project
{



    class Student
    {
     
        public int ID { get; set; }
        public string Name { get; set; }
    }

    class Program
    {
        static string connectionString = @"Server=GANESH;Database=StudentDB;Trusted_Connection=True;";


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

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO Students (ID, Name) VALUES (@ID, @Name)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@Name", name);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }

                Console.WriteLine("Student added Succesfully.");
        }

        static void ViewStudents()
        {
            
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM Students";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    Console.WriteLine("\nList of Students:");
                    while (reader.Read())
                    {
                        Console.WriteLine($"ID: {reader["ID"]}, Name: {reader["Name"]}");
                    }

                    reader.Close();
                    conn.Close();
                }

        }

        static void SearchStudent()
        {
            
                Console.Write("Enter ID to search: ");
                int id = Convert.ToInt32(Console.ReadLine());

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM Students WHERE ID = @ID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ID", id);

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        Console.WriteLine($"Found: ID = {reader["ID"]}, Name = {reader["Name"]}");
                    }
                    else
                    {
                        Console.WriteLine("Student not found!");
                    }

                    reader.Close();
                    conn.Close();
                }

        }

        static void DeleteStudent()
        {
           
                Console.Write("Enter ID to delete: ");
                int id = Convert.ToInt32(Console.ReadLine());

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM Students WHERE ID = @ID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ID", id);

                    conn.Open();
                    int rows = cmd.ExecuteNonQuery();
                    conn.Close();

                    if (rows > 0)
                        Console.WriteLine("Student deleted.");
                    else
                        Console.WriteLine("Student not found!");
                }

        }
    }


}
