using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TFNValidationApp.Services
{
    public abstract class Validation
    {
        protected readonly TFNValidationEngine _engine;

        public Validation(TFNValidationEngine engine)
        {
            _engine = engine;
        }

        public abstract ValidationResponse ValidateTfnNumber(string tfnNumber);
    }
}
