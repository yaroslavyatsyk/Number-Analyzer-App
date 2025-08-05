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
        private long number;

        public NumberAnalyser(long number)
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

        public int GetSumOfDigits()
        {
            var tempNumber = number;
            int sumOfDigits = 0;
            while (tempNumber > 0)
            {
                sumOfDigits += (int)tempNumber % 10;
                tempNumber /= 10;
            }
            return sumOfDigits;
        }

        public long GetProductOfDigits()
        {
            var tempNumber = number;
            long productOfDigits = 1;
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

        public Dictionary<long, int> GetDigitFrequencies()
        {
            var tempNumber = number;
            Dictionary<long, int> digitFrequencies = new Dictionary<long, int>();
            while (tempNumber > 0)
            {
               var digit = tempNumber % 10;
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
            for(int i = 2; i <= Math.Sqrt(number); i++)
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
            StringBuilder binaryNumber = new StringBuilder();

            while (tempNumber > 0)
            {
                var binaryDigit = tempNumber % 2;
                
                binaryNumber.Insert(0, binaryDigit);
                tempNumber /= 2;
            }
            return binaryNumber.ToString();
        }

        public long ToOctal()
        {
            var tempNumber = number;
          long octal = 0;
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
            StringBuilder hexadecimalBuilder = new StringBuilder();
            while (tempNumber > 0)
            {
                int value = (int)(tempNumber % 16);

                if (value > 9)
                {
                    switch (value)
                    {
                        case 10:
                            hexadecimalBuilder.Insert(0,"A");
                            break;
                        case 11:
                            hexadecimalBuilder.Insert(0, "B");
                            break;
                        case 12:
                            hexadecimalBuilder.Insert(0, "C");
                            break;
                        case 13:
                            hexadecimalBuilder.Insert(0, "D");
                            break;
                        case 14:
                              
                            hexadecimalBuilder.Insert(0, "E");
                            break;
                        case 15:
                            hexadecimalBuilder.Insert(0, "F");
                            break;

                    }
                }
                else
                {
                    hexadecimalBuilder.Insert(0, value);

                }
                tempNumber /= 16;
            }
            return hexadecimalBuilder.ToString();
        }

        private long GetFactorial(int number)
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
                sumOfFactorials += (int)GetFactorial((int)(tempNumber % 10));
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

        public List<long> GetUniqueDigits()
        {
            
            Dictionary<long, int> digitFrequencies = GetDigitFrequencies();
            List<long> uniqueDigits = new List<long>();


            foreach (var kvp in digitFrequencies)
            {
                if (kvp.Value == 1)
                {
                    uniqueDigits.Add(kvp.Key);
                }
            }
            uniqueDigits.Sort();
            return uniqueDigits;

        }


    }
}
