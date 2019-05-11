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
            //string eingabeFile = args[0];
            //string ausgabeFile = args[1];
            string eingabeFile = "C:\\Users\\lschubert\\source\\repos\\WoerterZaehlenUndAusgeben\\woerter.txt";
            string ausgabeFile = "C:\\Users\\lschubert\\source\\repos\\WoerterZaehlenUndAusgeben\\ergebnis.txt";
            //string eingabeFile = "C:\\Users\\lschubert\\Documents"
            List<string> woerterListe = new List<string>();
            List<int> zaehlListe = new List<int>();
            ReadList(eingabeFile, ausgabeFile, woerterListe, zaehlListe);
    }

        public static void ReadList(string file, string ausgabeFile, List<string> woerterListe, List<int> zaehlListe)
        {
            StreamReader reader = new StreamReader(file, System.Text.Encoding.Default);
            string wort;
            while((wort = reader.ReadLine()) != null)
            {
               string wortGeändert = AlterString(wort);
                if(!woerterListe.Contains(wortGeändert))
                {
                    woerterListe.Add(wortGeändert);
                    zaehlListe.Add(1);
                } else
                {
                    int position = woerterListe.IndexOf(wortGeändert);
                    zaehlListe[position]++;
                }
            }
            PrintList(ausgabeFile, woerterListe, zaehlListe);
        }

        public static string AlterString(string wort)
        {
           string wortTemp =  wort.ToLower();
            string wortFinal = null;
            string[] umlaute = { "ä", "ö", "ü" };
            string[] umgewandelt = { "ae", "oe", "ue" };
                for (int i = 0; i < 3; i++)
                {
                    wortTemp = wortTemp.Replace(umlaute[i], umgewandelt[i]);
                }
                wortFinal = wortTemp;
            return wortFinal;
        }

        public static void PrintList(string file, List<string> woerterListe, List<int> zaehlerListe)
        {
            StreamWriter writer = new StreamWriter(file);
             for(int i = 0; i < woerterListe.Count; i++)
             {
                 writer.WriteLine(woerterListe[i] + " " + zaehlerListe[i]);
             }
            writer.Close();
            writer.Dispose();
        }
    }
}
