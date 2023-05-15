using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proba
{
    public class YandexDictionaryResponse
    {
        [JsonProperty("def")]
        public List<DictionaryEntry> Definitions { get; set; }

        public class DictionaryEntry
        {
            [JsonProperty("text")]
            public string Text { get; set; }

            [JsonProperty("pos")]
            public string PartOfSpeech { get; set; }

            [JsonProperty("tr")]
            public List<Translation> Translations { get; set; }

            [JsonProperty("fl")]
            public string PastForm { get; set; }



            public class Translation
            {
                [JsonProperty("text")]
                public string Text { get; set; }

                [JsonProperty("pos")]
                public string PartOfSpeech { get; set; }

                [JsonProperty("syn")]
                public List<Synonym> Synonyms { get; set; }

                [JsonProperty("mean")]
                public List<Mean> Means { get; set; }

                [JsonProperty("ex")]
                public List<Example> Examples { get; set; }
            }

            public class Synonym
            {
                [JsonProperty("text")]
                public string Text { get; set; }

                [JsonProperty("pos")]
                public string PartOfSpeech { get; set; }
            }

            public class Mean
            {
                [JsonProperty("text")]
                public string Text { get; set; }
            }

            public class Example
            {
                [JsonProperty("text")]
                public string Text { get; set; }
            }
        }
    }


}

