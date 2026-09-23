using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentManagement
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List<Student> students = new List<Student>();

            int choice;

            do
            {
                ProgramIntro();
                PrintMenu();
                choice = ReadMenuChoice();

                Console.WriteLine();

                switch (choice) 
                {
                    case 1: AddStudent(students); break;
                    case 2: ShowAllStudents(students); break;
                    case 3: SearchStudent(students); break;
                    case 4: UpdateStudent(students); break;
                    case 5: RemoveStudent(students); break;
                    case 6: ShowPassedStudents(students);break;
                    case 7: ShowFailedStudents(students); break;
                    case 8: ShowStatistics(students); break;
                    case 9: SortStudentsByGrade(students); break;
                    case 0: Console.WriteLine("Goodbye!"); break;
                }

                Console.WriteLine();

            } while (choice != 0);

            Console.ReadLine();
        }

        static void ProgramIntro()
        {
            Console.WriteLine("==================================================");
            Console.WriteLine("\tUNIVERSITY STUDENT MANAGEMENT SYSTEM");
            Console.WriteLine("==================================================");
        }

        static void PrintMenu()
        {
            Console.WriteLine();
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. Show All Students");
            Console.WriteLine("3. Search Student");
            Console.WriteLine("4. Update Student");
            Console.WriteLine("5. Remove Student");
            Console.WriteLine("6. Show Passed Students");
            Console.WriteLine("7. Show Failed Students");
            Console.WriteLine("8. Show Statistics");
            Console.WriteLine("9. Sort Students by Grade");
            Console.WriteLine("0. Exit");
            Console.WriteLine();
        }

        // Read Menu

        static int ReadMenuChoice ()
        {
            while (true)
            {
                Console.Write("Choose : ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out int choice) && choice >= 0 && choice <= 9)
                {
                    return choice;
                }

                Console.WriteLine("Enter Valid Input");
            }
        }
        
         //Add Student
        static void AddStudent(List<Student> students)
        {
            Console.WriteLine();
            Console.WriteLine("=========================Add Student=========================");
            Console.WriteLine();

            int id = ReadId(students);
            string name = ReadName();
            int age = ReadAge();
            double grade = ReadGrade();
            StudentStatus status = ReadStatus();

            Student student = new Student(id, name, age, grade, status);
            students.Add(student);
            Console.WriteLine("Student Added Successfully!");
        }

        static int ReadId(List<Student> students)
        {
            while (true)
            {
                Console.Write("Enter Student's Id : ");
                string input = Console.ReadLine();

                if (!int.TryParse(input, out int id) || id <= 0)
                {
                    Console.WriteLine("Enter Valid Input");
                    continue;
                }

                bool exists = students.Any(student => student.Id == id);

                if (exists)
                {
                    Console.WriteLine("Id Already Exists");
                    continue;
                }
                return id;

            }
        }


        static string ReadName()
            {
                while (true) 
                {
                    Console.Write("Enter Student's Name : ");
                    string input = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(input))
                    {
                        Console.WriteLine("Enter Valid Input");
                        continue;
                    }

                    return input;
                }
        }

        static int ReadAge()
        {
            while (true)
            {
                Console.Write("Enter Student's Age : ");
                string input = Console.ReadLine();

                if (!int.TryParse(input, out int age) || age <= 0)
                {
                    Console.WriteLine("Enter Valid Input");
                    continue;
                }

                return age;
            }
        }

        static double ReadGrade()
        {

            while (true)
            {
                Console.Write("Enter Student's Grade : ");
                string input = Console.ReadLine();

                if (!double.TryParse(input, out double grade) || grade < 0 || grade > 100)
                {
                    Console.WriteLine("Enter Valid Input");
                    continue;
                }

                return grade;
            }
        }

        static StudentStatus ReadStatus()
        {
            while (true)
            {
                Console.WriteLine("1. Active");
                Console.WriteLine("2. Graduated");
                Console.WriteLine("3. Suspended");
                Console.Write("Choose Status : ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out int status) && status > 0 && status < 4)
                {
                    switch (status)
                    {
                        case 1: return StudentStatus.Active;
                        case 2: return StudentStatus.Graduated;
                        case 3: return StudentStatus.Suspended;
                    }
                }

                Console.WriteLine("Enter 1,2 or 3");
            }
        }
        // Show All Students
        static void ShowAllStudents(List<Student> students)
        {
            if (students.Count == 0)
            {
                Console.WriteLine("No Students Found");
                return;
            }

            Console.WriteLine();
            Console.WriteLine("=========================Show All Students=========================");
            Console.WriteLine();

            foreach (Student student in students)
            {
                Console.WriteLine();
                student.PrintInfo();
                Console.WriteLine();
                Console.WriteLine("-------------------------------------------");
            }
        }


        // Search for Student

        static void SearchStudent(List<Student> students)
        {
            if (students.Count == 0)
            {
                Console.WriteLine("No Students Found");
                return;
            }

            Console.WriteLine();
            Console.WriteLine("=========================Search Student=========================");
            Console.WriteLine();
            int id = PositiveInteger("Enter Id : ");

            Student student = students.FirstOrDefault(studentX => studentX.Id == id);

            if (student != null)
            {
                student.PrintInfo();
            }
            else
            {
                Console.WriteLine("Student Not Found");
            }
        }

        // Update Student

        static void UpdateStudent(List<Student> students)
        {
            if (students.Count == 0)
            {
                Console.WriteLine("No Students Found");
                return;
            }

            Console.WriteLine();
            Console.WriteLine("=========================Update Student=========================");
            Console.WriteLine();

            int id = PositiveInteger("Enter Id : ");

            Student student = students.FirstOrDefault(studentX => studentX.Id == id);

            if (student == null)
            {
                Console.WriteLine("Student Not Found");
                return;

            }

            
            Console.WriteLine("Enter the New Informations");

            student.Name = ReadName();
            student.Age = ReadAge();
            student.Grade = ReadGrade();
            student.Status = ReadStatus();

            Console.WriteLine("Student Updated Successfully!");

        }

        // Remove Student

        static void RemoveStudent(List<Student> students)
        {
            if (students.Count == 0)
            {
                Console.WriteLine("No Students Found");
                return;
            }

            Console.WriteLine();
            Console.WriteLine("=========================Remove Student=========================");
            Console.WriteLine();

            int id = PositiveInteger("Enter Id : ");

            Student student = students.FirstOrDefault(studentX => studentX.Id == id);

            if (student == null)
            {
                Console.WriteLine("Student Not Found");
                return;
            }

            students.Remove(student);
            Console.WriteLine("Student Removed Successfully!");

        }

        // Show Passed Students

        static void ShowPassedStudents(List<Student> students)
        {
            Console.WriteLine();
            Console.WriteLine("=========================Passed Students=========================");
            Console.WriteLine();

            var passedStudents = students.Where(student => student.Grade >= 50);


            if (!passedStudents.Any())
            {
                Console.WriteLine("No Passed Students Found");
                return;
            }

            foreach (Student student in passedStudents)
            {
                student.PrintInfo();
                Console.WriteLine("------------------------------------");
            }

        }

        // Show Failed Students

        static void ShowFailedStudents(List<Student> students)
        {
            Console.WriteLine();
            Console.WriteLine("=========================Failed Students=========================");
            Console.WriteLine();

            var failedStudents = students.Where(student => student.Grade < 50);


            if (!failedStudents.Any())
            {
                Console.WriteLine("No Failed Students Found");
                return;
            }

            foreach (Student student in failedStudents)
            {
                student.PrintInfo();
                Console.WriteLine("------------------------------------");
            }

        }

        // Show Statistics

        static void ShowStatistics(List<Student> students)
        {
            if (students.Count == 0)
            {
                Console.WriteLine("No Students Found");
                return;
            }

            int total = students.Count;
            int passedStudents = students.Count(student => student.Grade >= 50);
            int failedStudents = students.Count(student => student.Grade < 50);
            double average = students.Average(student => student.Grade);
            double highest = students.Max(student => student.Grade);
            double lowest = students.Min(student => student.Grade);

            Console.WriteLine();
            Console.WriteLine("=========================STATISTICS=========================");
            Console.WriteLine();
            Console.WriteLine($"Total Students : {total}");
            Console.WriteLine($"Passed Students : {passedStudents}");
            Console.WriteLine($"Failed Students : {failedStudents}");
            Console.WriteLine($"Average Grade : {average:F2}");
            Console.WriteLine($"Highest Grade : {highest}");
            Console.WriteLine($"Lowest Grade : {lowest}");
        
        }


        // Sorting
        static void SortStudentsByGrade(List<Student> students)
        {
            if (students.Count == 0)
            {
                Console.WriteLine("No Students Found");
                return;
            }

            var sort = students.OrderByDescending(student => student.Grade);

            Console.WriteLine();
            Console.WriteLine("=========================Highest To Lowest=========================");
            Console.WriteLine();

            foreach (Student student in sort)
            {
                student.PrintInfo();
                Console.WriteLine("---------------------------------");
            }
        }

        // Positive Integer (Helper)
        static int PositiveInteger(string message)
        {
            while (true)
            {
                Console.Write(message);
                string input = Console.ReadLine();

                if (int.TryParse(input, out int number) && number > 0)
                {
                    return number;
                }

                Console.WriteLine("Enter Valid Input");

            }
        }


        // Student Class
        class Student
        {
            public int Id { get; private set; }
            public string Name { get; set; }
            public int Age { get; set; }
            public double Grade { get; set; }
            public StudentStatus Status { get; set; }


            public Student(int id, string name, int age, double grade, StudentStatus status)
            {
                Id = id;
                Name = name;
                Age = age;
                Grade = grade;
                Status = status;
            }


            public void PrintInfo()
            {
                Console.WriteLine($"Id : {Id}");
                Console.WriteLine($"Name : {Name}");
                Console.WriteLine($"Age : {Age}");
                Console.WriteLine($"Grade : {Grade}");
                Console.WriteLine($"Status : {Status}");
            }
        }

        // Enum
        enum StudentStatus
        {
            Active,
            Graduated,
            Suspended
        }
        

        
    }


}