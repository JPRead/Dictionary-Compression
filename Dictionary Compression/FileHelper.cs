using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace Dictionary_Compression
{
    class FileHelper
    {
        public FileHelper()
        {
        }

        public string Open(string directory)
        {
            StreamReader s = new StreamReader(directory);
            string str = "";
            while (!s.EndOfStream)
            {
                str += (char)s.Read();
            }
            return str;
        }

        public string[] Split(string str)
        {
            //Put within [] all the characters to split at
            return Regex.Split(str, @"([?<= .,'!?])");
        }

        public Dictionary<int, string> CreateDictionary(string[] strArray)
        {
            Dictionary<int, string> dict = new Dictionary<int, string>();
            int index = 1;
            dict.Add(0, strArray[0]);
            for (int i = 1; i < strArray.Length; i++)
            {
                if (!dict.ContainsValue(strArray[i]))
                {
                    dict.Add(index, strArray[i]);
                    index++;
                }
            }

            return dict;
        }
    }
}
