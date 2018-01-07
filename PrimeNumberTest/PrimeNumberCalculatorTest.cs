using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PrimeNumberCalculation;

namespace PrimeNumberTest
{
    [TestClass]
    public class PrimeNumberCalculatorTest
    {
        private PrimeNumberCalculator calc_;

        [TestInitialize]
        public void Initialize()
        {
            calc_ = new PrimeNumberCalculator();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CheckPrime_NegativeNumberGiven_ShouldThrowArgumentException()
        {
            // Arrange
            long numberToCheck = -1;

            // Act 
            calc_.IsPrime(numberToCheck);

            // Assert
            // Nothing to assert -> Exception should be thrown
        }

        [TestMethod]
        public void CheckPrime_SmallPrimesGiven_ShouldReturnTrue()
        {
            // Arrange
            long[] numbersToCheck = new[] { 2L, 3L, 5L, 7L, 11L, 13L, 17L, 19L, 23L, 29L, 31L, 37L };

            // Act
            bool result = true;
            foreach (var num in numbersToCheck)
                result = result && calc_.IsPrime(num);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CheckPrime_BigPrimeGiven_ShouldReturnTrue()
        {
            // Arrange
            long bigPrime = long.MaxValue;

            // Act
            bool result = calc_.IsPrime(bigPrime);

            // Assert
            Assert.IsTrue(result);
        }
    }
}
