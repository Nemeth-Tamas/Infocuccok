using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace valasztas2
{
    class adatok
    {
        public int kerulet;
        public int szavazatok;
        public string vezeteknev;
        public string utonev;
        public string part;

    }
    class Program
    {
        static int indulok;
        static List<adatok> adatokList = new List<adatok>();
        static összszavazat;

        static void fajbeolvasas()
        {
            Console.WriteLine("1.Feladat.");
            indulok = 0;
            using(StreamReader sr = new StreamReader("szavazatok.txt"))
            {
                string sor = "";
                while ((sor = sr.ReadLine())!= null)
                {
                    string[] darabok = sor.Split(' ');
                    adatok adat = new adatok();
                    adat.kerulet = int.Parse(darabok[0]);
                    adat.szavazatok = int.Parse(darabok[1]);
                    adat.vezeteknev = darabok[2];
                    adat.utonev = darabok[3];
                    adat.part = darabok[4];
                    adatokList.Add(adat);
                    indulok++;
                }
            }
        }

        static void jeloltek()
        {
            Console.WriteLine("3.Feladat.");
            Console.WriteLine("Adja meg egy képviselő vezetéknevét!");
            string vnev = Console.ReadLine();
            Console.WriteLine("Adja meg egy képviselő utónevét.");
            string unev = Console.ReadLine();
            bool szerepel = false;
            foreach (var adat in adatokList)
            {
                if (adat.vezeteknev == vnev && adat.utonev == unev)
                {
                    Console.WriteLine($"{vnev} {unev} {adat.szavazatok} szavazatot kapott.");
                    szerepel = true;
                }
                
            }
            if(!szerepel) Console.WriteLine("Ilyen nevű képviselőjelölt nem szerepel a nyilvántartásban!");

        }
        static void arany()
        {
            Console.WriteLine("4.Feladat.");
            összszavazat = 0;
            foreach (var adat in adatokList)
            {
                összszavazat += adat.szavazatok;
            }
            Console.WriteLine($"A választáson {összszavazat} állampolgár vett részt és a jogosultak {(float)összszavazat/12345*100}%-a vett részt.");

        }
        static void partok()
        {
            Console.WriteLine("5.Feladat.");
            float gyep = 0;
            float hep = 0;
            float tisz = 0;
            float zep = 0;
            float flen = 0;
            foreach (var adat in adatokList)
            {
                if (adat.part == "GYEP")
                {
                    gyep += adat.szavazatok;
                }

                if (adat.part == hep)
                {
                    gyep += hep.szavazatok;
                }

                if (adat.part == tisz)
                {
                    gyep += tisz.szavazatok;
                }

                 if (adat.part == zep)
                {
                    gyep += zep.szavazatok;
                }

                if (adat.part == -)
                {
                    -+=
                }
            }
           

        }


       


        static void Main(string[] args)
        {
            fajbeolvasas();
            Console.WriteLine("2.Feladat");
            Console.WriteLine($"A helyhatósági választáson {indulok} képviselőjelölt indult.");
            jeloltek();
            arany();
        }
    }
}
