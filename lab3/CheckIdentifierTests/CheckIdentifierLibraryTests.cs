using Microsoft.VisualStudio.TestTools.UnitTesting;
using CheckIdentifierLibrary;

namespace CheckIdentifierTests
{
    [TestClass]
    public class CheckIdentifierLibraryTests
    {
        [TestMethod]
        public void TestDetermineIdentifier()
        {
            Assert.AreEqual(false, CheckIdentifier.IsIdentifier(""));
            Assert.AreEqual(false, CheckIdentifier.IsIdentifier("1"));
            Assert.AreEqual(false, CheckIdentifier.IsIdentifier("1a"));
            Assert.AreEqual(true, CheckIdentifier.IsIdentifier("a"));
            Assert.AreEqual(true, CheckIdentifier.IsIdentifier("a1"));
            Assert.AreEqual(true, CheckIdentifier.IsIdentifier("A"));
        }
    }
}
