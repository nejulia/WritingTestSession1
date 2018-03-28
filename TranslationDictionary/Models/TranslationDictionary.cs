using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HomeworkApp.Models
{
    public class TranslationDictionary
    {
        public string FromWord { get; set; }
        public string FromLanguage { get; set; }
        public string ToWord { get; set; }
        public string ToLanguage { get; set; }
    }
}
