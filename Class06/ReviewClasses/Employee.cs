namespace ReviewClasses;
public class Employee {

    public int Id { get; set; }
    public string Name { get; set; }
    public string Title { get; set; }
    public double Salary { get; set; }

    //crud
    public void Create(string name, string title, double salary) {
        Employee newEmployee = new Employee();
        newEmployee.Name = name;
        newEmployee.Title = title;
        newEmployee.Salary = salary;

        int id = GetEmployeeId();
        newEmployee.Id = id;

        Program.EmployeesDatabase.Add(newEmployee);

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Employee Created Successfully");
        Console.ResetColor();
    }

    // public List<Employee> GetAll() {

    // }

    // public Employee GetById(int id) {
        
    // }

    public void Update(Employee employee) {
        Name = employee.Name;
        Title = employee.Title;
        Salary = employee.Salary;
    }

    public void Delete(int id) {
    }

// 
    private int GetEmployeeId() {
        if(Program.EmployeesDatabase.Count == 0){
            return 1;
        } else {
            return Program.EmployeesDatabase.Last().Id++;
        }
    }
}
