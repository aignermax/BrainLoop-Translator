using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TranslationWCFService.Model
{
    public class DummyTranslationXMLGenerator
    {
        public TranslationDictionary mytransdict;
        public DummyTranslationXMLGenerator()
        {
            mytransdict = new TranslationDictionary();
        }
        
        /// <summary>
        /// generates the XML file, that serves as the translation database
        /// </summary>
        /// <param name="path">the full path with filename and extension to save the file.</param>
        public void GenerateDummyData(string path)
        {
            if (String.IsNullOrWhiteSpace(path)) return;
            // create folderstructure if needed
            string folderPath = Path.GetDirectoryName(path);
            if (String.IsNullOrWhiteSpace(folderPath) == false)
            {
                Directory.CreateDirectory(folderPath);
            }
            // create language and save it to path
            mytransdict.Languages = new Language[] {
                new Language("german", new Word[] {
                    new Word("hallo", "hello"),
                    new Word("der", "the"),
                    new Word("sein", "to be"),
                    new Word("ist", "be"),
                    new Word("zu", "to"),
                    new Word("von", "of"),
                    new Word("und", "and"),
                    new Word("ich", "i"),
                    new Word("ein", "a"),
                    new Word("in", "in"),
                    new Word("dass", "that"),
                    new Word("habe", "have"),
                    new Word("es", "it"),
                    new Word("für", "for"),
                    new Word("nicht", "not"),
                    new Word("an", "on"),
                    new Word("baum", "tree"),
                    new Word("auto", "car"),
                    new Word("haus", "house")
                }),
                new Language("english", new Word[] {
                    new Word("hello", "hello"),
                    new Word("the", "the"),
                    new Word("to be", "to be"),
                    new Word("be", "be"),
                    new Word("to", "to"),
                    new Word("of", "of"),
                    new Word("and", "and"),
                    new Word("i", "i"),
                    new Word("a", "a"),
                    new Word("in", "in"),
                    new Word("that", "that"),
                    new Word("have", "have"),
                    new Word("it", "it"),
                    new Word("for", "for"),
                    new Word("not", "not"),
                    new Word("on", "on"),
                    new Word("tree", "tree"),
                    new Word("car", "car"),
                    new Word("house", "house")
                }),
                new Language("french", new Word[] {
                    new Word("bonjour", "hello"),
                    new Word("le", "the"),
                    new Word("son", "to be"),
                    new Word("est", "be"),
                    new Word("à", "to"),
                    new Word("à partir de", "off"),
                    new Word("et", "and"),
                    new Word("me", "i"),
                    new Word("a", "a"),
                    new Word("dans", "in"),
                    new Word("que", "that"),
                    new Word("ont", "have"),
                    new Word("it", "it"),
                    new Word("pour", "for"),
                    new Word("pas", "not"),
                    new Word("à", "on"),
                    new Word("arbre", "tree"),
                    new Word("voiture", "car"),
                    new Word("maison", "house")
                })
                };
            mytransdict.Save(path);
        }
    }
}
