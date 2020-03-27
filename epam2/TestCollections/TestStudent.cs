using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tree;
using Xunit;

namespace TestTree
{
    public class TestStudent
    {
        [Fact]
        public void Student_CreateStudent_ObjectIsNotNull()
        {
            //arrenge
            Student student;

            //act
            student = new Student();

            //assert
            Assert.NotNull(student);
        }

        [Fact]
        public void Student_CreateStudentWithValue_ObjectIsNotNull()
        {
            //arrenge
            Student student;
            string Name = "name", Surname = "surname", Test = "test";
            int Mark = 100; DateTime Date = new DateTime(2019, 10, 15);
            var expected = new List<string> { Name, Surname, Test, Date.ToString(), Mark.ToString()};
           
            //act
            student = new Student(Name, Surname, Test, Date, Mark);
            var actual = new List<string> { student.Name, student.Surname, student.Test, student.Date.ToString(), student.Mark.ToString() };

            //assert
            Assert.Equal(expected,actual);
        }

        [Fact]
        public void Student_SetMark_ThrowArgumentException()
        {
            //arrenge
            Student student = new Student();

            //act
            Action action = () => { student.Mark = -10; };

            //assert
            Assert.Throws<ArgumentException>(action);
        }

        [Fact]
        public void ToString_ReturnStringForStudent_StringIsCorrect()
        {
            //arrenge
            Student student = new Student("name","surname","test",new DateTime(2019, 10, 15), 100);
            string expected = "surname name :100";

            //act
            var actual = student.ToString();

            //assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CompareTo_CompareSmallerToBigger_ReturnNegativeValue()
        {
            //arrenge
            Student student1 = new Student("name1", "surname1", "test1", new DateTime(2019, 10, 15), 70);
            Student student2 = new Student("name2", "surname2", "test2", new DateTime(2019, 10, 15), 90);

            //act
            var actual = student1.CompareTo(student2);

            //assert
            Assert.Equal(-1, actual);
        }

        [Fact]
        public void CompareTo_CompareBiggerToSmaller_ReturnPositiveValue()
        {
            //arrenge
            Student student1 = new Student("name1", "surname1", "test1", new DateTime(2019, 10, 15), 70);
            Student student2 = new Student("name2", "surname2", "test2", new DateTime(2019, 10, 15), 90);

            //act
            var actual = student2.CompareTo(student1);

            //assert
            Assert.Equal(1, actual);
        }

        [Fact]
        public void CompareTo_CompareSameValues_ReturnNullValue()
        {
            //arrenge
            Student student1 = new Student("name1", "surname1", "test1", new DateTime(2019, 10, 15), 70);
           
            //act
            var actual = student1.CompareTo(student1);

            //assert
            Assert.Equal(0, actual);
        }
    }
}
