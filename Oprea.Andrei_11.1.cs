using System.ComponentModel;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;

namespace Oprea.Rares_11._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a, b;
            try
            {
                checked
                {
                    Console.WriteLine("Enter the 1st number");
                    a = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter the 2nd number");
                    b = Convert.ToInt32(Console.ReadLine());
                    Add(a, b);
                    Remove(a, b);
                    Multiply(a, b);
                    Divide(a, b);
                }
            }
            catch(NotFiniteNumberException nr)
            {
                Console.WriteLine("Not an integer");
            }
            catch(Exception ex)
            {
                Console.WriteLine("Not an integer");
            }
        }
        static public int Add(int a, int b) 
        {
            int sum = 0;
            try
            {
                unchecked
                {
                    sum = a + b;
                    Console.WriteLine($"The sum of the numbers is {sum}");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("There was an error with the math");
            }
            return sum;
        }
        static public int Remove(int a, int b)
        {
            int diff = 0;
            try
            {
                unchecked
                {
                    diff = a - b;
                    Console.WriteLine($"The difference of the numbers is {diff}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("There was an error with the math");
            }
            return diff;
        }
        static public int Multiply(int a, int b)
        {
            int prod = 0;
            try
            {
                unchecked
                {
                    prod = a * b;
                    Console.WriteLine($"The product of the numbers is {prod}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("There was an error with the math");
            }
            return prod;
        }
        static public float Divide(int a, int b)
        {
            float div = 0;
            try
            {
                unchecked
                {
                    div = a / b;
                    Console.WriteLine($"The division of the numbers is {div}");
                }
            }
            catch(DivideByZeroException zero)
            {
                Console.WriteLine("Division by zero is impossible");
            }
            catch (Exception ex)
            {
                Console.WriteLine("There was an error with the math");
            }
            return div;
        }
    }
}
