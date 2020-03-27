using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RemoveExtraBlanksLibrary;

namespace RemoveExtraBlanksTests
{
    [TestClass]
    public class StringProcessorTests
    {
        [TestMethod]
        public void TestRemoveExtraBlanks()
        {
            StringProcessor stringProcessor = new StringProcessor();
            Assert.AreEqual("", stringProcessor.RemoveExtraBlanks("  "));
            Assert.AreEqual("abcd", stringProcessor.RemoveExtraBlanks(" abcd\t "));
            Assert.AreEqual("абвгд", stringProcessor.RemoveExtraBlanks(" абвгд \t"));
            Assert.AreEqual("абв гд", stringProcessor.RemoveExtraBlanks("абв гд"));
            Assert.AreEqual("абв гд", stringProcessor.RemoveExtraBlanks("абв  гд"));
            Assert.AreEqual("абв\tcd", stringProcessor.RemoveExtraBlanks("абв\t  cd "));
        }
    }
}
