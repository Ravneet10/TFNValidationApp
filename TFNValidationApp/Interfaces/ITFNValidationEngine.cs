using System;
using TFNValidationApp.Services;

namespace TFNValidationApp.Interfaces
{
    public interface ITFNValidationEngine
    {
        public ValidationResponse ValidateTFNNumber(string validationType,string tfnNumber);
    }
}
