
int a = 5;

Employee ahmad = new Employee();
ahmad.Name = "Ahmad";
ahmad.Age = 25;
// Console.WriteLine(ahmad.Name);
// Console.WriteLine(ahmad.Age);
ahmad.Department = "IT";
// Console.WriteLine(ahmad.Department);
// Console.WriteLine(ahmad.Salary);
// Console.WriteLine(ahmad.HasEmail);

ahmad.Salary = 1000;// salary = 1000
ahmad.CommissionPct = 0.2;// commission percentage = 0.2

double netSalary = ahmad.CalculateNetSalary();// net salary = 1200


Console.WriteLine(netSalary);

ahmad.Email = "duaa@gmail.com";
Console.WriteLine(ahmad.HasEmail());
Console.WriteLine(ahmad.GetEmailIfExist());


Employee employeeWithoutEmail = new Employee();

Console.WriteLine(employeeWithoutEmail.HasEmail());
Console.WriteLine(employeeWithoutEmail.GetEmailIfExist());


//HasEmail


// Student odai = new Student();

// Console.WriteLine(odai);

public class Employee
{
    // Properties
    public int Id { get; set; }
    public string Name { get; set; }
    public string Department { get; set; }
    public double Salary { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public int Age { get; set; }
    public double CommissionPct { get; set; }

    // Methods
    // How to add parameters to method
    public double CalculateNetSalary()
    {
        double commission = Salary * CommissionPct;// commission value = 200
        double netSalary = Salary + commission;// net salary = 1200

        return netSalary;
    }

    public bool HasEmail() {
        if(string.IsNullOrEmpty(Email))
        {
            return false;
        } 
        else
        {
            return true;
        }
        // if(!string.IsNullOrEmpty(Email))
        // {
        //     return true;
        // } 
        // else
        // {
        //     return false;
        // }
    }

    public string GetEmailIfExist() {
        if(HasEmail()) {
            return Email;
        }
        else
        {
            return "No Email";
        }
    }

}

public class Student {
    public int Id { get; set; }
    public string Name { get; set; }
}
