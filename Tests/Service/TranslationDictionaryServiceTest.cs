using HomeworkApp.Repositories.Implementation;
using HomeworkApp.Services.Implementation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests.Service
{
    [TestClass]
    public class TranslationDictionaryServiceTest
    {
        [TestMethod]
        [DataRow("cat", "English", "German")]
        public void Translate_IfNotPresent(string fromWord, string fromLanguage, string toLanguage)
        {
            string _fromWord = "house";
            string _fromLanguage = "English";
            string _toWord = "haus";
            string _toLanguage = "German";
            var repository = new TranslationDictionaryRepository();
            repository.AddEntry(_fromWord, _fromLanguage, _toWord, _toLanguage);

            var service = new TranslationDictionaryService(repository);

            Assert.IsNull(service.Translate(fromWord, fromLanguage, toLanguage));
        }

        [TestMethod]
        [DataRow("house", "English", "German")]
        public void Translate_IfPresent(string fromWord, string fromLanguage, string toLanguage)
        {
            string _fromWord = "house";
            string _fromLanguage = "English";
            string _toWord = "haus";
            string _toLanguage = "German";
            var repository = new TranslationDictionaryRepository();
            repository.AddEntry(_fromWord, _fromLanguage, _toWord, _toLanguage);

            var service = new TranslationDictionaryService(repository);

            Assert.AreEqual(_toWord, service.Translate(fromWord, fromLanguage, toLanguage));
        }
    }
}
