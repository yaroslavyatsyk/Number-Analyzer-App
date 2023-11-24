using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Number_Analysis_App
{
    public class NumberAnalyser
    {
        private BigInteger number;

        public NumberAnalyser(BigInteger number)
        {
            this.number = number;
        }

        public BigInteger Number { get { return number; } }


        public int GetDigitsCount()
        {
            var tempNumber = number;

            int digitsCount = 0;

            while (tempNumber > 0)
            {
                tempNumber /= 10;
                digitsCount++;
            }
            return digitsCount;
        }

        public BigInteger GetSumOfDigits()
        {
            var tempNumber = number;
            BigInteger sumOfDigits = 0;
            while (tempNumber > 0)
            {
                sumOfDigits +=  tempNumber % 10;
                tempNumber /= 10;
            }
            return sumOfDigits;
        }

        public BigInteger GetProductOfDigits()
        {
            var tempNumber = number;
            BigInteger productOfDigits = 1;
            while (tempNumber > 0)
            {
                productOfDigits *= tempNumber % 10;
                tempNumber /= 10;
            }
            return productOfDigits;
        }

        public int GetLargestDigit()
        {
            var tempNumber = number;
            int largestDigit = (int)(tempNumber % 10);
            while (tempNumber > 0)
            {
                if (tempNumber % 10 > largestDigit)
                {
                    largestDigit = (int)(tempNumber % 10);
                }
                tempNumber /= 10;
            }
            return largestDigit;
        }

        public int GetSmallestDigit()
        {
            var tempNumber = number;
            int smallestDigit = (int)(tempNumber % 10);
            while (tempNumber > 0)
            {
                if (tempNumber % 10 < smallestDigit)
                {
                    smallestDigit = (int)(tempNumber % 10);
                }
                tempNumber /= 10;
            }
            return smallestDigit;
        }

        public Dictionary<int, int> GetDigitFrequencies()
        {
            var tempNumber = number;
            Dictionary<int, int> digitFrequencies = new Dictionary<int, int>();
            while (tempNumber > 0)
            {
                int digit = (int)(tempNumber % 10);
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
            var tempNumber = number;
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
            var tempNumber = number;
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
            var tempNumber = number;
            int sumOfDigits = 0;
            while (tempNumber > 0)
            {
                sumOfDigits += (int)Math.Pow((int)(tempNumber % 10), GetDigitsCount());
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
            var tempNumber = number;
            BigInteger reverseNumber = 0;
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
            var tempNumber = number;
            string binaryNumber = "";
          
            while (tempNumber > 0)
            {
                binaryNumber += (tempNumber % 2);
                tempNumber /= 2;
            }
            return binaryNumber;
        }

        public BigInteger ToOctal()
        {
            var tempNumber = number;
          BigInteger octal = 0;
            while (tempNumber > 0)
            {
               octal += (tempNumber % 8);
                octal *= 10;
                tempNumber /= 8;
            }
            return octal;
        }

        public string ToHexadecimal()
        {
            var tempNumber = number;
           string hexadecimalNumber = "";
            while (tempNumber > 0)
            {
                int value = (int)(tempNumber % 16);

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

        private int GetFactorial(int number)
        {
            int[] facts = new int[number + 1];

            if(number < 0)
            {
                return 0;
            }
            else if(number == 0)
            {
                return 1;
            }
            else
            {
                facts[0] = 1;
                for(int i = 1; i <= number; i++)
                {
                    facts[i] = i * facts[i - 1];
                }
                return facts[number];
            }
        }

        public bool IsStrongNumber()
        {
            var tempNumber = number;
            int sumOfFactorials = 0;
            while (tempNumber > 0)
            {
                sumOfFactorials += GetFactorial((int)(tempNumber % 10));
                tempNumber /= 10;
            }
            return sumOfFactorials == number;
        }

        public bool IsFactorial()
        {
            int fact = 1;

            for(int i = 1; i <= number; i++)
            {
                fact *= i;
                if(fact == number)
                {
                    return true;
                }
            }

            return false;
        }


    }
}
