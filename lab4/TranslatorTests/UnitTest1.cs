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
        public void TestDictionaryFindSuccess()
        {
            Assert.Equal("ÿ", dictionary.Find("i"));
        }
        [Fact]
        public void TestDictionaryFindFail()
        {
            Assert.Null(dictionary.Find("undefined word"));
        }
    }
}
