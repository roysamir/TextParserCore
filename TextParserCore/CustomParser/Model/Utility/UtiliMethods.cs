using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;


namespace CustomParser.Model.Utility
{
    internal class UtiliMethods
    {
        internal static Text populateObject(string textValue)
        {
            Text state = null;
            if (!String.IsNullOrEmpty(textValue))
            {
                string statement = textValue.Replace(System.Environment.NewLine, " ");
                string[] sentenceSeparator = { "." };
                string[] wordSeparator = { " ", ",", ";", "\"", "'","=" };
                
                Regex regexAplhaNumeric = new Regex("^[a-zA-Z0-9]*$");
                var sentenceList = statement.Split(sentenceSeparator, StringSplitOptions.RemoveEmptyEntries);
                if (sentenceList?.Length > 0)
                {
                    state = new Text { Sentence = new List<Sentence>() };

                    foreach (var sentence in sentenceList)
                    {
                        Sentence sentences = new Sentence();
                        var wordList = sentence.Split(wordSeparator, StringSplitOptions.RemoveEmptyEntries);
                        if (wordList?.Length > 0)
                        {
                            var convertedList = wordList.Where(x => regexAplhaNumeric.IsMatch(x)).Select(y => y.Trim()).ToList();
                            if (convertedList?.Count > 0)
                            {
                                convertedList.Sort();
                                sentences.Word = convertedList;
                                state.Sentence.Add(sentences);
                            }

                        }
                    }
                }
            }
            return state;
        }
    }
}
