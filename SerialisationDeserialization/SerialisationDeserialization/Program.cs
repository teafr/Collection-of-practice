using SerialisationDeserialization.Data;
using SerialisationDeserialization.Models;
using System.Text.Json;

namespace SerialisationDeserialization
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = StudentsData.GetListOfStudents();

            var option = new JsonSerializerOptions { WriteIndented = true };
            var jsonString = JsonSerializer.Serialize(students, option);

            Console.WriteLine(jsonString);

            var studentsFromJSON = JsonSerializer.Deserialize<List<Student>>(jsonString, option);

            if (studentsFromJSON == null)
            {
                Console.WriteLine("Students could not be deserialized");
                return;
            }

            OperationsWithStudents.GetAllStudents(studentsFromJSON);
        }        
    }
}
