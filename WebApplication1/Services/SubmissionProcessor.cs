using System.Linq;
using WebApplication1.Interfaces;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class SubmissionProcessor
    {

        private readonly ISerialNumberContext _serialNumbersContext;
        public SubmissionProcessor(ISerialNumberContext serialNumbersContext)
        {

            _serialNumbersContext = serialNumbersContext;
        }

        //checks if the number exist in the serialnumberlist and that is not used, which is equal to 0
        public bool ProcessSubmission(int number)
        {
            SerialNumbers result = _serialNumbersContext.GetSerialNumbersList().FirstOrDefault(t => t.Number == number);


            if (result != null)
            {
                return (result.ThisNumberUsed == 0);
            }

            return false;
        }


    }
}
