using System;
using System.Collections.Generic;

namespace PasswordFinder
{
    public class PasswordFinder
    {
        public static int GetNumberOfPotentialValidPasswords(int lowerLimit, int upperLimit)
        {
            var validPasswords = new List<int>();
            
            for (var i = lowerLimit; i <= upperLimit; i++)
            {
                if (PassesAllRules(i))
                {
                    validPasswords.Add(i);
                }
            }

            return validPasswords.Count;
        }
        
        public static bool PassesAllRules(int input)
        {
            return IsSixDigits(input) && HasAdjacentMatchingDigits(input) && DigitsIncrease(input);
        }
        
        public static bool IsSixDigits(int input)
        {
            return GetNumberDigits(input) == 6;
        }

        public static bool HasAdjacentMatchingDigits(int input)
        {
            var intArray = GetIntArray(input);
            for (var i = 1; i < GetNumberDigits(input); i++)
            {
                if (intArray[i] == intArray[i - 1])
                {
                    return true;
                }
            }

            return false;
        }

        public static bool DigitsIncrease(int input)
        {
            var intArray = GetIntArray(input);
            for (var i = 1; i < GetNumberDigits(input); i++)
            {
                if (intArray[i] < intArray[i - 1])
                {
                    return false;
                }
            }

            return true;
        }

        private static int GetNumberDigits(int input)
        {
            return (int) Math.Floor(Math.Log10(input) + 1);
        }

        private static int[] GetIntArray(int input)
        {
            var result = new int[GetNumberDigits(input)];
            for (var i = result.Length - 1; i >= 0; i--)
            {
                result[i] = input % 10;
                input /= 10;
            }

            return result;
        }
    }
}