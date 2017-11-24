using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary_Compression
{
    class Program
    {
        static void Main(string[] args)
        {
            FileHelper f = new FileHelper();

            //Get directory of executable
            string currentDirectory = System.IO.Path.GetDirectoryName(System.Diagnostics.Process.G‌​etCurrentProcess().M‌​ainModule.FileName);

            //Look back to project directory, Double up each backslash, and add the directory for the text file
            char[] CurDirArray = currentDirectory.ToCharArray();
            currentDirectory = "";
            for(int i = 0; i <= CurDirArray.Length - 10; i++)
            {
                currentDirectory += CurDirArray[i];
                if(CurDirArray[i] == Convert.ToChar("\\"))
                {
                    currentDirectory += "\\";
                }
            }
            currentDirectory += "files\\input.txt";

            //Open and split the file into an array
            string str = f.Open(currentDirectory);
            string[] strArray = f.Split(str);

            for( int i = 0; i < strArray.Length; i++)
            {
                Console.Write(strArray[i] + "|");
            }
            
            //Create dictionary from the array
            Dictionary<int, string> dict =  f.CreateDictionary(strArray);

            for (int i = 0; i < dict.Count; i++)
            {
                Console.WriteLine(dict.ElementAt(i));
            }

            Console.Read();
        }
    }
}
