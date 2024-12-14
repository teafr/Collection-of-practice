using SerialisationDeserialization.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerialisationDeserialization.Data
{
    public static class StudentsData
    {
        public static List<Student> GetListOfStudents()
        {
            List<Subject> subjectsForFirstStudent = new List<Subject>()
            {
                new Subject("Math", new List<int>() { 7, 8, 12, 9 }),
                new Subject("Biology", new List<int>() { 11, 7, 11, 9 }),
            };
            List<Subject> subjectsForSecondStudent = new List<Subject>()
            {
                new Subject("Literature", new List<int>() { 9, 6, 9, 11 }),
                new Subject("Biology", new List<int>() { 10, 6, 9, 9 }),
            };
            List<Subject> subjectsForThirdStudent = new List<Subject>()
            {
                new Subject("Math", new List<int>() { 7, 3, 9, 5 }),
                new Subject("Literature", new List<int>() { 8, 2, 10, 12 }),
            };

            List<Student> students = new List<Student>()
            {
                new Student("Nastya", 19, subjectsForFirstStudent),
                new Student("Kate", 18, subjectsForSecondStudent),
                new Student("Sonya", 17, subjectsForThirdStudent)
            };

            return students;
        }
    }
}
