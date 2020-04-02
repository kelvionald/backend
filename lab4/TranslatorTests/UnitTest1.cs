using System;
using Xunit;
using Translator.Data.Models;

namespace TranslatorTests
{
    public class UnitTest1
    {
        private Dictionary dictionary;
        public UnitTest1()
        {
            dictionary = new Dictionary("../../../../Translator/dictionaries/en-ru.txt");
        }
        [Fact]
        public void TestDictionaryEnRuFindSuccess()
        {
            Assert.Equal("ÿ", dictionary.Find("i"));
        }
        [Fact]
        public void TestDictionaryEnRuFindFail()
        {
            Assert.Null(dictionary.Find("undefined word"));
        }
        [Fact]
        public void TestDictionaryRuEnFindSuccess()
        {
            Assert.Equal("i", dictionary.Find("ÿ"));
        }
    }
}
