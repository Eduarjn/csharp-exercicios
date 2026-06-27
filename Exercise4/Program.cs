using System.Collections.Generic;

List<int> numbers = new List<int>();

Console.WriteLine("Enter a list of numbers, type 0 when finished.");

int number = -1;

while (number != 0)
{
    Console.Write("Enter number: ");
    number = int.Parse(Console.ReadLine());
    if (number != 0)
    {
        numbers.Add(number);
    }
}

int sum = 0;
int largest = numbers[0];

foreach (int n in numbers)
{
    sum = sum + n;
    if (n > largest)
    {
        largest = n;
    }
}

double average = (double)sum / numbers.Count;

Console.WriteLine($"The sum is: {sum}");
Console.WriteLine($"The average is: {average}");
Console.WriteLine($"The largest number is: {largest}");
