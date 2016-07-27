using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace kerekadat
{
    class Program
    {
        static void Main(string[] args)
        {
            if (File.Exists("kerekadat.txt"))
            {
                Console.WriteLine("fájl feldolgozása");
                
                StreamReader r = new StreamReader("kerekadat.txt");
                StreamWriter w;
                string date = DateTime.Now.Date.ToShortDateString();
                string hh = DateTime.Now.Hour.ToString();
                string mm = DateTime.Now.Minute.ToString();
                string ss = DateTime.Now.Second.ToString();
                string path = date + " " + hh + "." + mm + "." + ss;
                Directory.CreateDirectory(path);
                
                
                
                while (!r.EndOfStream)
                {
                    string svv = "";
                    string[] sv = r.ReadLine().Split(';');
                     svv=sv[sv.Length - 1].Substring(9,5);
                    
                    w = new StreamWriter(path+"\\"+sv[sv.Length - 1].Substring(4, 5) + svv+".txt",true);
                    string ssv = "";
                    ssv += sv[0];
                    for (int i = 1; i < sv.Length; i++)
                    {
                        ssv +=";"+ sv[i];
                    }
                    w.WriteLine(ssv);
                    w.Close();
                     
                }
                r.Close();
                Console.WriteLine("a fájl feldolgozása megtörtént.");
            }
            else
            {
                Console.WriteLine("fájl nem található!");
            }
            Console.ReadKey();
        }
    }
}
