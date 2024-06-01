using System;
using task1;

class Program
{
    public static void Main(string[] args)
    {
        Course course = new Course("Code Academy");
        GroupServices groupServices = new GroupServices();
        StudentServices studentServices = new StudentServices();
        bool flag = true;
        while (flag)
        {
            Console.WriteLine("-- MENU --");
            Console.WriteLine("1)Add Group"); //+
            Console.WriteLine("2)Show All Groups"); //+
            Console.WriteLine("3)Delete Group");// +
            Console.WriteLine("4)Update Group");
            Console.WriteLine("5)Add Student to the Group"); 
            Console.WriteLine("6)Show All Students in Group");
            Console.WriteLine("7)Search Student");
            Console.WriteLine("8)Update Student");
            Console.WriteLine("9)Delete Student From The Group");
            Console.WriteLine("10)Show All Students in Course");
            Console.WriteLine("0)Exit");
            Console.WriteLine("----Please choose one of this selections----");



            
            string input = Console.ReadLine();
            bool isSucceeded = int.TryParse(input, out int menuNumber);
            if (isSucceeded)
            {
                switch (menuNumber)
                {
                    case (int)Menu.AddGroup:
                        groupServices.AddGroup(course);
                        break;
                    case (int)Menu.ShowAllGroups:
                        groupServices.ShowAllGroups(course);
                        break;
                    case (int)Menu.DeleteGroup:
                        groupServices.DeleteGroup(course);
                        break;
                    case (int)Menu.UpdateGroup:
                        groupServices.UpdateGroup(course);
                        break;
                    case (int)Menu.AddStudent:
                        studentServices.AddStudent();
                        break;
                    case (int)Menu.DeleteStudent:
                        studentServices.RemoveStudent();
                        break;
                    case (int)Menu.UpdateStudent:
                        studentServices.EditStudentInGroup();
                        break;
                    case (int)Menu.ShowStudentsInGroup:
                        studentServices.ViewStudentsInGroup();
                        break;
                    case (int)Menu.ShowStudentsInCourse:
                        studentServices.ViewAllStudentsInCourse();
                        break;
                    case (int)Menu.Exit:
                        flag = false;
                        break;
                }
            }



        }
    }
}