using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using HomeworkApp.Data;
using HomeworkApp.Models;

namespace HomeworkApp.Repositories.Implementation
{
    public class TranslationDictionaryRepository : ITranslationDictionaryRepository
    {
        public TranslationDictionaryRepository()
        {
            _storage = new Storage<TranslationDictionary>();
        }

        private readonly Storage<TranslationDictionary> _storage;
        public IReadOnlyCollection<TranslationDictionary> Items => _storage.Table.AsReadOnly();

        public void AddEntry(string fromWord, string fromLanguage, string toWord, string toLanguage)
        {
            if(string.IsNullOrEmpty(fromWord))
                throw new ArgumentNullException(nameof(fromWord));

            if (string.IsNullOrEmpty(fromLanguage))
                throw new ArgumentNullException(nameof(fromLanguage));

            if (string.IsNullOrEmpty(toWord))
                throw new ArgumentNullException(nameof(toWord));

            if (string.IsNullOrEmpty(toLanguage))
                throw new ArgumentNullException(nameof(toLanguage));

            var entry = new TranslationDictionary()
            {
                FromWord = fromWord,
                FromLanguage = fromLanguage,
                ToWord = toWord,
                ToLanguage = toLanguage
            };

            if (_storage.Table.Any(x => x.FromWord == fromWord && x.FromLanguage == fromLanguage && x.ToLanguage == toLanguage))
                throw new Exception("Dictionary already have translation for this word.");
            
            _storage.Table.Add(entry);
        }

        public void Clear()
        {
            _storage.Table.Clear();
        }

        public void Remove(string word, string language)
        {
            var entry = _storage.Table.SingleOrDefault(x => x.FromWord == word && x.FromLanguage == language);
            if (entry == null)
                throw new Exception("Dictionary doesn't have such translation.");

            _storage.Table.Remove(entry);
        }

        public TranslationDictionary GetEntry(string fromWord, string fromLanguage, string toLanguage)
        {
            return _storage.Table.SingleOrDefault(x => x.FromWord == fromWord &&
                                                  x.FromLanguage == fromLanguage &&
                                                  x.ToLanguage == toLanguage);
        }
    }
}
