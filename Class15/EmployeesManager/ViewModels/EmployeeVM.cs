namespace EmployeesManager.ViewModels
{
    public class EmployeeVM
    {
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public JobVM Job { get; set; }
    }
}