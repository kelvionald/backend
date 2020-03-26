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
            CheckIdentifier checkIdentifier = new CheckIdentifier();

            Assert.IsFalse(checkIdentifier.IsIdentifier(""));
            Assert.IsTrue(checkIdentifier.IsEmpty());

            Assert.IsFalse(checkIdentifier.IsIdentifier("1"));
            Assert.IsFalse(checkIdentifier.IsEmpty());
            Assert.AreEqual(0, checkIdentifier.GetBadIndex());

            Assert.IsFalse(checkIdentifier.IsIdentifier("1a"));
            Assert.AreEqual(0, checkIdentifier.GetBadIndex());

            Assert.IsTrue(checkIdentifier.IsIdentifier("a"));
            Assert.IsTrue(checkIdentifier.IsIdentifier("a1"));
            Assert.IsTrue(checkIdentifier.IsIdentifier("A"));
        }
    }
}
