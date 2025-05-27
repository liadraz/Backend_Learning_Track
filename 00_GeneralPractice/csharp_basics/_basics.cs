// using System;
// using System.Collections;
// using System.Collections.Generic;

//
//
// Delegates ->
//
//

// public delegate int MathOperation(int a, int b);

// public static class MathOps
// {
//     public static int Add(int a, int b) => a + b;
//     public static int Subtract(int a, int b) => a - b;
//     public static int Multiply(int a, int b) => a * b;
// }

// class Program
// {
//     private static void Main()
//     {
//         MathOperation[] del = { MathOps.Add, MathOps.Subtract, MathOps.Multiply };

//         while (true)
//         {
//             Console.Clear();
//             Console.WriteLine("Enter a Math Operation: ");
//             Console.WriteLine("1. Add, 2. Subtract, 3. Multiply");
//             Int32.TryParse(Console.ReadLine(), out int op);

//             Console.WriteLine();

//             Console.WriteLine("Enter first number: ");
//             Int32.TryParse(Console.ReadLine(), out int a);
//             Console.WriteLine("Enter second number: ");
//             Int32.TryParse(Console.ReadLine(), out int b);

//             int res = del[op - 1](a, b);

//             System.Console.WriteLine($"Result is {res}");
//             Console.ReadKey();
//         }
//     }
// }

//
//
// IEnumerable ->
//
//

// public class Zoo : IEnumerable<string>
// {
//     private List<string> animals = new List<string>();

//     public void AddAnimal(string animal)
//     {
//         animals.Add(animal);
//     }

//     public IEnumerator<string> GetEnumerator()
//     {
//         return animals.GetEnumerator();
//     }

//     IEnumerator IEnumerable.GetEnumerator()
//     {
//        return (IEnumerator)GetEnumerator();
//     }
// }

// class Program
// {
//     static void Main()
//     {
//         Zoo zoo = new Zoo();
//         zoo.AddAnimal("Lion");
//         zoo.AddAnimal("Elephant");
//         zoo.AddAnimal("Zebra");

//         foreach (var animal in zoo)
//         {
//             Console.WriteLine(animal);
//         }
//     }
// }


//
//
// Events ->
//
//

// public class TimerSimulator
// {
//     public event Action<int> Tick;

//     public void Start()
//     {
//         for (int i = 1; i <= 5; i++)
//         {
//             Thread.Sleep(1000);
//             Tick?.Invoke(i);
//         }
//     }
// }
// public class ClockDisplay
// {
//     public void ShowTick(int seconds)
//     {
//         Console.WriteLine($"Clock: {seconds} second(s) passed.");
//     }

//         public void ShowTickHeb(int seconds)
//     {
//         Console.WriteLine($"שעון: {seconds} שניות(s) עברו.");
//     }
// }

// class Program
// {
//     static void Main()
//     {
//         TimerSimulator timer = new();
//         ClockDisplay clock = new();

//         timer.Tick += clock.ShowTick;
//         timer.Tick += clock.ShowTickHeb;

//         timer.Start();
//     }
// }


//
//
// Collections ->
//
//

// List<string> students = new List<string> { "Liad", "Yoav", "Biscuit", "Potato" };

// Dictionary<string, int> studentAges = new Dictionary<string, int>
// {
//     {"Liad", 37},
//     {"Yoav", 41},
//     {"Biscuit", 6},
//     {"Potato", 3}
// };

// foreach (var name in students)
// {
//     Console.WriteLine(name);
// }

// Console.WriteLine("Enter student name to get age: ");
// string input = Console.ReadLine();

// if (studentAges.ContainsKey(input))
// {
//     Console.WriteLine($"{input} age is {studentAges[input]}");
// }

// foreach (var key in studentAges.Keys)
// {
//     System.Console.WriteLine($"Name {key}");
// }

// foreach (var value in studentAges.Values)
// {
//     System.Console.WriteLine($"Age {value}");
// }

// foreach (var kv in studentAges)
// {
//     System.Console.WriteLine($"{kv.Key} {kv.Value}");
// }


//
//
// throw ->
//
//


// // Prompt the user for the lower and upper bounds
// Console.Write("Enter the lower bound: ");
// int lowerBound = int.Parse(Console.ReadLine());

// Console.Write("Enter the upper bound: ");
// int upperBound = int.Parse(Console.ReadLine());

// decimal averageValue = 0;

// bool exit = false;

// do
// {
//     try
//     {
//         // Calculate the sum of the even numbers between the bounds
//         averageValue = AverageOfEvenNumbers(lowerBound, upperBound);

//         // Display the result to the user
//         Console.WriteLine($"The average of even numbers between {lowerBound} and {upperBound} is {averageValue}.");

//         exit = true;
//     }
//     catch (ArgumentOutOfRangeException ex)
//     {
//         Console.WriteLine("An error has occurred.");
//         Console.WriteLine(ex.Message);
//         Console.WriteLine($"The upper bound must be greater than {lowerBound}");
//         Console.Write($"Enter a new upper bound (or enter Exit to quit): ");
//         string? userResponse = Console.ReadLine();
//         if (userResponse.ToLower().Contains("exit"))
//         {
//             exit = true;
//         }
//         else
//         {
//             exit = false;
//             upperBound = int.Parse(userResponse);
//         }
//     }    
// } while (exit == false);


// // Display the value returned by AverageOfEvenNumbers in the console
// Console.WriteLine($"The average of even numbers between {lowerBound} and {upperBound} is {averageValue}.");

// // Wait for user input
// Console.ReadLine();

// static decimal AverageOfEvenNumbers(int lowerBound, int upperBound)
// {
//     if (lowerBound >= upperBound)
//     {
//         throw new ArgumentOutOfRangeException("upperBound", "ArgumentOutOfRangeException: upper bound must be greater than lower bound.");
//     }

//     int sum = 0;
//     int count = 0;
//     decimal average = 0;

//     for (int i = lowerBound; i <= upperBound; i++)
//     {
//         if (i % 2 == 0)
//         {
//             sum += i;
//             count++;
//         }
//     }

//     average = (decimal)sum / count;

//     return average;
// }