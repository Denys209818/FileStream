using FileWork.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileWork
{
    class Program
    {
        static void Main()
        {
            string word;
            string path;

            Console.Write("Enter word: ");
            word = Console.ReadLine();

            Console.Write("Enter path to file: ");
            path = Console.ReadLine();

            DirectoryInfo directory = new DirectoryInfo(path);

            FileInfo[] files = 
                (directory.GetFiles()
                .Where((FileInfo f) => { return f.Extension == ".txt"; })
                .Select(f=>f))
                .ToArray();

            Console.Clear();

            Settings.ReadAllFiles(files, word);
            Settings.ReplaceWord(files, word);
        }
    }
}
