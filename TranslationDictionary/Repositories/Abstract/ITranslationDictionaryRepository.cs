using HomeworkApp.Data;
using HomeworkApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeworkApp
{
    public interface ITranslationDictionaryRepository
    {
        void AddEntry(string fromWord, string fromLanguage, string toWord, string toLanguage);

        void Remove(string word, string language);

        void Clear();

        TranslationDictionary GetEntry(string fromWord, string fromLanguage, string toLanguage);
    }
}
