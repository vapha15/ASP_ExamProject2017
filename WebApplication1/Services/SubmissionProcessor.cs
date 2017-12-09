using System.Linq;
using WebApplication1.Interfaces;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class SubmissionProcessor
    {
        ///  private readonly ISerialNumberChecker _serialNumberChecker;
        private readonly ISerialNumberContext _serialNumbersContext;
        public SubmissionProcessor(ISerialNumberContext serialNumbersContext)
        {
            //serialNumberChecker = serialNumberChecker;
            _serialNumbersContext = serialNumbersContext;
        }

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
