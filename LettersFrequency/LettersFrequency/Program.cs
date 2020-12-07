using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LettersFrequency
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Эта программа посчитает кол-во символов в тексте и выдаст вам полную статистику по символам");
            Console.WriteLine("Пожалуйста, укажите путь текстового файла, который нужно обработать");
            Console.WriteLine();
            var pathText = Console.ReadLine();
            Console.WriteLine("Пожалуйста, укажите где сохранить файл с результатами");
            Console.WriteLine();
            var pathRes = Console.ReadLine();
            GetLetters(pathText, pathRes);
        }

        static void GetLetters(string pathText, string pathRes)
        {
            var fileStream = new FileStream(pathText, FileMode.Open);
            var bytes = new byte[fileStream.Length];
            fileStream.Read(bytes, 0, bytes.Length);
            var text = System.Text.Encoding.UTF8.GetString(bytes).Replace(" ", "").ToLower();
            GetDict(text, pathRes);
        }

        static void GetDict(string text, string pathRes)
        {
            var dict = new Dictionary<char, int>();
            foreach(var letter in text)
            {
                if (dict.ContainsKey(letter))
                    dict[letter]++;
                else if (Char.GetUnicodeCategory(letter) == System.Globalization.UnicodeCategory.LowercaseLetter)
                    dict.Add(letter, 1);
            }
            Print(dict, pathRes);
        }

        static void Print(Dictionary<char, int> dict, string pathRes)
        {
            var file = new FileStream(pathRes + @"\Res.txt", FileMode.Create);
            file.Close();
            var writer = new StreamWriter(pathRes + @"\Res.txt", false);
            foreach(var letter in dict)
            {
                writer.Write($"{letter.Key} => {letter.Value}\n");
                writer.Flush();
            } 
            for(var i = 0; i < 5; i++)
            {
                if (dict.Count == 0)
                    break;
                var maxValue = dict.Max(x => x.Value);
                var maxKey = dict.Where(x => x.Value == maxValue).FirstOrDefault().Key;
                Console.WriteLine($"{maxKey} => {maxValue}");
                dict.Remove(maxKey);
            }
        }
    }
}
