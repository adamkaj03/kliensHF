using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using static proba.YandexDictionaryResponse.DictionaryEntry;

namespace proba
{
    public class DictionaryService
    {
        private readonly Uri serverUrl = new Uri("https://dictionary.yandex.net/api/v1/dicservice.json/");
        private string apiKey = "dict.1.1.20230509T064245Z.ffceac622f104a98.b7f2bf67c1128ff05c19d555efffd2aca9f25739";
        private readonly HttpClient client;

        public DictionaryService()
        {
            client = new HttpClient();
        }

        private async Task<T> GetAsync<T>(Uri uri)
        {
            var response = await client.GetAsync(uri);
            var json = await response.Content.ReadAsStringAsync();
            T result = JsonConvert.DeserializeObject<T>(json);
            return result;
        }

        public async Task<List<string>> GetLanguagesAsync()
        {
            var uri = new Uri(serverUrl, $"getLangs?key={apiKey}");
            return await GetAsync<List<string>>(uri);
        }

        public async Task<List<string>> GetSourceLanguage()
        {
            List<string> lista = await GetLanguagesAsync();
            List<string> returnList = new List<string>();
            foreach (var item in lista)
            {
                string language = item.Split('-')[0];
                if (!returnList.Contains(language))
                {
                    returnList.Add(language);
                }
            }
            return returnList;
        }

        public async Task<List<string>> GetTargetLanguage(string sourceLanguage)
        {
            List<string> lista = GetLanguagesAsync().Result;
            List<string> returnList = new List<string>();
            foreach (var item in lista)
            {

                string language = item.Split('-')[0];
                if (language.Equals(sourceLanguage))
                {
                    returnList.Add(item.Split('-')[1]);
                }
            }
            return returnList;
        }

        public async Task<List<string>> GetTranslationsAsync(string word, string sourceLanguage, string targetLanguage)
        {
            var uri = new Uri(serverUrl, $"lookup?key={apiKey}&text={word}&lang={sourceLanguage}-{targetLanguage}");
            var result = await GetAsync<YandexDictionaryResponse>(uri);
            if (result.Definitions == null)
            {
                return new List<string>();
            }

            List<string> translations = new List<string>();
            foreach (var item in result.Definitions)
            {
                foreach (var tran in item.Translations)
                {
                    translations.Add(tran.Text);
                }
            }

            return translations;
        }

        public async Task<List<string>> GetSynonims(string word, string sourceLanguage, string targetLanguage)
        {
            var uri = new Uri(serverUrl, $"lookup?key={apiKey}&text={word}&lang={sourceLanguage}-{targetLanguage}");
            var result = await GetAsync<YandexDictionaryResponse>(uri);
            if (result.Definitions == null || result.Definitions.Count == 0)
            {
                return new List<string>();
            }
            List<string> synonyms = new List<string>();
            foreach (var definition in result.Definitions)
            {
                foreach (var tr in definition.Translations)
                {
                    foreach (var syn in tr.Synonyms)
                    {
                        synonyms.Add(syn.Text);
                    }
                }
            }
            return synonyms;

        }

        public async Task<string> GetPastForm(string word, string sourceLanguage, string targetLanguage)
        {
            var uri = new Uri(serverUrl, $"lookup?key={apiKey}&text={word}&lang={sourceLanguage}-{targetLanguage}");
            var result = await GetAsync<YandexDictionaryResponse>(uri);
            if (result.Definitions == null || result.Definitions.Count == 0)
            {
                return String.Empty;
            }
            foreach (var item in result.Definitions)
            {
                return item.PastForm;
            }
            return null;

        }


    }
}

