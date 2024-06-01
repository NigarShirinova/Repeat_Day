using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace task1
{
    internal class StudentServices
    {
        ErrorMessages errors = new ErrorMessages();
        Course course;
            public void AddStudent()
            {
                Console.WriteLine("Write the group name which you want to add a student to:");
                string groupName = Console.ReadLine();
                var existGroup = course.Groups.FirstOrDefault(g => g.Name == groupName);

                if (existGroup == null)
                {
                    Console.WriteLine("Group not found.");
                    return;
                }

                if (existGroup.Students.Count >= existGroup.Limit)
                {
                    Console.WriteLine("Group is full.");
                    return;
                }

                Console.WriteLine("Write Student's Name:");
                string studentName = Console.ReadLine();

                Console.WriteLine("Write Student's Surname:");
                string studentSurname = Console.ReadLine();

                Console.WriteLine("Write Student's Age:");
                if (!int.TryParse(Console.ReadLine(), out int studentAge))
                {
                    Console.WriteLine("Invalid age.");
                    return;
                }

                Console.WriteLine("Write Student's Grade:");
                if (!double.TryParse(Console.ReadLine(), out double studentGrade))
                {
                    Console.WriteLine("Invalid grade.");
                    return;
                }

                var newStudent = new Student(studentName, studentSurname, studentAge, studentGrade);
                

                existGroup.Students.Add(newStudent);
                Console.WriteLine("Student added to the group.");
            }





        

        public void RemoveStudent()
        {
            Console.WriteLine("Write the group name from which you want to remove a student:");
            string groupName = Console.ReadLine();
            Group groupp = course.Groups.FirstOrDefault(g => g.Name == groupName);

            if (groupp == null)
            {
                Console.WriteLine("Group not found.");
                return;
            }

            if (groupp.Students.Count == 0)
            {
                Console.WriteLine("No students in the group.");
                return;
            }

            foreach (var student in groupp.Students)
            {
                Console.WriteLine($"Id: {student.Id}, Name: {student.Name}");
            }

            Console.WriteLine("Enter the student ID to remove:");
            if (!int.TryParse(Console.ReadLine(), out int studentId))
            {
                Console.WriteLine("Invalid ID.");
                return;
            }

            var studentToRemove = groupp.Students.FirstOrDefault(s => s.Id == studentId);
            if (studentToRemove == null)
            {
                Console.WriteLine("Student not found.");
                return;
            }

            groupp.Students.Remove(studentToRemove);
            Console.WriteLine("Student removed from the group.");
        }


        public void EditStudentInGroup()
        {
            Console.WriteLine("Write the group name in which you want to edit a student:");
            string groupName = Console.ReadLine();
            var group = course.Groups.FirstOrDefault(g => g.Name == groupName);

            if (group == null)
            {
                Console.WriteLine("Group not found.");
                return;
            }

            if (group.Students.Count == 0)
            {
                Console.WriteLine("No students in the group.");
                return;
            }

            foreach (var student in group.Students)
            {
                Console.WriteLine($"Id: {student.Id}, Name: {student.Name}");
            }

            Console.WriteLine("Enter the student ID to edit:");
            if (!int.TryParse(Console.ReadLine(), out int studentId))
            {
                Console.WriteLine("Invalid ID.");
                return;
            }

            var studentToEdit = group.Students.FirstOrDefault(s => s.Id == studentId);
            if (studentToEdit == null)
            {
                Console.WriteLine("Student not found.");
                return;
            }

            Console.WriteLine("Write new Student's Name:");
            studentToEdit.Name = Console.ReadLine();

            Console.WriteLine("Write new Student's Surname:");
            studentToEdit.SurName = Console.ReadLine();

            Console.WriteLine("Write new Student's Age:");
            if (!int.TryParse(Console.ReadLine(), out int newAge))
            {
                Console.WriteLine("Invalid age.");
                return;
            }
            studentToEdit.Age = newAge;

            Console.WriteLine("Write new Student's Grade:");
            if (!double.TryParse(Console.ReadLine(), out double newGrade))
            {
                Console.WriteLine("Invalid grade.");
                return;
            }
            studentToEdit.Grade = newGrade;

            Console.WriteLine("Student information updated.");
        }

        public void ViewStudentsInGroup()
        {
            Console.WriteLine("Write the group name to view its students:");
            string groupName = Console.ReadLine();
            var group = course.Groups.FirstOrDefault(g => g.Name == groupName);

            if (group == null)
            {
                Console.WriteLine("Group not found.");
                return;
            }

            if (group.Students.Count == 0)
            {
                Console.WriteLine("No students in the group.");
                return;
            }

            foreach (var student in group.Students)
            {
                Console.WriteLine($"Id: {student.Id}, Name: {student.Name}, Surname: {student.SurName}, Age: {student.Age}, Grade: {student.Grade}");
            }
        }

        public void ViewAllStudentsInCourse()
        {
            var allStudents = course.Groups.SelectMany(g => g.Students).ToList();

            if (allStudents.Count == 0)
            {
                Console.WriteLine("No students in the course.");
                return;
            }

            foreach (var student in allStudents)
            {
                Console.WriteLine($"Id: {student.Id}, Name: {student.Name}, Surname: {student.SurName}, Age: {student.Age}, Grade: {student.Grade}");
            }
        }

        public void SearchStudents()
        {
            Console.WriteLine("Enter the string to search for in student names:");
            string searchString = Console.ReadLine();

            var foundStudents = course.Groups.SelectMany(g => g.Students)
                                              .Where(s => s.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                                              .ToList();

            if (foundStudents.Count == 0)
            {
                Console.WriteLine("No students found matching the search criteria.");
                return;
            }

            foreach (var student in foundStudents)
            {
                Console.WriteLine($"Id: {student.Id}, Name: {student.Name}, Surname: {student.SurName}, Age: {student.Age}, Grade: {student.Grade}");
            }
        }


    }
}
