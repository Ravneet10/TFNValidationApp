using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TFNValidationApp.Services
{
    public class BasicTfnValidationService : Validation
    {
        public BasicTfnValidationService(TFNValidationEngine engine):base(engine)
        {

        }

        public override ValidationResponse ValidateTfnNumber(string tfnNumber)
        {
            ValidationResponse response = new ValidationResponse();

            try
            {
                 int Sum = 0;
                int[] weightigFactors = new int[] { 10, 7, 8, 4, 6, 3, 5, 2, 1 };
                int[] tfnNumberArray = Array.ConvertAll(tfnNumber.ToArray(), x => (int)x - 48);
                for (int i = 0; i <= tfnNumberArray.Length - 1; i++)
                {
                    Sum += weightigFactors[i] * tfnNumberArray[i];
                }
                int remainder = Sum % 11;
                response.IsValidNumber = remainder == 0 ? true : false;
                response.IsConsecutiveSequence = isConsecutiveString(tfnNumber);
            }
            catch(Exception e)
            {
                response.IsValidNumber = false;
            }
                return response;

        }
        public bool isConsecutiveString(string str)
        {
            int start;

            int length = str.Length;

            for (int i = 0; i < length / 2; i++)
            {
                string new_str = str.Substring(0, i + 1);
                int num = int.Parse(new_str);
                start = num;
                while (new_str.Length < length)
                {
                    num++;
                    new_str = new_str + string.Join("", num);
                }
                if (new_str.Equals(str))
                    return true;
            }

            return false;
        }
    }
}

