using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TFNValidationApp.Interfaces;

namespace TFNValidationApp.Services
{
    public class TFNValidationEngine: ITFNValidationEngine
    {
        public ValidationResponse ValidateTFNNumber(string validationType, string tfnNumber)
        {
            TFNValidationFactory factory = new TFNValidationFactory();
            var validator = factory.Create(validationType, this);
            var result = validator?.ValidateTfnNumber(tfnNumber);
            return result;
        }
    }
}
