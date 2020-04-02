using System;
using Xunit;
using Translator.Data.Models;

namespace TranslatorTests
{
    public class DictionaryTests
    {
        private Dictionary dictionary;
        public DictionaryTests()
        {
            dictionary = new Dictionary("../../../../Translator/dictionaries/en-ru.txt");
        }
        [Fact]
        public void TestDictionaryEnRuFindSuccess()
        {
            Assert.Equal("я", dictionary.Find("i"));
        }
        [Fact]
        public void TestDictionaryEnRuFindFail()
        {
            Assert.Null(dictionary.Find("undefined word"));
        }
        [Fact]
        public void TestDictionaryRuEnFindSuccess()
        {
            Assert.Equal("i", dictionary.Find("я"));
        }
    }
}
