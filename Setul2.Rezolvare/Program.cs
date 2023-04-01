using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Setul2Rezolvare
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Scrieti numarul problemei pe care doriti sa o folositi:");
            int Problema = int.Parse(Console.ReadLine());

            switch (Problema)

            {
                case 1: PB1(); break;
                case 2: PB2(); break;
                case 3: PB3(); break;
                case 4: PB4(); break;
                case 5: PB5(); break;
                case 6: PB6(); break;
                case 7: PB7(); break;
                case 8: PB8(); break;
                case 9: PB9(); break;
                case 10: PB10(); break;
                case 11: PB11(); break;
                case 12: PB12(); break;
                case 13: PB13(); break;
                case 14: PB14(); break;
                case 15: PB15(); break;
                case 16: PB16(); break;
                case 17: PB17(); break;
                default: PB18(); break;

            }
        }

        private static void PB18()
        {
            Console.WriteLine("Numarul introdus nu apartine nici unei probleme! Introduceti un nr de la 1 la 17.");
            Console.ReadKey();

        }

        private static void PB17()
        {
            //Se da o secventa de 0 si 1, unde 0 inseamna paranteza deschisa si 1 inseamna paranteza inchisa.
            //Determinati daca secventa reprezinta o secventa de paranteze corecta si, daca este,
            //determinati nivelul maxim de incuibare a parantezelor.De exemplu 0 1 0 0 1 0 1 1 este corecta
            //si are nivelul maxim de incuibare 2 pe cand 0 0 1 1 1 0 este incorecta. 
            Console.WriteLine("Introduce-ti un numar n care sa fie par.");
            int n = int.Parse(Console.ReadLine());
            if (n % 2 == 1) { Console.WriteLine("Numarul introdus nu este par! Introduce-ti un nr par."); Console.ReadKey(); return; };
            Console.WriteLine("Introduce-ti n numere care sa fie 0 sau 1  una sub alta:");
            int a = 0;
            int zero = 0, incuibare = 0, unu = 1, incuibaremax = 0;
            int aux = 0, aux1 = 0;
            for (int i = 0; i < n; i++)
            {
                a = int.Parse(Console.ReadLine());
                if (i == 0) { aux = a; }
                if (i == n - 1) { aux1 = a; }
                if (a == 0)
                {
                    incuibare++;
                    zero++;
                }
                if (a == 1)
                {
                    incuibare = 0;
                    unu++;
                }
                if (incuibare > incuibaremax)
                {
                    incuibaremax = incuibare;
                }
            }
            if (aux == 1 || aux1 == 0)
                Console.WriteLine($"Secventa este incorecta");
            else if (unu == zero && a != 0)
                Console.WriteLine($"Secventa este corecta si incuibarea maxima este {incuibaremax}");
            else
                Console.WriteLine($"Secventa este incorecta");
            Console.ReadKey();

        }

        private static void PB16()
        {
            //O <secventa bitonica rotita> este o secventa bitonica sau una ca poate fi transformata intr-o secventa bitonica
            //prin rotiri succesive (rotire = primul element devine ultimul). Se da o secventa de n numere.
            //Se cere sa se determine daca este o secventa bitonica rotita. 
            Console.WriteLine("Introduceti nr n:");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("Introduceti n numere, cate unul pe fiecare linie:");
            int x1 = int.Parse(Console.ReadLine());
            int y = 0; bool ok = true; int k = 0; int aux = 0; int yy = 0; int kk = 0; int kkk = 0;

            for (int i = 0; i < n - 1; i++)
            {
                int x2 = int.Parse(Console.ReadLine());
                if (i == 0) { aux = x1; }

                if (x1 < x2 && kkk == 1) { ok = false; }   //verificam daca e 
                if (x1 > x2 && kk == 1) { kkk = 1; }    //secventa bitonica rotita
                if (x1 < x2 && k == 1) { kk = 1; }

                if (x1 < x2 && yy == 1) { ok = false; }   //verificama daca 
                if (x1 > x2 && y == 1) { yy = 1; }          //este secventa bitonica

                if (x1 > x2 && y == 0) { k = 1; }// k=1 secventa poate fi doar bitonica rotita
                if (x1 < x2 && k == 0) { y = 1; }//y=1 secvtenta poate fi doar bitonica

                if (i == n - 2 && aux > x2 && kkk == 1) { ok = false; }//secventa nu este bit.rot deoarece ultimul nr nu e mai mare decat primul
                if (i == n - 2 && y == 1 && yy == 0) { ok = false; }//secventa doar creste, deci nu poate fi bitonica
                if (i == n - 2 && k == 1 && kk == 0) { ok = false; }//secventa doar descreste, deci nu poate fi bitonica
                x1 = x2;

            }
            if (ok) { Console.WriteLine("Secventa este bitonica rotita."); }
            else { Console.WriteLine("Secventa nu este bitonica rotita."); }
            Console.ReadKey();
        }

        private static void PB15()
        {
            //O secventa bitonica este o secventa de numere care incepe monoton crescator si continua monoton descrecator.
            //De ex. 1,2,2,3,5,4,4,3 este o secventa bitonica. Se da o secventa de n numere.Sa se determine daca este bitonica.
            Console.WriteLine("Introduceti nr n:");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("Introduceti n numere, cate unul pe fiecare linie:");
            int x1 = int.Parse(Console.ReadLine());
            int y = 0; bool ok = true; int k = 0;
            for (int i = 0; i < n - 1; i++)
            {
                int x2 = int.Parse(Console.ReadLine());
                if (x1 == x2) { continue; }
                if (x1 < x2) { k = 1; }
                if (x1 > x2 && k == 0) { ok = false; }
                if (x1 < x2 && k == 1 && y == 1) { ok = false; }
                if (x1 > x2 && k == 1) { y = 1; }
                x1 = x2;

            }
            if (ok) { Console.WriteLine("Secventa este bitonica."); }
            else { Console.WriteLine("Secventa nu este bitonica."); }
            Console.ReadKey();
        }

        private static void PB14()
        {
            //O <secventa monotona rotita> este o secventa de numere monotona sau poate fi transformata intr-o secventa montona
            //prin rotiri succesive. Determinati daca o secventa de n numere este o secventa monotona rotita. 
            Console.WriteLine("Introduceti numarul n:");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("Introduceti n numere una sub alta:");
            int k = 0; int y = 0; bool ok = true; int aux = 0; bool oy = true;
            int x1 = int.Parse(Console.ReadLine());
            for (int i = 1; i < n; i++)
            {
                int x2 = int.Parse(Console.ReadLine());
                if (i == 0) { aux = x1; }
                if (i == n - 1 && aux < x2 && y == 1) { oy = false; }
                if (i == n - 1 && aux > x2 && k == 1) { ok = false; }
                if (x1 > x2 && y == 1) { oy = false; }
                if (x1 < x2 && k == 1) { ok = false; }
                if (x1 > x2) { y = 1; }
                if (x1 < x2) { k = 1; }
                x1 = x2;
            }
            if (ok || oy) { Console.WriteLine("Secventa este monoton rotita."); }
            else { Console.WriteLine("Secventa nu este monoton rotita."); Console.ReadKey(); }
            Console.ReadKey();
        }
        private static void PB13()
        {
            //O < secventa crescatoare rotita> este o secventa de numere care este in ordine crescatoare sau poate fi transformata
            //intr - o secventa in ordine crescatoare prin rotiri succesive(rotire cu o pozitie spre stanga = toate elementele
            //se muta cu o pozitie spre stanga si primul element devine ultimul).Determinati daca o secventa de n numere este o
            //secventa crescatoare rotita.
            Console.WriteLine("Introduceti nr n:");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("Introduceti n numere, cate unul pe fiecare linie:");
            int x1 = int.Parse(Console.ReadLine());
            int aux = 0; int y = 0; bool ok = true;
            for (int i = 0; i < n - 1; i++)
            {
                int x2 = int.Parse(Console.ReadLine());
                if (i == 0) { aux = x1; }
                if (i == n - 2 && aux < x2 && y == 1) { ok = false; }
                if (x1 > x2 && y == 1) { ok = false; }
                if (x1 > x2) { y = 1; }
                x1 = x2;

            }
            if (ok) { Console.WriteLine("Secventa este crescatoare rotita."); }
            else { Console.WriteLine("Secventa nu este crescatoare rotita."); }
            Console.ReadKey();

        }

        private static void PB12()
        {
            //Cate grupuri de numere consecutive diferite de zero sunt intr-o secventa de n numere.
            //Considerati fiecare astfel de grup ca fiind un cuvant, zero fiind delimitator de cuvinte.
            //De ex. pentru secventa 1, 2, 0, 3, 4, 5, 0, 0, 6, 7, 0, 0 raspunsul este 3. 
            Console.WriteLine($"Introduceti numarul n:");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("Introduceti n numere una sub alta:");
            int numar = 0; int aux = 0; bool y = true;
            int x1 = int.Parse(Console.ReadLine());
            for (int i = 1; i < n; i++)
            {
                int x2 = int.Parse(Console.ReadLine());
                if (x2 == x1 + 1 && x1 != 0 && x2 != 0 && y == true) { aux = 1; }
                if (x2 == 0 && aux == 1) { numar++; aux = 0; }
                if (x2 != x1 + 1 && aux == 1) { aux = 0; }
                if (i == n - 1 && aux == 1) { numar++; }
                if (x2 != x1 + 1 && x1 != 0 && x2 != 0) { y = false; }
                if (x2 == 0) { y = true; }
                x1 = x2;

            }
            Console.WriteLine($"Sunt {numar} grupuri de numere consecutive diferite de 0.");
            Console.ReadKey();
        }

        private static void PB11()
        {
            //Se da o secventa de n numere. Se cere sa se caculeze suma inverselor acestor numere.
            Console.WriteLine($"Introduceti numarul n:");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("Introduceti n numere una sub alta:");
            int s = 0;
            for (int i = 0; i < n; i++)
            {
                int aux = 0;
                int x = int.Parse(Console.ReadLine());
                while (x > 0)
                {
                    aux = aux * 10 + x % 10;
                    x /= 10;
                }
                s = s + aux;
            }
            Console.WriteLine($"Suma inverselor numerelor este {s}.");
            Console.ReadKey();
        }

        private static void PB10()
        {
            //Se da o secventa de n numere. Care este numarul maxim de numere consecutive egale din secventa.
            Console.WriteLine($"Introduceti numarul n:");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("Introduceti n numere una sub alta:");
            int nr = 1;
            int nrmax = 1;
            int y = int.Parse(Console.ReadLine());
            for (int i = 1; i < n; i++)
            {
                int x = int.Parse(Console.ReadLine());
                if (y == x) { nr++; }
                if (nr > nrmax) { nrmax = nr; }
                if (y != x) { nr = 1; }
                y = x;
            }
            Console.WriteLine($"Numarul maxim de numere consecutive este {nrmax}.");
            Console.ReadKey();
        }

        private static void PB9()
        {
            //Sa se determine daca o secventa de n numere este monotona.
            //Secventa monotona = secventa monoton crescatoare sau monoton descrescatoare
            Console.WriteLine("Introduceti numarul n:");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("Introduceti n numere una sub alta:");
            int k = 0; int y = 0; bool ok = true;
            int x1 = int.Parse(Console.ReadLine());
            for (int i = 1; i < n; i++)
            {
                int x2 = int.Parse(Console.ReadLine());
                if ((x1 > x2 && k == 1) || (x1 < x2 && y == 1)) { ok = false; }
                if (x1 == x2) { continue; }
                if (x1 < x2) { k = 1; }
                if (x1 > x2) { y = 1; }
                x1 = x2;
            }
            if (ok == false) { Console.WriteLine("Secventa nu este monotona."); }
            else { Console.WriteLine("Secventa este monotona."); }
            Console.ReadKey();
        }

        private static void PB8()
        {
            //Determianti al n-lea numar din sirul lui Fibonacci. Sirul lui Fibonacci se construieste astfel: f1 = 0, f2 = 1, f_n = f_(n-1) + f(n-2).
            //Exemplu: 0, 1, 1, 2, 3, 5, 8 ...
            Console.WriteLine("Introduceti numarul n:");
            int n = int.Parse(Console.ReadLine());
            int a = 1, b = 1;
            if (n < 0) { Console.WriteLine("Nuamrul este negativ! Introduceti un nr pozitiv."); Console.ReadKey(); return; }
            if (n == 0) { Console.WriteLine("Nuamrul tau este zero."); Console.ReadKey(); return; }
            for (int i = 1; i <= n; i++)
            {
                int c = a + b;
                if (i == n) { Console.WriteLine($"Al n-lea numar di sirul lui fibonacci este {a}"); Console.ReadKey(); return; }
                a = b; b = c;
            }

        }

        private static void PB7()
        {
            //Se da o secventa de n numere. Sa se determine cea mai mare si cea mai mica valoare din secventa.
            Console.WriteLine("Introduceti nr n:");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("Introduceti n numere, cate unul pe fiecare linie:");
            int min = 0, max = 0;
            for (int i = 0; i < n; i++)
            {
                int x = int.Parse(Console.ReadLine());
                if (i == 0) { max = x; min = x; }
                if (i > 0)
                {
                    if (max < x) { max = x; }
                    if (min > x) { min = x; }
                }
            }
            Console.WriteLine($"Cel mai mare numar este {max} iar cel mai mic este {min}.");
            Console.ReadKey();

        }

        private static void PB6()
        {
            //Se da o secventa de n numere. Sa se determine daca numerele din secventa sunt in ordine crescatoare.
            Console.WriteLine("Introduceti nr n:");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("Introduceti n numere, cate unul pe fiecare linie:");
            int x1 = int.Parse(Console.ReadLine());
            bool aux = true;
            for (int i = 1; i < n; i++)
            {
                int x2 = int.Parse(Console.ReadLine());
                if (x1 > x2) { aux = false; }
            }
            if (aux) { Console.WriteLine($"Numerele sunt afisate in ordine crescatoare."); }
            else { Console.WriteLine($"Numerele nu sunt afisate in ordine crescatoare."); }
            Console.ReadKey();
        }

        private static void PB5()
        {
            //Cate elemente dintr-o secventa de n numere sunt egale cu pozitia pe care apar in secventa.
            //Se considera ca primul element din secventa este pe pozitia 0.
            Console.WriteLine("Introduceti nr n:");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("Introduceti n numere, cate unul pe fiecare linie:");
            int counter = 0; ;
            for (int i = 0; i < n; i++)
            {
                int x = int.Parse(Console.ReadLine());
                if (x == i) counter++;
            }
            Console.WriteLine($"Exista {counter} numere identice cu indicii lor.");
            Console.ReadKey();

        }

        private static void PB4()
        {
            //Se da o secventa de n numere. Determinati pe ce pozitie se afla in secventa un numara a.
            //Se considera ca primul element din secventa este pe pozitia zero.
            //Daca numarul nu se afla in secventa raspunsul va fi -1.
            Console.WriteLine("Introduceti nr n:");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("Introduceti nr a:");
            int a = int.Parse(Console.ReadLine());
            Console.WriteLine("Introduceti n numere, cate unul pe fiecare linie:");
            int indx = 0;
            for (int i = 0; i < n; i++)
            {
                int x = int.Parse(Console.ReadLine());
                if (a == x)
                    indx = i;
            }
            Console.WriteLine($"Numarul {a} se afla pe pozitia {indx}.");
            Console.ReadKey();
        }

        private static void PB3()
        {
            //Calculati suma si produsul numerelor de la 1 la n.
            Console.WriteLine("Introduceti nr n:");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("Introduceti n numere, cate unul pe fiecare linie:");
            int product = 1, sum = 0;
            for (int i = 0; i < n; i++)
            {
                int x = int.Parse(Console.ReadLine());
                product *= x; sum += x;
            }
            Console.WriteLine($"Suma este {sum} iar produsul este {product}.");
            Console.ReadKey();
        }

        private static void PB2()
        {
            //Se da o secventa de n numere. Sa se determina cate sunt negative, cate sunt zero si cate sunt pozitive.
            Console.WriteLine("Introduceti nr n:");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("Introduceti n numere, cate unul pe fiecare linie:");
            int zero = 0, pozitive = 0, negative = 0;
            for (int i = 0; i < n; i++)
            {
                int x = int.Parse(Console.ReadLine());
                if (x < 0) negative++;
                if (x > 0) pozitive++;
                if (x == 0) zero++;
            }
            Console.WriteLine($"Exista {negative} numere negative, {pozitive} numere pozitive si {zero} numere nule.");
            Console.ReadKey();
        }

        private static void PB1()
        {
            //Se da o secventa de n numere. Sa se determine cate din ele sunt pare. 
            Console.WriteLine("Introduceti nr n:");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("Introduceti n numere, cate unul pe fiecare linie:");
            int counter = 0;
            for (int i = 0; i < n; i++)
            {
                int x = int.Parse(Console.ReadLine());
                if (x % 2 == 0) counter++;
            }
            Console.WriteLine($"Exista {counter} numere pare in secventa data.");
            Console.ReadKey();
        }
    }
}

