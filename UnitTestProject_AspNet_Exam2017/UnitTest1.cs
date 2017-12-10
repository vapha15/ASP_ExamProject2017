using Microsoft.VisualStudio.TestTools.UnitTesting;
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


        [TestMethod]
        public void TestNumber100Exist()
        {
            int a = 100;

            bool test = _submissionProcessor.ProcessSubmission(a);

            Assert.IsTrue(test);


        }

        [TestMethod]
        public void TestNumber101NotExist()
        {
            int a = 101;

            bool test = _submissionProcessor.ProcessSubmission(a);

            Assert.IsFalse(test);

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
