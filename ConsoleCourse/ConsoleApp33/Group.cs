using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp33
{
    class Group
    {
        public string Name { get; set; }
        public List<Student> students = new List<Student>();
        public Group(string name)
        {
            Name = name;
        }
    }
}
