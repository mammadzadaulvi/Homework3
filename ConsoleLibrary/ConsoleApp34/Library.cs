using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp34
{
    class Library
    {
        public string Name { get; set; }
        public List<Employee> employees = new List<Employee>();
        public List<Book> books = new List<Book>();
        public List<Author> authors = new List<Author>();

        public Library(string name)
        {
            Name = name;
        }
    }
}
