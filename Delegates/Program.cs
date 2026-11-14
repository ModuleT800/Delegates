using System;
using System.Collections.Generic;

namespace Delegates
{
    delegate bool NumberConDition(int number);

    class Program
    {
        static void Main()
        {
            // Task 1
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            int[] numbers = { 1, 2, 3, 4, 5, 8, 11, 13, 15, 21, 22, 34, 40 };

            Console.WriteLine("Output array: " + string.Join(", ", numbers));

            int[] evenNumbers = FilterArray(numbers, IsEven);
            Console.WriteLine("Even numbers: " + string.Join(", ", evenNumbers));

            int[] oddNumbers = FilterArray(numbers, IsOdd);
            Console.WriteLine("Odd numbers: " + string.Join(", ", oddNumbers));

            int[] primeNumbers = FilterArray(numbers, IsPrime);
            Console.WriteLine("Prime numbers: " + string.Join(", ", primeNumbers));

            int[] fibNumbers = FilterArray(numbers, IsFibonacci);
            Console.WriteLine("Fibonacci numbers: " + string.Join(", ", fibNumbers));

            // Task 2
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Action showTime = DisplayCurrentTime;
            Action showDate = DisplayCurrentDate;
            Action showDayOfWeek = DisplayCurrentDayOfWeek;

            showTime();
            showDate();
            showDayOfWeek();
            Console.WriteLine();

            Predicate<double> isTriangleAreaGreaterThan100 = area => area > 100;
            Func<double, double, double> calculateTriangleArea = CalculateTriangleArea;
            Func<double, double, double> calculateRectangleArea = CalculateRectangleArea;

            double a = 5.0, h = 4.0;
            if (isPositive(a) && isPositive(h))
            {
                double triangleArea = calculateTriangleArea(a, h);
                Console.WriteLine($"Triangle area: {triangleArea}");
            }
            
            double width = 6.0, height = 3.5;
            if (isPositive(width) && isPositive(height))
            {
                double rectangleArea = calculateRectangleArea(width, height);
                Console.WriteLine($"Rectangle area: {rectangleArea}");
            }
        }

        static int[] FilterArray(int[] numbers, NumberConDition condition)
        {
            List<int> result = new List<int>();
            foreach (int number in numbers)
            {
                if (condition(number))
                {
                    result.Add(number);
                }
            }
            return result.ToArray();
        }

        static bool IsEven(int number)
        {
            return number % 2 == 0;
        }

        static bool IsOdd(int number)
        {
            return number % 2 != 0;
        }

        static bool IsPrime(int number)
        {
            if (number < 2)
                return false;
            for (int i = 2; i * i <= number; i++)
            {
                if (number % i == 0)
                    return false;
            }
            return true;
        }

        static bool IsFibonacci(int number)
        {
            int a = 0, b = 1;
            while (b < number)
            {
                int temp = a + b;
                a = b;
                b = temp;
            }
            return b == number;
        }

        static bool IsPerfectSquare(int number)
        {
            int sqrt = (int)Math.Sqrt(number);
            return sqrt * sqrt == number;
        }

        // 2.
        static void DisplayCurrentTime()
        {
            Console.WriteLine("Current time: " + DateTime.Now.ToString("T"));
        }

        static void DisplayCurrentDate()
        {
            Console.WriteLine("Current date: " + DateTime.Now.ToString("d"));
        }

        static void DisplayCurrentDayOfWeek()
        {
            Console.WriteLine("Current day of the week: " + DateTime.Now.DayOfWeek);
        }
        static double CalculateTriangleArea(double baseLength, double height)
        {
            return 0.5 * baseLength * height;
        }
        static double CalculateRectangleArea(double width, double height)
        {
            return width * height;
        }

        static bool isPositive(double number)
        {
            return number > 0;
        }
    }
}