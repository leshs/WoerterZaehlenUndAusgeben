using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoerterZaehlenUndAusgeben
{
    class Program
    {
        static void Main(string[] args)
        {
            string eingabeFile = args[0];
            string ausgabeFile = args[1];
            List<string> woerterListe = new List<string>();
            List<int> zaehlListe = new List<int>();
            ReadList(eingabeFile, ausgabeFile, woerterListe, zaehlListe);
    }

        public static void ReadList(string file, string ausgabeFile, List<string> woerterListe, List<int> zaehlListe)
        {
            StreamReader reader = new StreamReader(file);
            string wort;
            while((wort = reader.ReadLine()) != null)
            {
                wort = AlterString(wort);
                if(!woerterListe.Contains(wort))
                {
                    woerterListe.Add(wort);
                    zaehlListe.Add(1);
                } else
                {
                    int position = woerterListe.IndexOf(wort);
                    zaehlListe[position]++;
                }
            }
            PrintList(ausgabeFile, woerterListe, zaehlListe);
        }

        public static string AlterString(string wort)
        {
            wort.ToLower();
            string[] umlaute = { "ä", "ö", "ü" };
            string[] umgewandelt = { "ae", "oe", "ue" };
            if (wort.Contains("ä") || wort.Contains("ö") || wort.Contains("ü"))) {
                for (int i = 0; i < 3; i++)
                {
                    wort.Replace(umlaute[i], umgewandelt[i]);
                }
            }
            return wort;
        }

        public static void PrintList(string file, List<string> woerterListe, List<int> zaehlerListe)
        {
            StreamWriter writer = new StreamWriter(file);
            writer.WriteLine("hkhkJ");
            for(int i = 0; i < woerterListe.Count; i++)
            {
                writer.WriteLine(woerterListe[i] + " " + zaehlerListe[i]);
            }
        }
    }
}
