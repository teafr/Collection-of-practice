using SerialisationDeserialization.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerialisationDeserialization
{
    public static class OperationsWithStudents
    {
        public static void GetAllStudents(List<Student> students)
        {
            if (students != null)
                foreach (var student in students)
                    student.ShowStudentInfo();
        }
        public static void CreateStudent(List<Student> students, Student student)
        {
            if (students == null || students.Count == 0) return;

            students.Add(student);
        }
        public static void DeleteStudentByName(List<Student> students, string name)
        {
            Student student = students.FirstOrDefault(n => n.Name == name)!;
            if (student != null) 
                students.Remove(student);
        }
    }
}
