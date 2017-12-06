﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using JetBrains.Annotations;

namespace Euler
{
    public static class NaturalNumbers
    {
        static void Main() { }

        /*
         * If we list all the natural numbers below 10 that are multiples of 3 or 5, we get 3, 5, 6 and 9. The sum of these multiples is 23.
         * Find the sum of all the multiples of 3 or 5 below 1000. 
         */
        public static long SumMultiplesOf3And5Under1000()
        {
            long result = 0;
            var multiplesOf3 = new HashSet<int>();
            var multiplesOf5 = new HashSet<int>();

            for (int index = 1; index < 1000; index++)
            {
                if (index % 3 == 0) { multiplesOf3.Add(index); }
                if (index % 5 == 0) { multiplesOf5.Add(index); }
            }
            multiplesOf5.UnionWith(multiplesOf3);
            var values = new int[multiplesOf5.Count];
            multiplesOf5.CopyTo(values);

            Array.ForEach(values, item => result += item);
            return result;
        }

        /*
         * Each new term in the Fibonacci sequence is generated by adding the previous two terms. By starting with 1 and 2, the first 10 terms will be:
         * 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, ...
         * By considering the terms in the Fibonacci sequence whose values do not exceed four million, find the sum of the even-valued terms.
         */
        public static long SumEvenFibonacciUnder4Million()
        {
            long result = 0;

            long actualValue = 0;
            int iteration = 0;
            while (actualValue < 4000000)
            {
                iteration++;
                actualValue = Utils.Fibonacci(iteration);
                if (actualValue % 2 == 0 && actualValue < 4000000) { result += actualValue; }
            }

            return result;
        }

        /*
         * The prime factors of 13195 are 5, 7, 13 and 29.
         * What is the largest prime factor of the number 600851475143 ?
         */
        public static long LargestPrimeFactorOf600851475143()
        {
            return LargestPrimeFactorOf(600851475143);
        }

        public static long LargestPrimeFactorOf(long numberToFactorize)
        {
            var allPrimesFactors = Utils.PrimesFactorsOf(numberToFactorize);
            Array.Sort(allPrimesFactors);
            return allPrimesFactors[allPrimesFactors.Length - 1];
        }

        /*
         * A palindromic number reads the same both ways. The largest palindrome made from the product of two 2-digit numbers is 9009 = 91 × 99.
         * Find the largest palindrome made from the product of two 3-digit numbers.
         */
        public static int LargestPalindromicFromThreeDigits()
        {
            int result = 0;

            HashSet<int> potentials = new HashSet<int>();
            for (int anHundred = 1; anHundred < 10; anHundred++)
            {
                int slacker = anHundred * 100;
                while (slacker < (anHundred + 1) * 100)
                {
                    for (int index = 0; index < 100; index++)
                    {
                        int value = anHundred * 100 + index;
                        int candidate = value * slacker;
                        if (IsLongerPalindrom(candidate, result)) { potentials.Add(candidate); }

                    }
                    slacker++;
                }
            }
            int[] sortingArray = new int[potentials.Count];
            potentials.CopyTo(sortingArray);
            Array.Sort(sortingArray);
            result = sortingArray[sortingArray.Length - 1];
            return result;
        }

        public static bool IsLongerPalindrom(int candidate, int older)
        {
            string challenger = candidate.ToString();
            string champion = older.ToString();
            if (!Utils.IsAPalindrom(challenger)) { return false; }
            return challenger.Length > champion.Length;
        }

        /*
         * 2520 is the smallest number that can be divided by each of the numbers from 1 to 10 without any remainder.
         * What is the smallest positive number that is evenly divisible by all of the numbers from 1 to 20?
         */
        public static int SmallestEvenlyDivisibleByAllTwentyFirstNumbers()
        {
            HashSet<int> factors = new HashSet<int>(new[] { 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 });

            int result = 0;
            int candidate = 2520;
            bool looping = true;
            while (looping)
            {
                if (Utils.IsEvenlyDivisibleBy(candidate, factors))
                {
                    result = candidate;
                    looping = false;
                }
                candidate++;
            }

            return result;
        }

        /*
         * The sum of the squares of the first ten natural numbers is 1² + 2² + ... + 10² = 385 
         * The square of the sum of the first ten natural numbers is, (1 + 2 + ... + 10)² = 55² = 3025
         * Hence the difference between the sum of the squares of the first ten natural numbers and the square of the sum is 3025 − 385 = 2640.
         * Find the difference between the sum of the squares of the first one hundred natural numbers and the square of the sum.
         */

        public static long SumSquareDifference()
        {
            long sumAggregator = 0;
            long squareAggregator = 0;

            for (int index = 1; index < 101; index++)
            {
                sumAggregator += index;
                squareAggregator += (index * index);
            }

            sumAggregator *= sumAggregator;
            long result = Math.Abs(sumAggregator - squareAggregator);

            return result;
        }

        /*
         * By listing the first six prime numbers: 2, 3, 5, 7, 11, and 13, we can see that the 6th prime is 13.
         * What is the 10 001st prime number?
         */

        public static ulong TenThousandOnethPrime()
        {
            var tenThousandPrimes = new[] { 1UL };
            ulong limit = (ulong)Math.Pow(2, 16);

            tenThousandPrimes = Utils.FindPrimes(limit, tenThousandPrimes);
            while (tenThousandPrimes.Length < 10001)
            {
                tenThousandPrimes = Utils.FindPrimes(limit, tenThousandPrimes);
                limit *= 2;
            }

            ulong result = tenThousandPrimes[10001];
            return result;
        }

        /*
         * The four adjacent digits in the 1000-digit number that have the greatest product are 9 × 9 × 8 × 9 = 5832.
         * 
         * 73167176531330624919225119674426574742355349194934
         * 96983520312774506326239578318016984801869478851843
         * 85861560789112949495459501737958331952853208805511
         * 12540698747158523863050715693290963295227443043557
         * 66896648950445244523161731856403098711121722383113
         * 62229893423380308135336276614282806444486645238749
         * 30358907296290491560440772390713810515859307960866
         * 70172427121883998797908792274921901699720888093776
         * 65727333001053367881220235421809751254540594752243
         * 52584907711670556013604839586446706324415722155397
         * 53697817977846174064955149290862569321978468622482
         * 83972241375657056057490261407972968652414535100474
         * 82166370484403199890008895243450658541227588666881
         * 16427171479924442928230863465674813919123162824586
         * 17866458359124566529476545682848912883142607690042
         * 24219022671055626321111109370544217506941658960408
         * 07198403850962455444362981230987879927244284909188
         * 84580156166097919133875499200524063689912560717606
         * 05886116467109405077541002256983155200055935729725
         * 71636269561882670428252483600823257530420752963450
         * 
         * Find the thirteen adjacent digits in the 1000-digit number that have the greatest product. What is the value of this product?
         */
        public static long GreatestAdjacentSerieInBigDigit()
        {

            var bigDigitBuilder = new StringBuilder();
            bigDigitBuilder.Append("73167176531330624919225119674426574742355349194934");
            bigDigitBuilder.Append("96983520312774506326239578318016984801869478851843");
            bigDigitBuilder.Append("85861560789112949495459501737958331952853208805511");
            bigDigitBuilder.Append("12540698747158523863050715693290963295227443043557");
            bigDigitBuilder.Append("66896648950445244523161731856403098711121722383113");
            bigDigitBuilder.Append("62229893423380308135336276614282806444486645238749");
            bigDigitBuilder.Append("30358907296290491560440772390713810515859307960866");
            bigDigitBuilder.Append("70172427121883998797908792274921901699720888093776");
            bigDigitBuilder.Append("65727333001053367881220235421809751254540594752243");
            bigDigitBuilder.Append("52584907711670556013604839586446706324415722155397");
            bigDigitBuilder.Append("53697817977846174064955149290862569321978468622482");
            bigDigitBuilder.Append("83972241375657056057490261407972968652414535100474");
            bigDigitBuilder.Append("82166370484403199890008895243450658541227588666881");
            bigDigitBuilder.Append("16427171479924442928230863465674813919123162824586");
            bigDigitBuilder.Append("17866458359124566529476545682848912883142607690042");
            bigDigitBuilder.Append("24219022671055626321111109370544217506941658960408");
            bigDigitBuilder.Append("07198403850962455444362981230987879927244284909188");
            bigDigitBuilder.Append("84580156166097919133875499200524063689912560717606");
            bigDigitBuilder.Append("05886116467109405077541002256983155200055935729725");
            bigDigitBuilder.Append("71636269561882670428252483600823257530420752963450");

            var bigDigit = bigDigitBuilder.ToString();

            int lengthOfWindow = 13;

            string textWindow = bigDigit.Substring(0, lengthOfWindow);
            long sumOfWindow = 1;
            long bestSum = sumOfWindow;
            int barrier = bigDigit.Length - lengthOfWindow;
            int index = 0;

            while (index < barrier)
            {
                foreach (char t in textWindow) { sumOfWindow *= int.Parse(t.ToString()); }
                if (sumOfWindow > bestSum)
                {
                    bestSum = sumOfWindow;
                }
                index++;
                textWindow = bigDigit.Substring(index, lengthOfWindow);
                sumOfWindow = 1;
            }

            return bestSum;
        }

        /*
         * A Pythagorean triplet is a set of three natural numbers, a < b < c, for which,
         * a² + b² = c²
         * For example, 3² + 4² = 9 + 16 = 25 = 5².
         * There exists exactly one Pythagorean triplet for which a + b + c = 1000.
         * Find the product abc.
         */
        public static long SpecialPythagoreanTriplet()
        {
            for (int prem = 0; prem < 1000; prem++)
            {
                for (int deux = 0; deux < 1000; deux++)
                {
                    for (int trio = 0; trio < 1000; trio++)
                    {
                        if (!(prem < deux && deux < trio)) { continue; }
                        if (prem + deux + trio != 1000) { continue; }
                        if (Utils.IsAPythagoreanTriplet(prem, deux, trio)) { return prem * deux * trio; }
                    }
                }
            }
            return 0;
        }

        /*
         * The sum of the primes below 10 is 2 + 3 + 5 + 7 = 17.
         * Find the sum of all the primes below two million.
         */
        public static long SummationOfPrimes()
        {
            ulong result = 0;

            var candidates = Utils.FindPrimes(2000000, new ulong[] { 0 });
            Array.ForEach(candidates, prime => result += prime);

            return (long)result;
        }

        /*
         * In the 20×20 grid below, four numbers along a diagonal line have been marked in red.
         *          08,02,22,97,38,15,00,40,00,75,04,05,07,78,52,12,50,77,91,08
         *          49,49,99,40,17,81,18,57,60,87,17,40,98,43,69,48,04,56,62,00
         *          81,49,31,73,55,79,14,29,93,71,40,67,53,88,30,03,49,13,36,65
         *          52,70,95,23,04,60,11,42,69,24,68,56,01,32,56,71,37,02,36,91
         *          22,31,16,71,51,67,63,89,41,92,36,54,22,40,40,28,66,33,13,80
         *          24,47,32,60,99,03,45,02,44,75,33,53,78,36,84,20,35,17,12,50
         *          32,98,81,28,64,23,67,10,26,38,40,67,59,54,70,66,18,38,64,70
         *          67,26,20,68,02,62,12,20,95,63,94,39,63,08,40,91,66,49,94,21
         *          24,55,58,05,66,73,99,26,97,17,78,78,96,83,14,88,34,89,63,72
         *          21,36,23,09,75,00,76,44,20,45,35,14,00,61,33,97,34,31,33,95
         *          78,17,53,28,22,75,31,67,15,94,03,80,04,62,16,14,09,53,56,92
         *          16,39,05,42,96,35,31,47,55,58,88,24,00,17,54,24,36,29,85,57
         *          86,56,00,48,35,71,89,07,05,44,44,37,44,60,21,58,51,54,17,58
         *          19,80,81,68,05,94,47,69,28,73,92,13,86,52,17,77,04,89,55,40
         *          04,52,08,83,97,35,99,16,07,97,57,32,16,26,26,79,33,27,98,66
         *          88,36,68,87,57,62,20,72,03,46,33,67,46,55,12,32,63,93,53,69
         *          04,42,16,73,38,25,39,11,24,94,72,18,08,46,29,32,40,62,76,36
         *          20,69,36,41,72,30,23,88,34,62,99,69,82,67,59,85,74,04,36,16
         *          20,73,35,29,78,31,90,01,74,31,49,71,48,86,81,16,23,57,05,54
         *          01,70,54,71,83,51,54,69,16,92,33,48,61,43,52,01,89,19,67,48
         * The product of these numbers is 26 × 63 × 78 × 14 = 1788696.
         * What is the greatest product of four adjacent numbers in the same direction (up, down, left, right, or diagonally) in the 20×20 grid?
         */
        public static long LargestProductInGrid()
        {
            var grid = new int[,]
            {
                {08, 02, 22, 97, 38, 15, 00, 40, 00, 75, 04, 05, 07, 78, 52, 12, 50, 77, 91, 08},
                {49, 49, 99, 40, 17, 81, 18, 57, 60, 87, 17, 40, 98, 43, 69, 48, 04, 56, 62, 00},
                {81, 49, 31, 73, 55, 79, 14, 29, 93, 71, 40, 67, 53, 88, 30, 03, 49, 13, 36, 65},
                {52, 70, 95, 23, 04, 60, 11, 42, 69, 24, 68, 56, 01, 32, 56, 71, 37, 02, 36, 91},
                {22, 31, 16, 71, 51, 67, 63, 89, 41, 92, 36, 54, 22, 40, 40, 28, 66, 33, 13, 80},
                {24, 47, 32, 60, 99, 03, 45, 02, 44, 75, 33, 53, 78, 36, 84, 20, 35, 17, 12, 50},
                {32, 98, 81, 28, 64, 23, 67, 10, 26, 38, 40, 67, 59, 54, 70, 66, 18, 38, 64, 70},
                {67, 26, 20, 68, 02, 62, 12, 20, 95, 63, 94, 39, 63, 08, 40, 91, 66, 49, 94, 21},
                {24, 55, 58, 05, 66, 73, 99, 26, 97, 17, 78, 78, 96, 83, 14, 88, 34, 89, 63, 72},
                {21, 36, 23, 09, 75, 00, 76, 44, 20, 45, 35, 14, 00, 61, 33, 97, 34, 31, 33, 95},
                {78, 17, 53, 28, 22, 75, 31, 67, 15, 94, 03, 80, 04, 62, 16, 14, 09, 53, 56, 92},
                {16, 39, 05, 42, 96, 35, 31, 47, 55, 58, 88, 24, 00, 17, 54, 24, 36, 29, 85, 57},
                {86, 56, 00, 48, 35, 71, 89, 07, 05, 44, 44, 37, 44, 60, 21, 58, 51, 54, 17, 58},
                {19, 80, 81, 68, 05, 94, 47, 69, 28, 73, 92, 13, 86, 52, 17, 77, 04, 89, 55, 40},
                {04, 52, 08, 83, 97, 35, 99, 16, 07, 97, 57, 32, 16, 26, 26, 79, 33, 27, 98, 66},
                {88, 36, 68, 87, 57, 62, 20, 72, 03, 46, 33, 67, 46, 55, 12, 32, 63, 93, 53, 69},
                {04, 42, 16, 73, 38, 25, 39, 11, 24, 94, 72, 18, 08, 46, 29, 32, 40, 62, 76, 36},
                {20, 69, 36, 41, 72, 30, 23, 88, 34, 62, 99, 69, 82, 67, 59, 85, 74, 04, 36, 16},
                {20, 73, 35, 29, 78, 31, 90, 01, 74, 31, 49, 71, 48, 86, 81, 16, 23, 57, 05, 54},
                {01, 70, 54, 71, 83, 51, 54, 69, 16, 92, 33, 48, 61, 43, 52, 01, 89, 19, 67, 48}
            };

            for (int row = 1; row < 20; row++)
            {
                for (int col = 1; col < 20; col++)
                {
                    var pivot = grid[row, col];

                }
            }
        }
    }

}