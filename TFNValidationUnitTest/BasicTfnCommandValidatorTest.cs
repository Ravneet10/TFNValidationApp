using FluentValidation.TestHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TFNValidationApp;
using TFNValidationApp.Services;
using TFNValidationApp.Validator;

namespace TFNValidationUnitTest
{
    [TestClass]
    public class BasicTfnCommandValidatorTest
    {

        private readonly BasicTfnCommandValidator _validator;
        private readonly ValidationTFN _command;

        public BasicTfnCommandValidatorTest()
        {

            _validator = new BasicTfnCommandValidator();
            _command = new ValidationTFN() { };
        }

        [TestMethod]
        public void PassingInvalidCommand_ThrowsException()
        {
            _validator.ShouldHaveValidationErrorFor(l => l.tfnNumber, _command);
        }

        [TestMethod]
        public void PassingInvalidDescriptionCommand_ThrowsNoException()
        {
            _command.tfnNumber = "13454323";
            _validator.ShouldNotHaveValidationErrorFor(l => l.tfnNumber, _command);
        }
        [TestMethod]
        public void PassingInvalidDescriptionWithNineDigitsCommand_ThrowsNoException()
        {
            _command.tfnNumber = "134543235";
            _validator.ShouldNotHaveValidationErrorFor(l => l.tfnNumber, _command);
        }
        [TestMethod]
        public void PassingInvalidDescriptionWithInvalidLimitDigitsCommand_ThrowsException()
        {
            _command.tfnNumber = "1345432357";
            _validator.ShouldHaveValidationErrorFor(l => l.tfnNumber, _command);
        }

       
    }
}
