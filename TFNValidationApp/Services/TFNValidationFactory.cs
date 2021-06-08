using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TFNValidationApp.Services
{
    public class TFNValidationFactory
    {
            public Validation Create(string validationType, TFNValidationEngine engine)
            {
                try
                {
                    return (Validation)Activator.CreateInstance(
                        Type.GetType($"TFNValidationApp.Services.{validationType}ValidationService"),
                            new object[] { engine });
                }
                catch
                {
                    return null;
                }
            }
        
    }
}
