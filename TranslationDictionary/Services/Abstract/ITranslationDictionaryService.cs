using System;
using System.Collections.Generic;
using System.Text;

namespace HomeworkApp.Services.Abstract
{
    public interface ITranslationDictionaryService
    {
        string Translate(string fromWord, string fromLanguage, string toLanguage);
    }
}
