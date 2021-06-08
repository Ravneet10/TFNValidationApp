using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using TFNValidationApp.Services;

namespace TFNValidationUnitTest
{
    [TestClass]
    public class BasicTfnValidationServiceTest
    {
        private readonly BasicTfnValidationService _service;

        public BasicTfnValidationServiceTest()
        {

            _service = new BasicTfnValidationService(new TFNValidationEngine());
        }

        [TestMethod]
        public void SendInvalidSequencedTFNumber()
        {
            var result = _service.ValidateTfnNumber("12345678");
            Assert.IsFalse(result.IsValidNumber);
            Assert.IsTrue(result.IsConsecutiveSequence);
        }

        [TestMethod]
        public void SendInvalidTFNumber()
        {
            var result = _service.ValidateTfnNumber("14682497");
            Assert.IsFalse(result.IsValidNumber);
            Assert.IsFalse(result.IsConsecutiveSequence);
        }
        [TestMethod]
        public void CheckValidityOfTFNumber()
        {
            var result = _service.ValidateTfnNumber("648188499");
            Assert.IsTrue(result.IsValidNumber);
            Assert.IsFalse(result.IsConsecutiveSequence);
        }
        [TestMethod]
        public void CheckValidityOfEightDigitTFNumber()
        {
            var result = _service.ValidateTfnNumber("37118660");
            Assert.IsTrue(result.IsValidNumber);
            Assert.IsFalse(result.IsConsecutiveSequence);
        }
        [TestMethod]
        public void InvalidOfEightDigitTFNumber()
        {
            var result = _service.ValidateTfnNumber("37118629");
            Assert.IsFalse(result.IsValidNumber);
            Assert.IsFalse(result.IsConsecutiveSequence);
        }

        [TestMethod]
        public void ExceptionHandlingForTenDigitTFNumber()
        {
            var result = _service.ValidateTfnNumber("3711862986");
            Assert.IsFalse(result.IsValidNumber);
            Assert.IsFalse(result.IsConsecutiveSequence);
        }

    }
}
