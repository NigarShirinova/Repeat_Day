using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace task1
{
    internal class GroupServices
    {
        ErrorMessages errors = new ErrorMessages();

        public void AddGroup(Course course)
        {
            Console.WriteLine("Enter group name and limit");
            string groupName = Console.ReadLine();
            string input = Console.ReadLine();

            bool isSucceeded = int.TryParse(input, out int limit);

            Group group = new Group(groupName, limit);


            if (isSucceeded)
            {
                if (!string.IsNullOrEmpty(groupName) && groupName.Length > 2)
                {
                    if (!course.Groups.Any(g => g.Name == groupName))
                    {
                        course.Groups.Add(group);
                        Console.WriteLine("Group added successfully.");
                    }
                    else
                    {
                        errors.SameGroupName();
                    }
                }
                else
                {
                    errors.WrongGroupName();
                }
            }
            else
            {
                Console.WriteLine("Invalid limit input.");
            }
        }

        public void ShowAllGroups(Course course)
        {
            foreach (Group group in course.Groups)
            {
                Console.WriteLine($"group name : {group.Name}, group limit : {group.Limit}");
            }
        }

        public void DeleteGroup(Course course)
        {
            Console.WriteLine("Enter group name ");
            string groupName = Console.ReadLine();


            if (course.Groups.Any(g => g.Name == groupName))
            {
                    foreach(var group in course.Groups)
                {
                    
                    if (group.Name == groupName)
                    {
                        course.Groups.Remove(group);
                    }
                }
                Console.WriteLine($"{groupName} deleted succesfully");

            }
            else
            {
                errors.DoesntContainGroup();
            }
        }

        public void UpdateGroup(Course course)
        {
            Console.WriteLine("Enter the name of Group you want to change");
            string groupName = Console.ReadLine();
            if (course.Groups.Any(g => g.Name == groupName))
            {
                for (int i = 0; i < course.Groups.Count(); i++)
                foreach(var group in course.Groups)
                {
                    if (group.Name == groupName)
                    {
                        Console.WriteLine("Which you want to change? Write 1 for name and 2 for limit");
                        string input = Console.ReadLine();
                        bool isSucceeded = int.TryParse(input, out int menuNumber);
                        if (isSucceeded)
                        {
                            switch (Convert.ToInt32(input))
                            {
                                case 1:
                                    Console.WriteLine("Enter the name for changing");
                                    string updateName = Console.ReadLine();
                                    if (!string.IsNullOrEmpty(updateName) && updateName.Length > 2)
                                    {
                                        if (!course.Groups.Any(g => g.Name == updateName))
                                        {
                                            group.Name = updateName;
                                            Console.WriteLine("Group updated successfully.");
                                        }
                                        else
                                        {
                                            errors.SameGroupName();
                                        }
                                    }
                                    else
                                    {
                                        errors.WrongGroupName();
                                    }
                                    break;
                                case 2:
                                    Console.WriteLine("Enter the limit for changing");
                                    string newLimit = Console.ReadLine();
                                    isSucceeded = int.TryParse(newLimit, out int updateLimit);
                                    if (isSucceeded)
                                    {
                                        group.Limit = updateLimit;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Type isn't correct");
                                    }
                                    break;
                                default:
                                    Console.WriteLine("You must write 1 or 2 please try again");
                                    break;

                            }
                        }
                    }

                }

            }
            else
            {
                errors.DoesntContainGroup();
            }
        }
    }
}

            
        

    



