using Microsoft.AspNetCore.Mvc;
using TFNValidationApp.Interfaces;
using TFNValidationApp.Validator;

namespace TFNValidationApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TfnValidateController : ControllerBase
    {
        private readonly ITFNValidationEngine _validationEngine;
        public TfnValidateController(ITFNValidationEngine validationEngine)
        {
            _validationEngine = validationEngine;
        }

        [HttpPost]
        public IActionResult Post([FromBody] ValidationTFN validationTFNCommand)
        {
            var validationResults = new BasicTfnCommandValidator().Validate(validationTFNCommand);
            if (!validationResults.IsValid)
            {
                var errorResponse = new ValidationErrorsResponse(validationResults);
                return BadRequest(errorResponse);
            }
            var result = _validationEngine.ValidateTFNNumber(validationTFNCommand.validationType, validationTFNCommand.tfnNumber);
            return Ok(result);
        }

    }
}
