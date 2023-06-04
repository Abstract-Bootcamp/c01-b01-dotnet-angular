namespace AdvancedApp.Models;

public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateOnly DateOfBirth { get; set; }
    public Job Job { get; set; }
}
