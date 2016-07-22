using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//A palindromic number reads the same both ways. The largest palindrome made from the product of two 2-digit numbers is 9009 = 91 × 99.
//Find the largest palindrome made from the product of two 3-digit numbers.

namespace Project_Euler_4___Largest_Palindrome
{
    class Program
    {
        static void Main(string[] args)
        {
            long Largest = 0; // Stores the largest found palindrome number
            int FirstFactor = 999; // When multiplying all three digit numbers together, these store the two factors
            int SecondFactor = 999;
            int Product;
            int?[] ProductArray;
            ProductArray = new int?[10];
            for (FirstFactor = 999; FirstFactor > 100; FirstFactor--)
            {
                for (SecondFactor = 999; SecondFactor > 100; SecondFactor--) // Goes through every possible multiplication of 3-digit numbers, checks if the result is a palindrome, and if so, checks if it's the largest discovered so far.
                {
                    Product = FirstFactor * SecondFactor;
                    ProductArray = IntToArray(Product);   
                    if (IsPalindrome(ProductArray))
                    {
                        if (Product > Largest)
                        {
                            Largest = Product;
                            Console.WriteLine("New largest palindrome found: {0}", Product);
                        }
                    }
                }
            }
            Console.WriteLine("Largest palindrome: {0}", Largest);
            Console.ReadKey();
        }
        static bool IsPalindrome(int?[] CheckNumber)
        {
            int upperbound = 0; // The index of the most significant figure
            int length = 0; // The length of the number.
            int CurrentDigit = 0; // A counter used in the check
            while (CheckNumber[length] != null) // Checks each element in the passed digit array until it reaches a null element, thuse establishing the upper bound
            {
                length++;
            }
            upperbound = length - 1;
            for (CurrentDigit = 0; CurrentDigit <= (length / 2); CurrentDigit++)
            {
                if (CheckNumber[CurrentDigit] == CheckNumber[(upperbound - CurrentDigit)]) continue;
                else return false;
            }
            return true;
        }
        static int?[] IntToArray(int ConvertNumber) // Function to convert a number to an array of digits, making it easier to do a palindrome check
        {
            int?[] DigitArray;
            DigitArray = new int?[10]; // Each element in this array will represent one digit of the number converted.
            int digit = 0;
            int factor = 10;
            int IntermediateNumber = ConvertNumber % factor;
            while((IntermediateNumber != ConvertNumber))
            {
                IntermediateNumber = ConvertNumber % factor;
                if (IntermediateNumber >= 10 || (digit > 0 && IntermediateNumber < 10 )) DigitArray[digit] = (IntermediateNumber / (factor/10)); // Gets a digit past the first by dividing by the factor, which discards anything past the decimal point in integer division. 
                else DigitArray[digit] = IntermediateNumber;
                factor *= 10;
                digit++;

            }
            return DigitArray;
        }
    }
}
