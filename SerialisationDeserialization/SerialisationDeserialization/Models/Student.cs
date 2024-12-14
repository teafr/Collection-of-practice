using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerialisationDeserialization.Models
{
    public class Student
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public List<Subject> Subjects { get; set; }

        public Student() { }
        public Student(string studentName, int age, List<Subject> subjects)
        {
            Name = studentName;
            Age = age;
            Subjects = subjects;
        }

        public void ShowStudentInfo()
        {
            Console.Write($"\nName: {Name}\tAge: {Age}\nSubjects:\n");

            if ( Subjects != null )
            {
                foreach (var subject in Subjects)
                {
                    Console.Write($"\tName of subject: {subject.Name}\tGrades: [ ");
                    foreach (var grade in subject.Grades)
                        Console.Write(grade + " ");
                    Console.Write("]\n");
                }
            }
            else
                Console.Write("No subjects added\n");

            Console.WriteLine();
        }
    }
}
