
Console.WriteLine("Enter First Number test");
Console.ForegroundColor = ConsoleColor.Red;
int x = int.Parse(Console.ReadLine());
Console.ForegroundColor = ConsoleColor.Blue;
Console.WriteLine("Enter Second Number");


Console.ResetColor();

int y = int.Parse(Console.ReadLine());

Console.BackgroundColor = ConsoleColor.Green;

Console.WriteLine("The result is: ");
//int result = x + y;
//Console.WriteLine(result);

int result = x + y;

Console.WriteLine(result);

//Console.ReadLine();
