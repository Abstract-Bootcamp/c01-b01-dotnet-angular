int[] x = new int[10];
for (int i = 0; i < x.Length; i++)
{
    x[i] = x[i] * 5;
}
// [0, 5, 10, 20, 30, 40, 50, 60, 70, 80]
int[] y = new int[10];
for (int i = 0; i < y.Length; i++)
{
    y[i] = y[i] * 5;
}
// [0, 5, 10, 20, 30, 40, 50, 60, 70, 80]


// find a value of 70 in x and then get the index of the same value in y
for (int i = 0; i < x.Length; i++)
{
    if (x[i] == 70)
    {
        for (int j = 0; j < y.Length; i++)
        {
            if (y[j] == x[i])
            {
                Console.WriteLine("The index of 70 in y is: " + j);
            }
        }
    }
}
