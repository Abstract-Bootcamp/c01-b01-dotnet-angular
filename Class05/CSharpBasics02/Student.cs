public class Student
{
    public int Id { get; set; }
    public string Name { get; set; }

    public Student()
    {
        // logic
    }

    public Student(string name)
    {
        // logic
        Name = name;
    }

    public Student(int id, string name)
    {
        if(id < 0)
        {
            throw new Exception("Id cannot be negative");
        }

        Id = id;
        Name = name;
    }
}
