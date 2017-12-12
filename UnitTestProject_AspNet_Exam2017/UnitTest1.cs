using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using WebApplication1.Services;

namespace UnitTestProject_AspNet_Exam2017
{
    [TestClass]
    public class UnitTest1
    {
        private SerialNumbersContext _serialNumbersContext;
        private SubmissionProcessor _submissionProcessor;

        [TestInitialize]
        public void TestSetup()
        {
            _serialNumbersContext = new SerialNumbersContext();
            _serialNumbersContext.CreateNewSerialNumberList();
            _submissionProcessor = new SubmissionProcessor(_serialNumbersContext);
        }

        //Test that the SerialNumberlist contains number 100
        [TestMethod]
        public void TestNumber100Exist()
        {
            int a = 100;

            bool test = _submissionProcessor.ProcessSubmission(a);

            Assert.IsTrue(test);


        }

        //Test that the SerialNumberlist does not contain number 101
        [TestMethod]
        public void TestNumber101NotExist()
        {
            int a = 101;

            bool test = _submissionProcessor.ProcessSubmission(a);

            Assert.IsFalse(test);

        }

        //Sets a SerialNumber to Used and then checks that the number is used
        [TestMethod]
        public void TestNumberIsUsed()
        {
            int number = 55;
            var updateNumber = _serialNumbersContext.GetSerialNumbersList().First(x => x.Number == number);

            updateNumber.ThisNumberUsed = 1;

            //now the boolean ThisNumberUsed is set to 1, so this Asssert should return false
            Assert.IsFalse(_submissionProcessor.ProcessSubmission(number));

        }


        [TestCleanup]
        public void TestTearDown()
        {
            _serialNumbersContext = null;
            _submissionProcessor = null;
            Assert.IsNull(_serialNumbersContext);
            Assert.IsNull(_submissionProcessor);

        }

    }
}
