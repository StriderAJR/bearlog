using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using Bearlog.Web.Models;

namespace Bearlog.Web.Services
{
    public class TextService
    {
        private readonly string[] _endSentence = {".", "!", "?", "...", "?..", "!.."};



        public string[] ParseText(string line, string[] simbols)
        {
            List<string> collection = new List<string>();

            int indexOfFirstSimbol;
            int temp = 0;

            while (true)
            {
                indexOfFirstSimbol = line.Length;
                for (int i = 0; i < simbols.Length; i++)
                {
                    temp = line.IndexOf(simbols[i], StringComparison.Ordinal);
                    if (temp != -1)
                        if (temp < indexOfFirstSimbol) indexOfFirstSimbol = temp;
                }

                if (indexOfFirstSimbol == -1 || line.Length == 0) break;
                collection.Add(line.Substring(0, indexOfFirstSimbol + 1));
                line = line.Remove(0, indexOfFirstSimbol + 1);
            }
            
            return collection.ToArray();

        }

        public string[] ParseText(byte[] file)
        {
            string s = System.Text.Encoding.UTF8.GetString(file, 0, file.Length);

            return ParseText(s, _endSentence);
        }

    }
}