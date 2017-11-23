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
            Assert.That(result >0);
        }

        [Test]
        public void LargestPrimeFactorOf600851475143Test()
        {
            long result = NaturalNumbers.LargestPrimeFactorOf600851475143();
            Assert.That(result>0);
        }
    }
}
