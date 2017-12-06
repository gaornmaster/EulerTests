using System;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace Euler
{
    internal static class Utils
    {
        public static long Fibonacci(int iteration)
        {
            if (iteration <= 0) { return 0; }
            if (iteration == 1) { return 1; }
            if (iteration == 2) { return 2; }
            return Fibonacci(iteration - 2) + Fibonacci(iteration - 1);

            //round( Phi^n / √5 ) Phi = (1+√5) / 2

        }

        [NotNull]
        public static long[] PrimesFactorsOf(long numberToFactorize)
        {
            var factors = new HashSet<long>();
            var sieve = 2;
            while (numberToFactorize > 1)
            {
                while (numberToFactorize % sieve == 0)
                {
                    factors.Add(sieve);
                    numberToFactorize /= sieve;
                }
                sieve = sieve + 1;
                if (sieve * sieve <= numberToFactorize) { continue; }
                if (numberToFactorize > 1) { factors.Add(numberToFactorize); }
            }

            var result = new long[factors.Count];
            factors.CopyTo(result);
            return result;
        }

        public static bool IsAPalindrom([NotNull] string toEvaluate)
        {
            if (toEvaluate.Length % 2 != 0) { return false; }
            string left = toEvaluate.Substring(0, toEvaluate.Length / 2);

            string futureRight = toEvaluate.Substring(toEvaluate.Length / 2);
            char[] right = new char[futureRight.Length];
            futureRight.CopyTo(0, right, 0, futureRight.Length);
            Array.Reverse(right);

            for (int index = 0; index < left.Length; index++) { if (left[index] != right[index]) { return false; } }
            return true;
        }

        public static bool IsEvenlyDivisibleBy(int candidate, [NotNull] IEnumerable<int> factors)
        {
            foreach (var oneFactor in factors) { if (candidate % oneFactor != 0) { return false; } }
            return true;
        }

        [NotNull]
        public static unsafe ulong[] FindPrimes(ulong limit, [NotNull] ulong[] alreadyKnownPrimes)
        {
            var tampon = new List<ulong>();
            var isPrime = new bool[limit + 1];
            var lowerLimit = Math.Sqrt(limit);
            ulong largestValue = Math.Max(alreadyKnownPrimes[alreadyKnownPrimes.Length - 1], 1);

            Array.Sort(alreadyKnownPrimes);

            fixed (bool* pp = isPrime)
            {
                bool* pp1 = pp;
                tampon.AddRange(Array.FindAll(alreadyKnownPrimes, item => item <= limit));
                if (limit <= largestValue) { return tampon.ToArray(); }
                for (ulong x = 1; x <= lowerLimit; x++)
                for (ulong y = 1; y <= lowerLimit; y++)
                {
                    var n = 4 * x * x + y * y;
                    if (n <= limit && (n % 12 == 1 || n % 12 == 5)) pp1[n] ^= true;

                    n = 3 * x * x + y * y;
                    if (n <= limit && n % 12 == 7) pp1[n] ^= true;

                    n = 3 * x * x - y * y;
                    if (x > y && n <= limit && n % 12 == 11) pp1[n] ^= true;
                }

                for (ulong n = 5; n <= lowerLimit; n++)
                    if (pp1[n])
                    {
                        var s = n * n;
                        for (ulong k = s; k <= limit; k += s) pp1[k] = false;
                    }

                if (largestValue < 3)
                {
                    tampon.Add(2);
                    tampon.Add(3);
                }
                for (ulong n = 5; n <= limit; n += 2) if (pp1[n]) tampon.Add(n);
            }


            ulong[] sortie = new ulong[tampon.Count];
            new HashSet<ulong>(tampon).CopyTo(sortie);
            Array.Sort(sortie);
            sortie = Array.FindAll(sortie, item => item != 0);
            return sortie;
        }

        public static bool IsAPythagoreanTriplet(int prem, int deux, int trio)
        {
            var first = prem * prem;
            var second = deux * deux;
            var third = trio * trio;
            if (first + second == third) { return true; }
            return false;
        }
    }
}