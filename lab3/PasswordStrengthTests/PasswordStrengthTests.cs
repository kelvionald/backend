using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PasswordStrengthLibrary;

namespace PasswordStrengthTests
{
    [TestClass]
    public class PasswordStrengthTests
    {
        private PasswordStrength passwordStrength;

        public PasswordStrengthTests()
        {
            this.passwordStrength = new PasswordStrength();
        }

        [TestMethod]
        public void TestGetSafetyByLength()
        {
            Assert.AreEqual(0, passwordStrength.GetSafetyByLength(""));
            Assert.AreEqual(4, passwordStrength.GetSafetyByLength("a"));
        }

        [TestMethod]
        public void TestGetSafetyByDigitsCount()
        {
            Assert.AreEqual(0, passwordStrength.GetSafetyByDigitsCount("a"));
            Assert.AreEqual(1, passwordStrength.GetSafetyByDigitsCount("1"));
            Assert.AreEqual(2, passwordStrength.GetSafetyByDigitsCount("11"));
        }

        [TestMethod]
        public void TestGetSafetyByUpperCaseChars()
        {
            Assert.AreEqual(0, passwordStrength.GetSafetyByUpperCaseChars("a"));
            Assert.AreEqual(0, passwordStrength.GetSafetyByUpperCaseChars("A"));
            Assert.AreEqual(2, passwordStrength.GetSafetyByUpperCaseChars("aA"));
        }

        [TestMethod]
        public void TestGetSafetyByLowerCaseChars()
        {
            Assert.AreEqual(0, passwordStrength.GetSafetyByLowerCaseChars("a"));
            Assert.AreEqual(0, passwordStrength.GetSafetyByLowerCaseChars("A"));
            Assert.AreEqual(2, passwordStrength.GetSafetyByLowerCaseChars("aA"));
        }

        [TestMethod]
        public void TestGetSafetyByContainsOnlyLetters()
        {
            Assert.AreEqual(-1, passwordStrength.GetSafetyByContainsOnlyLetters("a"));
            Assert.AreEqual(-2, passwordStrength.GetSafetyByContainsOnlyLetters("aA"));
            Assert.AreEqual(0, passwordStrength.GetSafetyByContainsOnlyLetters("aA1"));
        }

        [TestMethod]
        public void TestGetSafetyByContainsOnlyDigits()
        {
            Assert.AreEqual(0, passwordStrength.GetSafetyByContainsOnlyDigits("a"));
            Assert.AreEqual(0, passwordStrength.GetSafetyByContainsOnlyDigits("a1"));
            Assert.AreEqual(-1, passwordStrength.GetSafetyByContainsOnlyDigits("1"));
            Assert.AreEqual(-2, passwordStrength.GetSafetyByContainsOnlyDigits("11"));
        }

        [TestMethod]
        public void TestGetSafetyByRepeateChars()
        {
            Assert.AreEqual(0, passwordStrength.GetSafetyByRepeateChars("a"));
            Assert.AreEqual(-2, passwordStrength.GetSafetyByRepeateChars("aa"));
            Assert.AreEqual(-3, passwordStrength.GetSafetyByRepeateChars("aaa"));
            Assert.AreEqual(-2, passwordStrength.GetSafetyByRepeateChars("aab"));
            Assert.AreEqual(-4, passwordStrength.GetSafetyByRepeateChars("aabb"));
        }

        [TestMethod]
        public void TestCalcSafety()
        {
            Assert.AreEqual(4, passwordStrength.CalcSafety("1"));
            Assert.AreEqual(3, passwordStrength.CalcSafety("a"));

            Assert.AreEqual(46, passwordStrength.CalcSafety("1234qwerr"));
        }
    }
}
