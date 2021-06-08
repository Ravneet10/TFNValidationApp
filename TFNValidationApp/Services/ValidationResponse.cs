using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TFNValidationApp.Services
{
    public class ValidationResponse
    {
        public bool IsConsecutiveSequence {get; set;}
        public bool IsValidNumber { get; set; }
    }
}
