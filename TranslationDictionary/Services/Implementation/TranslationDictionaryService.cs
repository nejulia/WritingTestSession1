using HomeworkApp.Repositories.Implementation;
using HomeworkApp.Services.Abstract;
using System;

namespace HomeworkApp.Services.Implementation
{
    public class TranslationDictionaryService : ITranslationDictionaryService
    {
        public TranslationDictionaryService(ITranslationDictionaryRepository repository)
        {
            _data = repository;
        }

        private ITranslationDictionaryRepository _data;

        public string Translate(string fromWord, string fromLanguage, string toLanguage)
        {
            if (string.IsNullOrEmpty(fromWord))
                throw new ArgumentNullException(nameof(fromWord));

            if (string.IsNullOrEmpty(fromLanguage))
                throw new ArgumentNullException(nameof(fromLanguage));

            if (string.IsNullOrEmpty(toLanguage))
                throw new ArgumentNullException(nameof(toLanguage));

            return _data.GetEntry(fromWord, fromLanguage, toLanguage)?.ToWord;
        }
    }
}
