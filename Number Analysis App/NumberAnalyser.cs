using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Number_Analysis_App
{
    public class NumberAnalyser
    {
        private int number;

        public NumberAnalyser(int number)
        {
            this.number = number;
        }

        public int Number { get { return number; } }


        public int GetDigitsCount()
        {
            int tempNumber = number;

            int digitsCount = 0;

            while (tempNumber > 0)
            {
                tempNumber /= 10;
                digitsCount++;
            }
            return digitsCount;
        }

        public int GetSumOfDigits()
        {
            int tempNumber = number;
            int sumOfDigits = 0;
            while (tempNumber > 0)
            {
                sumOfDigits += tempNumber % 10;
                tempNumber /= 10;
            }
            return sumOfDigits;
        }

        public int GetProductOfDigits()
        {
            int tempNumber = number;
            int productOfDigits = 1;
            while (tempNumber > 0)
            {
                productOfDigits *= tempNumber % 10;
                tempNumber /= 10;
            }
            return productOfDigits;
        }

        public int GetLargestDigit()
        {
            int tempNumber = number;
            int largestDigit = tempNumber % 10;
            while (tempNumber > 0)
            {
                if (tempNumber % 10 > largestDigit)
                {
                    largestDigit = tempNumber % 10;
                }
                tempNumber /= 10;
            }
            return largestDigit;
        }

        public int GetSmallestDigit()
        {
            int tempNumber = number;
            int smallestDigit = tempNumber % 10;
            while (tempNumber > 0)
            {
                if (tempNumber % 10 < smallestDigit)
                {
                    smallestDigit = tempNumber % 10;
                }
                tempNumber /= 10;
            }
            return smallestDigit;
        }

        public Dictionary<int, int> GetDigitFrequencies()
        {
            int tempNumber = number;
            Dictionary<int, int> digitFrequencies = new Dictionary<int, int>();
            while (tempNumber > 0)
            {
                int digit = tempNumber % 10;
                if (digitFrequencies.ContainsKey(digit))
                {
                    digitFrequencies[digit]++;
                }
                else
                {
                    digitFrequencies.Add(digit, 1);
                }
                tempNumber /= 10;
            }
            return digitFrequencies;
        }

        public bool isPrimeNumber()
        {
            if(number <= 1)
            {
                return false;
            }
            for(int i = 2; i < number; i++)
            {
                if(number % i == 0)
                {
                    return false;
                }
            }
            return true;
        }

        public bool ContainsEvenDigits()
        {
            int tempNumber = number;
            while (tempNumber > 0)
            {
                if ((tempNumber % 10) % 2 == 0)
                {
                    return true;
                }
                tempNumber /= 10;
            }
            return false;
        }

        public bool ContainsOddDigits()
        {
            int tempNumber = number;
            while (tempNumber > 0)
            {
                if ((tempNumber % 10) % 2 != 0)
                {
                    return true;
                }
                tempNumber /= 10;
            }
            return false;
        }

        public bool IsAmstrongNumber()
        {
            int tempNumber = number;
            int sumOfDigits = 0;
            while (tempNumber > 0)
            {
                sumOfDigits += (int)Math.Pow(tempNumber % 10, GetDigitsCount());
                tempNumber /= 10;
            }
            return sumOfDigits == number;
        }

        public bool IsPerfectNumber()
        {
            int sumOfDivisors = 0;
            for(int i = 1; i < number; i++)
            {
                if(number % i == 0)
                {
                    sumOfDivisors += i;
                }
            }
            return sumOfDivisors == number;
        }

        public bool IsPalindrome()
        {
            int tempNumber = number;
            int reverseNumber = 0;
            while (tempNumber > 0)
            {
                reverseNumber  += tempNumber % 10;
                reverseNumber *= 10;
                tempNumber /= 10;
                
            }
            return reverseNumber == number;
        }

        public string ToBinary()
        {
            int tempNumber = number;
            string binaryNumber = "";
          ;
            while (tempNumber > 0)
            {
                binaryNumber += (tempNumber % 2);
                tempNumber /= 2;
            }
            return binaryNumber;
        }

        public string ToOctal()
        {
            int tempNumber = number;
           string octalNumber = "";
            while (tempNumber > 0)
            {
                octalNumber += (tempNumber % 8);
                tempNumber /= 8;
            }
            return octalNumber;
        }

        public string ToHexadecimal()
        {
            int tempNumber = number;
           string hexadecimalNumber = "";
            while (tempNumber > 0)
            {
                int value = tempNumber % 16;

                if (value > 9)
                {
                    switch (value)
                    {
                        case 10:
                            hexadecimalNumber += "A";
                            break;
                        case 11:
                            hexadecimalNumber += "B";
                            break;
                        case 12:
                            hexadecimalNumber += "C";
                            break;
                        case 13:
                            hexadecimalNumber += "D";
                            break;
                        case 14:
                            hexadecimalNumber += "E";
                            break;
                        case 15:
                            hexadecimalNumber += "F";
                            break;

                    }
                }
                else
                {
                    hexadecimalNumber += value;
                }
                tempNumber /= 16;
            }
            return hexadecimalNumber;
        }


    }
}
