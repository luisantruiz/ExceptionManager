using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ExceptionManager.Tests
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void ShouldGetDeepestException()
        {
            var innerException = new Exception("There was another error");
            var exception = new Exception("There was an error", innerException);

            Exception exceptionReturned = ExceptionManager.GetDeepestException(exception);
            Assert.AreEqual(exceptionReturned.Message, innerException.Message);
        }

        [TestMethod]
        public void ShouldGetDeepestExceptionMessage()
        {
            var innerException = new Exception("There was another error");
            var exception = new Exception("There was an error", innerException);

            string messageReturned = ExceptionManager.GetDeepestExceptionMessage(exception);
            Assert.AreEqual(messageReturned, innerException.Message);
        }

        [TestMethod]
        public void ShouldConcatAllInnerExceptionMessages()
        {
            var innerException = new Exception("There was another error");
            var exception = new Exception("There was an error", innerException);

            string messageReturned = ExceptionManager.Concatener.ConcatAllInnerExceptionMessages(exception);
            Assert.AreEqual(messageReturned, $"{exception.Message}, {innerException.Message}");
        }

        [TestMethod]
        public void ShouldConcatAllInnerExceptionMessagesWithSeparator()
        {
            var innerException = new Exception("There was another error");
            var exception = new Exception("There was an error", innerException);

            string messageReturned = ExceptionManager.Concatener.ConcatAllInnerExceptionMessages(exception, " |");
            Assert.AreEqual(messageReturned, $"{exception.Message} | {innerException.Message}");
        }
    }
}
