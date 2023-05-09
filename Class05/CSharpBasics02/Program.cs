using System.Collections.Generic;


Employee ahmad = new Employee();
ahmad.Name = "Ahmad";
ahmad.Age = 25;
ahmad.Department = "IT";

ahmad.Salary = 1000;// salary = 1000
ahmad.CommissionPct = 0.2;// commission percentage = 0.2

double commission = ahmad.Salary * ahmad.CommissionPct;// commission value = 200
double netSalary = ahmad.CalculateNetSalary(commission);// net salary = 1200

Console.WriteLine(netSalary);

ahmad.Email = "duaa@gmail.com";
Console.WriteLine(ahmad.HasEmail());
Console.WriteLine(ahmad.GetEmailIfExist());

Employee employeeWithoutEmail = new Employee();

Console.WriteLine(employeeWithoutEmail.HasEmail());
Console.WriteLine(employeeWithoutEmail.GetEmailIfExist());

Student test = new Student();

Student hadi = new Student("Hadi");
Console.WriteLine(hadi.Id);
Console.WriteLine(hadi.Name);

Student kahter = new Student(111, "Khater");
Console.WriteLine(kahter.Id);
Console.WriteLine(kahter.Name);

///////////////// arrays
Console.WriteLine("Printing Array values");


int[] numbers = new int[5];// size 5
//[0,0,0,0,0]

numbers[0] = 1;
//[1,0,0,0,0]
numbers[1] = 15;
//[1,15,0,0,0]
numbers[4] = 6;
//[1,15,0,0,6]
Console.ForegroundColor = ConsoleColor.Red;
// Console.WriteLine(numbers[3]);
// Console.WriteLine(numbers[4]);
// i = i + 1
// loop through array 5 times
for(int i = 0; i < numbers.Length; i++)
{
    Console.WriteLine(numbers[i]);
}

//ctrl + shift + p

Console.ForegroundColor = ConsoleColor.Yellow;

Employee[] employees = new Employee[3];
employees[0] = ahmad;
//[ahmad, null, null]
Console.WriteLine(employees[0].Name);

//// List

Console.ForegroundColor = ConsoleColor.Green;

List<int> numbersList = new List<int>();
// List<Employee> employeesList = new List<Employee>();
numbersList.Add(1);
numbersList.Add(20);
numbersList.Add(30);
numbersList.Add(400);
numbersList.Add(400);
numbersList.Add(400);
numbersList.Add(400);
numbersList.Add(400);
numbersList.Add(400);

for(int i = 0; i < numbersList.Count; i++)
{
    Console.WriteLine(numbersList[i]);
}


Console.ForegroundColor = ConsoleColor.Blue;


foreach(int number in numbersList)
{
    if(number > 20){
        Console.WriteLine(number);
    }
}
