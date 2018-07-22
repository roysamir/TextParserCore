using CustomParser.Model;
using CustomParser.Model.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomParser
{
    public class CustomCSVParser
    {
        public static string ToCsv(string textValue)
        {
            string retValue = String.Empty;
            if(!String.IsNullOrEmpty(textValue))
            {
                StringBuilder strBuilder = null;
                Text textObj = UtiliMethods.populateObject(textValue);
                var lstHeader = getHeaders(textObj);
                var lstSentence = getRows(textObj);

                if (lstHeader?.Count > 0 && lstSentence?.Count > 0)
                {
                    strBuilder = new StringBuilder();
                    lstHeader.ForEach(x => strBuilder.Append(x));
                    strBuilder.AppendLine();
                    lstSentence.ForEach(x => strBuilder.AppendLine(x));
                }
                retValue= strBuilder?.ToString();
            }
            return retValue;
        }

        /// <summary>
        /// Get CSV Headers
        /// </summary>
        /// <param name="textObj"></param>
        /// <returns></returns>
        private static List<string> getHeaders(Text textObj)
        {
            List <string> lstHeaders= null;
            string commaSeparator = ",";
            string spaceSeparator = " ";
            if (textObj?.Sentence?.Count>0)
            {
                var propertNames=textObj.Sentence[0].GetType().GetProperties().ToList().Select(x=>x.Name).ToList();
                var maxWordCount=textObj.Sentence.Max(x => x.Word.Count);
                if(propertNames?.Count>0 && maxWordCount>0)
                {
                    lstHeaders = new List<string>();
                    for (var count = 1; count <= maxWordCount; count++)
                    {
                        lstHeaders.Add(commaSeparator + propertNames[0]+ spaceSeparator + count.ToString());
                    }
                }
                
            }
            return lstHeaders;
        }

        /// <summary>
        /// Get CSV rows
        /// </summary>
        /// <param name="textObj"></param>
        /// <returns></returns>
        private static List<string> getRows(Text textObj)
        {
            List<string> lstRows = null;
            string spaceSeparator = " ";
            string commaSeparator = ",";
            if (textObj?.Sentence?.Count > 0)
            {
                lstRows = new List<string>();
                var propertNames = textObj.GetType().GetProperties().ToList().Select(x => x.Name).ToList();
                if(propertNames?.Count>0)
                {
                    foreach (var sentence in textObj.Sentence)
                    {
                        string rowText = propertNames[0] + spaceSeparator + Convert.ToString(textObj.Sentence.IndexOf(sentence) + 1) + commaSeparator + String.Join(commaSeparator, sentence.Word.Select(x => x));
                        lstRows.Add(rowText);
                    }
                }
            }
            return lstRows;
        }
        
    }
}
