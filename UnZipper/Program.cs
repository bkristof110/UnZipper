using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;

namespace UnZipper
{
    class Program
    {
        static void Main(string[] args)
        {
            string fromFolder = args.Length < 1 ? Directory.GetCurrentDirectory() : args[0];
            string toFolder = args.Length < 2 ? Directory.GetCurrentDirectory() : args[1];

            var files = Directory.GetFiles(fromFolder,"*.zip",SearchOption.TopDirectoryOnly).Select(x => Path.GetFileName(x));
            foreach (string item in files)
            {               
                string filepath = fromFolder + @"\" + item;
                string dirPath = Directory.CreateDirectory(Path.GetFileNameWithoutExtension(toFolder + @"\" + item)).FullName;
                try
                {
                    ZipFile.ExtractToDirectory(filepath, dirPath);
                }
                catch (Exception ee)
                {
                    ConsoleColor cColor = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("ERROR: " + ee.Message);
                    Console.ForegroundColor = cColor;
                    Environment.Exit(1);
                }
                Console.WriteLine(item + " unzipped!");
            }

            Console.WriteLine("Everything is done!");
        }
    }
}
