using System;
using System.Collections.Generic;

namespace ConsoleApp33
{
    class Program
    {
        static void Main(string[] args)
        {
            Course course = new Course("CODE");

            while (true)
            {
            START:
                Helper.Print("1 - Qrup elave et ", ConsoleColor.Magenta);
                Helper.Print("2 - Qruplari gor", ConsoleColor.Magenta);
                Helper.Print("3 - Qrupa student elave et", ConsoleColor.Magenta);
                Helper.Print("4 - Studentleri gor", ConsoleColor.Magenta);
                Helper.Print("5 - Studentler uzre axtaris", ConsoleColor.Magenta);
                Helper.Print("6 - Qrupdan student sil", ConsoleColor.Magenta);
                Helper.Print("7 - Qrupdaki studenti editle", ConsoleColor.Magenta);

                string answer = Console.ReadLine();
                bool isInt = int.TryParse(answer, out int con);

                if (!isInt)
                {
                    Helper.Print("Please write again", ConsoleColor.Gray);
                    goto START;
                }

                switch (con)
                {
                    case 1:
                flag1:
                    
                    Helper.Print("Enter group name: ", ConsoleColor.Gray);
                    string strgroupname = Console.ReadLine();
                    
                    foreach (var item in course.groups)
                    {
                        if (item.Name == strgroupname)
                        {
                           Helper.Print("Please write again", ConsoleColor.Red);
                           goto flag1;
                        }
                    }

                    Group newgroup = new Group(strgroupname);
                    course.groups.Add(newgroup);
                    Helper.Print("Group has been created", ConsoleColor.Green);
                    
                    break;


                    case 2:

                        if (course.groups.Count == 0)
                        {
                            Helper.Print("Please create a group", ConsoleColor.Red);
                            goto START;
                        }
                        foreach (var elem in course.groups)
                        {
                            Helper.Print($"{elem.Name}", ConsoleColor.Green);
                        }
                        break;


                    case 3:

                        if (course.groups.Count == 0)
                        {
                            Helper.Print("Please create a group", ConsoleColor.Red);
                            goto START;
                        }

                CHOOSEGROUP:

                        Helper.Print("Choose a group", ConsoleColor.Gray);
                        Helper.Print("List of groups: ", ConsoleColor.Gray);

                        foreach (var item3 in course.groups)
                        {
                            Helper.Print(item3.Name, ConsoleColor.Green);
                        }

                        string strchoosengroup = Console.ReadLine();

                        foreach (var item in course.groups)
                        {
                            if (item.Name != strchoosengroup)
                            {
                                Helper.Print("Please choose right group name", ConsoleColor.Red);
                                goto CHOOSEGROUP;
                            }

                            else if (strchoosengroup == item.Name)
                            {
                                Helper.Print("Enter name: ", ConsoleColor.Gray);
                                string strName = Console.ReadLine();

                                Helper.Print("Enter surname: ", ConsoleColor.Gray);
                                string strSurname = Console.ReadLine();


                AGE:
                                Helper.Print("Enter age: ", ConsoleColor.Gray);
                                string strage = Console.ReadLine();
                                bool Isage = int.TryParse(strage, out int intage);

                                if (!Isage)
                                {
                                    Helper.Print("Please write again", ConsoleColor.Red);
                                    goto AGE;
                                }

                GRADE:
                                Helper.Print("Enter grade: ", ConsoleColor.Gray);
                                string strgrade = Console.ReadLine();
                                bool Isgrade = int.TryParse(strgrade, out int intgrade);
                                
                                if (!Isgrade && intage > 0 && intage < 100)
                                {
                                    Helper.Print("Please write again", ConsoleColor.Red);
                                    goto GRADE;
                                }

                                Student student = new Student(strName, strSurname, intage, intgrade);
                                item.students.Add(student);
                                Helper.Print("The student has been added to the group", ConsoleColor.Green);
                            }
                        }
                        break;

                    case 4:

                        if (course.groups.Count == 0)
                        {
                            Helper.Print("Please create a group ", ConsoleColor.Red);
                            goto START;
                        }
                        
                        foreach (var item4 in course.groups)
                        {
                            Helper.Print(item4.Name, ConsoleColor.Gray);
                        }
                        
                        Helper.Print("Which group students do you want to see ?", ConsoleColor.Gray);
                        string showstudents = Console.ReadLine();

                        foreach (var item in course.groups)
                        {
                            if (showstudents == item.Name)
                            {
                                if (item.students.Count == 0)
                                {
                                    Helper.Print("There is 0 student in this group", ConsoleColor.Red);
                                }

                                foreach (var itemstd in item.students)
                                {
                                    Helper.Print($" Name: {itemstd.Name}  Surname: {itemstd.Surname} Age: {itemstd.Age} Grade: {itemstd.Grade}", ConsoleColor.Green);
                                }
                            }
                        }
                        break;

                    case 5:

                        if (course.groups.Count == 0)
                        {
                            Helper.Print("Please create group", ConsoleColor.Red);
                            goto START;
                        }

                        Helper.Print("Search student: ", ConsoleColor.Gray);
                        string searchstudent = Console.ReadLine();

                        foreach (var item in course.groups)
                        {
                            foreach (var item5 in item.students)
                            {
                                if (item5.Name.ToUpper() == searchstudent.ToUpper())
                                {
                                    Helper.Print($"Name: {item5.Name}  Surname: {item5.Surname}", ConsoleColor.Gray);
                                }
                            }
                        }
                        break;


                    case 6:

                        if (course.groups.Count == 0)
                        {
                            Helper.Print("Please create group", ConsoleColor.Red);
                            goto START;
                        }

                        foreach (var item in course.groups)
                        {
                            Helper.Print($"{item.Name}", ConsoleColor.Gray);
                        }

                        Helper.Print("Which student do you want to delete? (Write group name of this student)", ConsoleColor.Gray);
                        string deletestudent = Console.ReadLine();
                        foreach (var item6 in course.groups)
                        {
                            if (item6.Name == deletestudent)
                            {
                                foreach (var elem6 in item6.students)
                                {
                                    Helper.Print($"Name:{elem6.Name}", ConsoleColor.Green);
                                }
                            }
                        }


                DeleteID:

                        Helper.Print("Enter ID which you want to delete", ConsoleColor.Gray);

                        string strdelete = Console.ReadLine();
                        bool boolid = int.TryParse(strdelete, out int id);

                        if (!boolid)
                        {
                            Helper.Print("Please enter correct id", ConsoleColor.Red);
                            goto DeleteID;
                        }

                        foreach (var delitem in course.groups)
                        {
                            foreach (var delelem in delitem.students)
                            {
                                if (delelem.Id == id)
                                {
                                    delitem.students.Remove(delelem);
                                    Helper.Print("The student has been deleted", ConsoleColor.Green);
                                    break;
                                }
                            }
                        }
                        break;

                    case 7:

                        if (course.groups.Count == 0)
                        {
                            Helper.Print("Please create group", ConsoleColor.Red);
                            goto START;
                        }

                        foreach (var item in course.groups)
                        {
                            Helper.Print($"{item.Name}", ConsoleColor.Gray);
                        }

                        Helper.Print("Which student do you edit ? (Write group name)", ConsoleColor.Gray);
                        string edit = Console.ReadLine();
                        foreach (var item7 in course.groups)
                        {
                            if (item7.Name == edit)
                            {
                                if (item7.students.Count == 0)
                                {
                                    Helper.Print("There is 0 student in this group, please add some students", ConsoleColor.Red);
                                    goto case 3;
                                }
                                else
                                {
                                    foreach (var elem in item7.students)
                                    {
                                        Helper.Print($"Name:{elem.Name}", ConsoleColor.Gray);
                                    }
                                }

                            }
                            else
                            {
                                Helper.Print("Please write correct group name", ConsoleColor.Red);
                                goto case 7;
                            }

                        }
                EDITID:
                        Helper.Print("Which student do you want to edit:(Write Id) ", ConsoleColor.Gray);
                        string strid = Console.ReadLine();
                        bool isID = int.TryParse(strid, out int ID);
                        
                        if (!isID)
                        {
                            Helper.Print("Please write again", ConsoleColor.Red);
                            goto EDITID;
                        }
                        
                        foreach (var item in course.groups)
                        {
                            foreach (var elem in item.students)
                            {
                                if (elem.Id == ID)
                                {
                                   
                                    Helper.Print("Enter new name", ConsoleColor.Gray);
                                    string newName = Console.ReadLine();
                                    elem.Name = newName;
                                   
                                    Helper.Print("Enter new surname", ConsoleColor.Gray);
                                    string newSurname = Console.ReadLine();
                                    elem.Surname = newSurname;
                                
                                AGE2:
                                   
                                    Helper.Print("Enter new age", ConsoleColor.Gray);
                                    string strAge = Console.ReadLine();
                                    bool boolAge = int.TryParse(strAge, out int age);
                                    if (!boolAge)
                                    {
                                        Helper.Print("Please write again", ConsoleColor.Red);
                                        goto AGE2;
                                    }
                                    elem.Age = age;
                                
                                GRADE2:
                                    
                                    Helper.Print("Enter new grade ", ConsoleColor.Gray);
                                    string strGrade = Console.ReadLine();
                                    bool boolGrade = int.TryParse(strGrade, out int grade);
                                    if (!boolGrade)
                                    {
                                        Helper.Print("Please write again", ConsoleColor.Red);
                                        goto GRADE2;
                                    }
                                    elem.Grade = grade;
                                    Helper.Print("Successful", ConsoleColor.Green);
                                    break;
                                }
                            }
                        }
                        break;

                    default:
                        break;
                }
            }
        }
    }
}

