using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{
    public class Student : IComparable<Student>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Test { get; set; }
        public DateTime Date { get; set; }
        public int mark;
        public int Mark
        {
            get { return this.mark;  }

            set
            {
                if (value < 0 || value > 100)
                    throw new ArgumentException("Mark has uncorrect value");
                    this.mark = value;
            }
        }

        public Student() { }

        public Student(string Name, string Surname, string Test, DateTime Date, int Mark)
        {
            this.Name = Name;
            this.Surname = Surname;
            this.Test = Test;
            this.Date = Date;
            this.Mark = Mark;
        }

        public override string ToString()
        {
            return Surname + " " + Name + " " + ":" + Mark.ToString();
        }

        public int CompareTo(Student other)
        {
            if (Mark == other.Mark)
            {
                return 0;
            }
            else if (Mark > other.Mark)
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }
    }
}
