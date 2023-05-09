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
    public double CalculateNetSalary(double commission)
    {
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
