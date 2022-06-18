using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp34
{
    class Book
    {
        public string Name { get; set; }
        public int Year { get; set; }
        public int Id { get; set; }
        private static int _id;
        public List<Author> authors = new List<Author>();
        public Book()
        {

        }
        public Book(string name, int year) : this()
        {
            Name = name;
            Year = year;
            Id = ++_id;
        }
    }
}
