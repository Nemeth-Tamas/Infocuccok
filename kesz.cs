using System;
using System.IO;
using System.Collections.Generic;

namespace valasztas
{
    class Kepviselo
    {
        public string vnev, unev, korzet, part;
        public int szavazat;
    }

    class valasztas
    {
        static List<Kepviselo> kepviselokLista = new List<Kepviselo>();
        static int n;
        static float osszesszavazat = 0;
        const float valasztokszama = 12345;

        static void Main(string[] args)
        {
            Feladat1();
            Console.WriteLine();
            Feladat2();
            Console.WriteLine();
            Feladat3();
            Console.WriteLine();
            Feladat4();
            Console.WriteLine();
            Feladat5();
            Console.WriteLine();
            Feladat6();
            Console.WriteLine();
            Feladat7();
            Console.ReadKey();
        }

        static void Feladat1()
        {
            Console.WriteLine("1. feladat. Az adatok beolvasása");
            n = 0;
            using (StreamReader sr = new StreamReader("szavazatok.txt"))
            {
                string sor = "";
                while ((sor = sr.ReadLine()) != null)
                {
                    string[] sordarabok = sor.Split(' ');
                    Kepviselo kepvis = new Kepviselo();
                    kepvis.korzet = sordarabok[0];
                    kepvis.szavazat = int.Parse(sordarabok[1]);
                    kepvis.vnev = sordarabok[2];
                    kepvis.unev = sordarabok[3];
                    kepvis.part = sordarabok[4];
                    kepviselokLista.Add(kepvis);
                    n++;
                }
            }
        }

        static void Feladat2()
        {
            Console.WriteLine($"2. feladat. A helyhatósági választáson {n} képviselőjelölt indult.");
        }

        static void Feladat3()
        {
            Console.WriteLine("3. feladat. Egy képviselő");
            Console.Write("vezetékneve=");
            string veznev = Console.ReadLine();
            Console.Write("utóneve=");
            string utonev = Console.ReadLine();
            bool szerepel = false;

            foreach (var kepvis in kepviselokLista)
            {

                if (kepvis.vnev == veznev && kepvis.unev == utonev)
                {
                    Console.WriteLine($"{veznev} {utonev} képviselőjelölt {kepvis.szavazat} szavazatot kapott.");
                    szerepel = true;
                }
            }

            if (!szerepel) Console.WriteLine("Ilyen nevű képviselőjelölt nem szerepel a nyilvántartásban!");
        }

        static void Feladat4()
        {
            foreach (var kepvis in kepviselokLista)
            {
                osszesszavazat += kepvis.szavazat;
            }

            float array = osszesszavazat / valasztokszama * 100;
            Console.WriteLine($"4. feladat. A választáson {osszesszavazat} állampolgár, a jogosultak {array.ToString("F2")}%-a vett részt.");
        }

        static void Feladat5()
        {
            float gyep = 0;
            float hep = 0;
            float tisz = 0;
            float zep = 0;
            float flen = 0;

            foreach (var kepvis in kepviselokLista)
            {
                if (kepvis.part == "GYEP") gyep += kepvis.szavazat;
                if (kepvis.part == "HEP") hep += kepvis.szavazat;
                if (kepvis.part == "TISZ") tisz += kepvis.szavazat;
                if (kepvis.part == "ZEP") zep += kepvis.szavazat;
                if (kepvis.part == "-") flen += kepvis.szavazat;
            }

            Console.WriteLine($"5. feladat. Az egyes pártokra leadott szavazatok aránya:");
            Console.WriteLine($"Gyümölcsevők Pártja = {(100 * gyep / osszesszavazat).ToString("F2")}%");
            Console.WriteLine($"Húsevők Pártja = {(100 * hep / osszesszavazat).ToString("F2")}%");
            Console.WriteLine($"Tejivók Szövetsége = {(100 * tisz / osszesszavazat).ToString("F2")}%");
            Console.WriteLine($"Zöldségevők Pártja = {(100 * zep / osszesszavazat).ToString("F2")}%");
            Console.WriteLine($"Független jelöltek = {(100 * flen / osszesszavazat).ToString("F2")}%");
        }

        static void Feladat6()
        {
            Console.WriteLine("6. feladat. A legtöbb szavazatot kapott képviselő(k):");
            int max = kepviselokLista[0].szavazat;

            foreach (var kepvis in kepviselokLista)
            {
                if (max < kepvis.szavazat)
                {
                    max = kepvis.szavazat;
                }
            }

            foreach (var kepvis in kepviselokLista)
            {
                if (kepvis.szavazat == max)
                {
                    Console.Write($"{kepvis.vnev} {kepvis.unev} ");
                    if (kepvis.part == "-")
                    {
                        Console.WriteLine("független");
                    }
                    else
                    {
                        Console.WriteLine(kepvis.part);
                    }
                }
            }
        }

        static void Feladat7()
        {
            Console.WriteLine("7. feladat. A választás eredményének kiírása");
            using (FileStream fs = new FileStream("kepviselok.txt", FileMode.Create))
            using (StreamWriter sw = new StreamWriter(fs))
            {
                for (int i = 1; i <= 8; i++)
                {
                    bool elso = true;
                    int max = 0;
                    int maxh = 0;
                    for (int j = 0; j < n; j++)
                    {
                        if (kepviselokLista[j].korzet == i.ToString())
                        {
                            if (elso)
                            {
                                maxh = j;
                                max = kepviselokLista[j].szavazat;
                                elso = false;
                            }
                            else
                            {
                                if (kepviselokLista[j].szavazat > max)
                                {
                                    maxh = j;
                                    max = kepviselokLista[j].szavazat;
                                }
                            }
                        }
                    }

                    sw.Write($"{i.ToString()} {kepviselokLista[maxh].vnev} {kepviselokLista[maxh].unev} ");
                    if (kepviselokLista[maxh].part == "-")
                    {
                        sw.WriteLine("fuggetlen");
                    }

                    else
                    {
                        sw.WriteLine(kepviselokLista[maxh].part);
                    }

                }
                sw.Flush();
            }
        }
    }
}
