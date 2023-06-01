namespace EmployeesManager.Models;

public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime DateOfBirth { get; set; }
    public Job Job { get; set; }
}
