using System;
using System.Collections.Generic;

namespace ConsoleApp34
{
    class Program
    {
        static void Main(string[] args)
        {
            Library library = new Library("P323");

            while (true)
            {
                START:
                Helper.Print("1. Kitabxanaya isci elave et;", ConsoleColor.Yellow);
                Helper.Print("2. Muellif elave et", ConsoleColor.Yellow);
                Helper.Print("3. Kitabxanaya kitab elave et", ConsoleColor.Yellow);
                Helper.Print("4. Kitabxanadan isci sil (id-e gore)", ConsoleColor.Yellow);
                Helper.Print("5. Kitabxanadan kitab sil (id-e gore)", ConsoleColor.Yellow);

                string answer = Console.ReadLine();
                bool isInt = int.TryParse(answer, out int con);

                if (!isInt)
                {
                    Console.WriteLine("Please write correctly");
                    goto START;
                }

                switch (con)
                {
                    case 1:

                        Helper.Print("Enter employee name: ", ConsoleColor.Yellow);
                        string stremployeename = Console.ReadLine();

                        Helper.Print("Enter employee surname: ", ConsoleColor.Yellow);
                        string stremployeesurname = Console.ReadLine();

                    EMPLOYEEAGE:

                        Helper.Print("Enter employee age: ", ConsoleColor.Yellow);
                        string stremployeeage = Console.ReadLine();
                        
                        bool isAge = int.TryParse(stremployeeage, out int age);
                        if (!isAge)
                        {
                            Console.WriteLine("Please enter correctly");
                            goto EMPLOYEEAGE;
                        }


                        Employee newemployee = new Employee(stremployeename, stremployeesurname, age);
                        library.employees.Add(newemployee);
                        Helper.Print("Employee has been added", ConsoleColor.Green);

                        break;



                    case 2:

                        Helper.Print("Enter Author name: ", ConsoleColor.Yellow);
                        string strauthorname = Console.ReadLine();

                        Helper.Print("Enter Author surname: ", ConsoleColor.Yellow);
                        string strauthorsurname = Console.ReadLine();

                        AUTHORAGE:
                        Helper.Print("Enter Author age: ", ConsoleColor.Yellow);
                        string strauthorage = Console.ReadLine();

                        bool isAuthorAge = int.TryParse(strauthorage, out int Aage);
                        if (!isAuthorAge)
                        {
                            Console.WriteLine("Please enter correctly");
                            goto AUTHORAGE;
                        }

                        Author newauthor = new Author(strauthorname, strauthorsurname, Aage);
                        library.authors.Add(newauthor);
                        Helper.Print("Author has been added", ConsoleColor.Green);

                        break;


                    case 3:

                        Helper.Print("Enter Book name: ", ConsoleColor.Yellow);
                        string strbookname = Console.ReadLine();

                        BOOKYEAR:

                        Helper.Print("Enter Book release year: ", ConsoleColor.Yellow);
                        string strbookyear = Console.ReadLine();

                        bool isBookYear = int.TryParse(strbookyear, out int Bage);
                        if (!isBookYear)
                        {
                            Console.WriteLine("Please enter correct year");
                            goto BOOKYEAR;
                        }

                        Book book = new Book(strbookname, Bage);

                        foreach (var item in library.authors)
                        {
                            Console.WriteLine($"ID: {item.Id}  Name: {item.Name}");
                        }

                    CHOOSEBOOK:

                        Console.WriteLine("Choose authors(Enter ID))");
                        string checkId = Console.ReadLine();
                        string[] ids = checkId.Split(",");
                        foreach (var item in ids)
                        {
                            bool isChoosen = int.TryParse(item, out int trueId);
                            
                            if (!isChoosen)
                            {
                                Console.WriteLine("Please enter correctly");
                                goto CHOOSEBOOK;
                            }

                            foreach (var item1 in library.authors)
                            {
                                if (item1.Id == trueId)
                                {
                                    book.authors.Add(item1);
                                    item1.books.Add(book);
                                }
                            }
                        }
                        library.books.Add(book);
                        Console.WriteLine($"The book has been added to the library");

                        break;


                    case 4:
                        
                        Helper.Print("Which employee do you want to delete (Enter id)", ConsoleColor.Yellow);
                        string strdeleteemp = Console.ReadLine();
                        bool isEmpid = int.TryParse(strdeleteemp, out int empId);

                        foreach (var item in library.employees)
                        {
                            Console.WriteLine($"ID: {item.Id}  Name: {item.Name}");
                        }

                        if (!isEmpid)
                        {
                            Helper.Print("Please enter correct id", ConsoleColor.Red);
                            goto case 4;
                        }

                        foreach (var item in library.employees)
                        {
                            if (item.Id == empId)
                            {
                                library.employees.Remove(item);
                                Helper.Print("The employee has been removed", ConsoleColor.Green);
                                break;
                            }
                        }

                        break;



                    case 5:

                        Helper.Print("Which book do you want to delete (Enter id)", ConsoleColor.Yellow);
                        string strdeletebook = Console.ReadLine();
                        bool isBookid = int.TryParse(strdeletebook, out int bookId);

                        foreach (var item in library.books)
                        {
                            Console.WriteLine($"ID: {item.Id}  Name: {item.Name}");
                        }

                        if (!isBookid)
                        {
                            Helper.Print("Please enter correct id", ConsoleColor.Red);
                            goto case 5;
                        }

                        foreach (var item in library.books)
                        {
                            if (item.Id == bookId)
                            {
                                library.books.Remove(item);
                                Helper.Print("The book has been removed", ConsoleColor.Green);
                                break;
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
