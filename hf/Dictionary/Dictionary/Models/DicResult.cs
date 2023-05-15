using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary.Models
{

    /// <summary>
    /// ez egy szótár bejegyzésnek felel meg
    /// </summary>
    public class DictionaryEntry
    {
        /// <summary>
        /// magát a szót reprezentálja
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// az adott szónak a szófaját adja meg
        /// </summary>
        public string Pos { get; set; }


        /// <summary>
        /// szónak a jelentéseinek a listáját
        /// </summary>
        public List<Translation> Translations { get; set; }
    }

    /// <summary>
    /// jelentést reprezentál
    /// </summary>
    public class Translation
    {
        /// <summary>
        /// fordított szöveg
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// az adott szónak a szófaját adja meg
        /// </summary>
        public string Pos { get; set; }

        /// <summary>
        /// a szónak a különböző szinonímáinak listája
        /// </summary>
        public List<string> Synonyms { get; set; }

        /// <summary>
        /// a szónak a különböző jelentéseinek a listája
        /// </summary>
        public List<string> Meanings { get; set; }

        /// <summary>
        /// szónak példáinak a listája
        /// </summary>
        public List<Example> Examples { get; set; }
    }

    /// <summary>
    /// példát reprezentáló osztály
    /// </summary>
    public class Example
    {
        /// <summary>
        /// szónak a használatára egy példa szöveg
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// az adott nyelvnek megfelelő fordítás
        /// </summary>
        public List<Translation> Translations { get; set; }
    }
}
