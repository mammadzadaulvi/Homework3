using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp33
{
    class Course
    {
        public string Name { get; set; }
        public List<Group> groups = new List<Group>();
        public Course(string name)
        {
            Name = name;
        }
    }
}
