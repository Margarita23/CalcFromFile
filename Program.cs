using System;
using System.IO;
using System.Text.RegularExpressions;

namespace CalcFromFile
{
    class Program
    {
        static void Main(string[] args)
        {
            try {
                string text = "";
                using (StreamReader file =  new StreamReader(@"Solution.txt"))
                {
                string line;

                while ((line = file.ReadLine()) != null)
                {  
                    string[] example = line.Split(" ");
                    try{
                        string res = myResolve(example[0], example[2], example[1]);
                        string exy = line.Insert(line.IndexOf("=") + 1, " " + res);
                        text += exy + "\n";
                        
                    }catch(Exception){
                        Console.WriteLine("Проверьте правильное написание примеров");
                        break;
                    }
                    
                }

                file.Close(); 
                System.IO.File.WriteAllText(@"Solution.txt", text);
            }
            } catch (FileNotFoundException){
                Console.WriteLine("Файл Solution.txt не найден.");
            }

        }

//функция проверки количества примеров
        public static int exampleCount(StreamReader file)
        {
            int count = 0;
            string line;
            while ((line = file.ReadLine()) != null )
            {
                count++;
            }
            return count;
        }

//функция решения примера в строке
        public static string myResolve(string a, string b, string userChar)
        {
            double aa = double.Parse(a);
            double bb = double.Parse(b);
            switch (userChar){
                case "+" :
                    return String.Format("{0}", aa + bb);
                case "-" :
                    return String.Format("{0}", aa - bb);
                case "*" :
                    return String.Format("{0}", aa * bb);
                case ":" :
                    return String.Format("{0:F2}", aa / bb);
                default :
                    return "Не могу решить!";
            }
        }
    }
}
