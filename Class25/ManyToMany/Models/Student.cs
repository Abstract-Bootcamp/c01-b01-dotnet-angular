
namespace ManyToMany.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? AddressId { get; set; }
        public Address? Address { get; set; }
        public List<Course> Courses { get; set; } = new();
    }

    public class Address
    {
        public int Id { get; set; }
        public string Location { get; set; }
    }

    public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<Student> Students { get; set; } = new();
    }

}
