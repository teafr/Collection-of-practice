namespace SerialisationDeserialization.Models
{
    public class Subject
    {
        public string Name { get; set; }
        public List<int> Grades { get; set; }

        public Subject(string name, List<int> grades)
        {
            Name = name;
            Grades = grades;
        }
    }
}