namespace ReviewClasses;
class Program
{
    public static List<Employee> EmployeesDatabase = new List<Employee>();

    static void Main(string[] args)
    {
        while(true) {
            Console.WriteLine("Enter 1. To Create an Employee");
            Console.WriteLine("Enter 2. To Get All Employees");
            Console.WriteLine("Enter 3. To Get Employee By Id");
            Console.WriteLine("Enter 4. To Update an Employee");
            Console.WriteLine("Enter 5. To Delete an Employee");
            Console.WriteLine("Enter 6. To Exit");

           string option = Console.ReadLine();
           switch (option) {
            case "1":
                //create
                Console.WriteLine("Enter Name: ");
                string createName = Console.ReadLine();
                Console.WriteLine("Enter Title: ");
                string createTitle = Console.ReadLine();
                Console.WriteLine("Enter Salary must be a number: ");
                double createSalary = Convert.ToDouble(Console.ReadLine());

                Employee e = new Employee();
                e.Create(createName, createTitle, createSalary);
                break;
            case "2":
                //get all
                
                foreach(Employee employeeFromDatabase in EmployeesDatabase) {
                    string message = "id: " + employeeFromDatabase.Id.ToString() + " name: " + employeeFromDatabase.Name ;
                    Console.WriteLine(message);
                }


                break;
            case "3":
                //get
                Console.WriteLine("Get Employee By Id");
                break;
            case "4":
                //update
                Console.WriteLine("Enter Employee name for Update: ");
                string name = Console.ReadLine();

                Employee employee = new Employee();


                foreach(Employee empToUpdate in EmployeesDatabase) {
                  if(empToUpdate.Name == name){
                    employee = empToUpdate;
                    break;
                  }
                }

                Employee newEmployeeData = new Employee();
                Console.WriteLine("Enter new Name: ");
                newEmployeeData.Name = Console.ReadLine();
                Console.WriteLine("Enter new Title: ");
                newEmployeeData.Title = Console.ReadLine();
                Console.WriteLine("Enter new Salary must be a number: ");
                newEmployeeData.Salary = Convert.ToDouble(Console.ReadLine());

                employee.Update(newEmployeeData);
                break;
            case "5":
                //delete
                Console.WriteLine("Delete an Employee");
                break;
            case "6":
                //exit
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("Invalid Option");
                break;
           }
        }
    }
}
