using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileWork.Classes
{
    static class Settings
    {
        private static int counter = 0;
        public static void ReadAllFiles(FileInfo[] files, string word) 
        {
            Console.WriteLine("FILES:");
            
            foreach (var file in files)
            {
                using (FileStream fs = new FileStream(file.FullName, FileMode.Open, FileAccess.Read))
                {
                    using (StreamReader sr = new StreamReader(fs))
                    {
                        string allText = sr.ReadToEnd();

                        if (allText.Contains(word))
                        {
                            int count = 0;
                            string[] elements = allText.Split(new char[] { ' ' });
                            foreach (var el in elements)
                            {
                                if (el == word)
                                {
                                    count++;
                                }
                            }

                            if (count > 0) 
                            {
                               Console.WriteLine("=========================================");
                               Console.WriteLine(fs.Name + " | " + count + " |");
                               Console.WriteLine("=========================================");
                                Settings.counter++;
                            }


                        }
                    }
                }
            }
            Console.ReadKey();
        }

        public static void ReplaceWord(FileInfo[] files, string word) 
        {
            if (Settings.counter <= 0) 
            {
                return;
            }
            Console.Clear();
            string newWord;
            Console.Write("Write a new word or press 'Enter': ");
            newWord = Console.ReadLine();
            if (newWord.Length > 0)
            {
                foreach (var file in files)
                {

                    StreamReader sr = new StreamReader(file.FullName);
                    string allText = sr.ReadToEnd();

                    if (allText.Contains(word))
                    {
                        string[] elements = allText.Split(new char[] { ' ' });
                        sr.Dispose();
                        using (StreamWriter sw = new StreamWriter(file.FullName, false))
                        {

                            if (word.Length != 0)
                            {
                                for (int i = 0; i < elements.Length; i++)
                                {
                                    if (elements[i] == word)
                                    {
                                        elements[i] = newWord;
                                    }
                                }
                            }

                            string endStr = "";
                            for (int i = 0; i < elements.Length; i++)
                            {
                                endStr += elements[i] + " ";
                            }

                            endStr.Trim(new char[] { ' ' });

                            sw.Write(endStr);
                        }
                    }


                }
            }
        }
    }

}
