using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary.Models
{
    public class LanguageGroup
    {
        public List<Language> Languages { get; set; }
        public int SelectedLanguage { get; set; }
    }
}
