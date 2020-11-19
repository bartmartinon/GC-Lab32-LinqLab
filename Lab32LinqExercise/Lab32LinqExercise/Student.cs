using System;
using System.Collections.Generic;
using System.Text;

namespace Lab32LinqExercise
{
    class Student
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Student(string Name, int Age)
        {
            this.Name = Name;
            this.Age = Age;
        }
    }
}
