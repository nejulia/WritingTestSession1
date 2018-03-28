using HomeworkApp.Repositories.Implementation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tests.Repository
{
    [TestClass]
    public class TranslationDictionaryRepositoryTest
    {
        [TestMethod]
        public void AddEntry_IfNotPresent()
        {
            string _fromWord = "house";
            string _fromLanguage = "English";
            string _toWord = "haus";
            string _toLanguage = "German";
            var repository = new TranslationDictionaryRepository();
            repository.AddEntry(_fromWord, _fromLanguage, _toWord, _toLanguage);

            var firstItem = repository.Items.Single();

            Assert.AreEqual(_fromWord, firstItem.FromWord);
            Assert.AreEqual(_fromLanguage, firstItem.FromLanguage);
            Assert.AreEqual(_toWord, firstItem.ToWord);
            Assert.AreEqual(_toLanguage, firstItem.ToLanguage);
        }

        [TestMethod]
        [DataRow("", "German", "cat", "English")]
        [DataRow("Der Kater", "", "cat", "English")]
        [DataRow("Der Kater", "German", "", "English")]
        [DataRow("Der Kater", "German", "cat", "")]
        public void AddEntry_WithInvalidParameter(string fromWord, string fromLanguage, string toWord, string toLanguage)
        {
            var repository = new TranslationDictionaryRepository();

            Assert.ThrowsException<ArgumentNullException>(() => repository.AddEntry(fromWord, fromLanguage, toWord, toLanguage));
        }
    }
}
