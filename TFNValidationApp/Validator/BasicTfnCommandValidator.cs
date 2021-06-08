using FluentValidation;

namespace TFNValidationApp.Validator
{
    public class BasicTfnCommandValidator : BaseValidator<ValidationTFN>
    {
        public BasicTfnCommandValidator()
        {
            RuleFor(r => r.tfnNumber)
                .NotEmpty()
                .WithMessage("Tax File Number is required.")
                .Length(8, 9)
                .WithMessage("Tax File Number can be 8 or 9 digits only.");
        }
       
    }

}
