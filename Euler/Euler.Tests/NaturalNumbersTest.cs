// <copyright file="NaturalNumbersTest.cs">Copyright ©  2017</copyright>

using NUnit.Framework;


namespace Euler.Tests
{
    /// <summary>This class contains parameterized unit tests for NaturalNumbers</summary>
    [TestFixture]
    public sealed class NaturalNumbersTest
    {
        [Test]
        public void SumMultiplesOf3And5Under1000Test()
        {
            long expected = 0;
            for (int index = 1; index < 1001; index++) { expected += index; }
            long result = NaturalNumbers.SumMultiplesOf3And5Under1000();
            Assert.That(result < expected);
        }

        [Test]
        public void SumEvenFibonacciUnder4MillionTest()
        {
            long result = NaturalNumbers.SumEvenFibonacciUnder4Million();
            Assert.That(result > 0);
        }

        [Test]
        public void LargestPrimeFactorOf600851475143Test()
        {
            long result = NaturalNumbers.LargestPrimeFactorOf600851475143();
            Assert.That(result > 0);
        }

        [Test]
        public void IsAPalindromTest()
        {
            bool result = Utils.IsAPalindrom("100001");
            Assert.That(result);
        }

        [Test]
        public void LargestPalindromicFromThreeDigitsTest()
        {
            int result = NaturalNumbers.LargestPalindromicFromThreeDigits();
            Assert.That(result > 0);
        }

        [Test]
        public void SmallestEvenlyDivisibleTest()
        {
            int result = NaturalNumbers.SmallestEvenlyDivisibleByAllTwentyFirstNumbers();
            Assert.That(result > 0);
        }

        [Test]
        public void SumSquareDifferenceTest()
        {
            long result = NaturalNumbers.SumSquareDifference();
            Assert.That(result > 0);
        }

        [Test]
        public void TenThousandOnethPrimeTest()
        {
            ulong result = NaturalNumbers.TenThousandOnethPrime();
            Assert.That(result > 0);
        }

        [Test]
        public void GreatestAdjacentSerieInBigDigitTest()
        {
            long result = NaturalNumbers.GreatestAdjacentSerieInBigDigit();
            Assert.That(result > 0);
        }

        [Test]
        public void SpecialPythagoreanTripletTest()
        {
            long result = NaturalNumbers.SpecialPythagoreanTriplet();
            Assert.That(result > 0);
        }

        [Test]
        public void SummationOfPrimesTest()
        {
            long result = NaturalNumbers.SummationOfPrimes();
            Assert.That(result > 0);
        }

        [Test]
        public void LargestProductInGridTest()
        {
            long result = NaturalNumbers.LargestProductInGrid();
            Assert.That(result > 0);
        }

        [Test]
        public void HighlyDivisibleTriangleTest()
        {
            long result = NaturalNumbers.HighlyDivisibleTriangle();
            Assert.That(result > 0);
        }

        [Test]
        public void SumOfBigChunkTest()
        {
            long result = NaturalNumbers.SumOfBigChunk();
            Assert.That(result > 0);
        }

        [Test]
        public void LongestCollatzTest()
        {
            int result = NaturalNumbers.LongestColatzSequenceUnderMilion();
            Assert.That(result > 0);
        }

        [Test]
        public void LatticePathsTest()
        {
            long result = NaturalNumbers.LatticePathsNumber();
            Assert.That(result > 0);
        }

        [Test]
        public void PowerDigitSumTest()
        {
            long result = NaturalNumbers.PowerDigitSum();
            Assert.That(result > 0);
        }
    }
}
