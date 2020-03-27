using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tree;
using ArrayList;


namespace epam2
{
    class Program
    {
        static void Main(string[] args)
        {
            var tree = new MyTree<int>();
            int[] arr = new int[] { 5, 2, 6, 1, 8 };
            foreach (var item in arr)
            {
                tree.Insert(item);
            }

            tree.Remove(2);
            Console.WriteLine($"3 is in tree: {tree.Find(3)}");
            Console.WriteLine($"2 is in tree: {tree.Find(2)}");
            foreach (var item in tree)
            {
                Console.WriteLine(item + " ");
            }

            List<Student> students = new List<Student>(){
            new Student(Name: "Pavlo", Surname: "Petrov", Mark: 96, Date: new DateTime(2019, 12, 1), Test: "OLAP2"),
            new Student(Name: "Dmytro", Surname: "Ivanchuk", Mark: 78, Date: new DateTime(2019, 10, 15), Test: "MMDO-1"),
            new Student(Name: "Olga", Surname: "Sinchuk", Mark: 69, Date: new DateTime(2019, 8, 22), Test: "OLAP1")
            };

            var studentTree = new MyTree<Student>();

            studentTree.OnRemove += OnTreeRemove;
            studentTree.OnInsert += OnTreeInsert;

            foreach (var item in students)
            {
                studentTree.Insert(item);
            }

            Console.WriteLine("Students tree:");
            foreach (var item in studentTree)
            {
                Console.WriteLine($"{item} ");
            }

            var student = new Student(Name: "Dmytro", Surname: "Ivanchuk", Mark: 78, Date: new DateTime(2019, 10, 15), Test: "MMDO-1");
            var student1 = new Student(Name: "Oleksandr", Surname: "Kovalev", Mark: 100, Date: new DateTime(2019, 11, 21), Test: "PIS-12");

            try
            {
                studentTree.Remove(student);
                Console.WriteLine($"Kovalev is in tree: {studentTree.Find(student1)}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            try
            {
                studentTree.Insert(student1);
                Console.WriteLine($"Kovalev is in tree: {studentTree.Find(student1)}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            var ar = new MyArrayList<int>(-2,10);
            ar[-2] = 1;
            ar[0] = 2;
            ar[5] = 3;
            ar[7] = 4;

            foreach (object el in ar)
            {
                Console.Write($"{el} ");
            }
            Console.ReadKey();
        }

        static void OnTreeRemove<T>(object sender, MyTreeEventArgs<T> e)
        {
            Console.WriteLine($"Element removed: {e.Element}");
        }

        static void OnTreeInsert<T>(object sender, MyTreeEventArgs<T> e)
        {
            Console.WriteLine($"Element inserted: {e.Element}");
        }
    }
}
