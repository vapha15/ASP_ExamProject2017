using WebApplication1.Interfaces;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class SubmissionProcessor
    {
        private readonly ISerialNumberChecker _serialNumberChecker;

        public SubmissionProcessor(ISerialNumberChecker serialNumberChecker)
        {
            _serialNumberChecker = serialNumberChecker;
        }

        public bool ProcessSubmission(SerialNumbers number)
        {
            bool succes = _serialNumberChecker.SerialNumberValidation(number);

            return succes;
        }
    }
}
