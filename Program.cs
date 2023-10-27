using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace Kamień_papier_nożyce;

class Program
{


    static void Main(string[] args)
    {
        Start();
        /*
        formula start zawiera instruckje gry wraz 
        z przywitaniem oraz dwima innymi metodami które 
        mają na celu nadać tekstowi odpowiednie formatowanie kolorystyczne 
        */
        bool gra_z_graczem = true;
        //wprowadzenie zmiennej odpowiadającej grze z komputerem bazowo true
        int b = 0;
        //wprowadzenie zmiennej b, zostanie zastąpiona w pierwszym obiegu pętli gra przez gracza lub komputer
        List<int> lista_1 = new List<int>();
        List<int> lista_2 = new List<int>();
        /*
        tablice do przechowywania ruchów obu graczy
        długość tablic określa ich pojemność 
        i określa w późniejszym etapie dla którego elementu przypisać wybrany ruch
        */
        int punkty_całości_1 = 0;
        int punkty_całości_2 = 0;
        //zmienne do zliczania punktów w całości gry
        int licznik = 0;
        int punkty_1 = 0;
        int punkty_2 = 0;
        /*
         zmienne do rozgrywki:
        zmienne punkty zliczają punkty uzyskane w danej grze 
        zmienna licznik ma za zdanie doliczanie w celu wyświetlania punktacji,
        dopiero po rozpoczęciu drugiego obiegu pętlli
        */


        /*
          pętla warunkowa służaca do wyboru formy rozgrywki komputer / człowiek
         */

        while (true)
        {

            Console.WriteLine("Czy chcesz zagrać z innym graaczem? - wybierz 1, czy komputerem? wybierz 2");
            String gvsk = Console.ReadLine();
            if (int.TryParse(gvsk, out int gracz))
            {
                if (gracz != 1 && gracz != 2)
                {
                    Czerwony_kolor_tekstu();
                    Console.WriteLine("wybrano nie właściwą liczbę wybierz liczbę z przedziału 1-2");
                    Koniec_koloru();
                    continue;
                }
                else if (gracz == 1)
                {
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine("wybrano grę z innym graczem");
                    Koniec_koloru();
                }
                else if (gracz == 2)
                {
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine("wybrano grę z komputerem, powodzenia!");
                    Koniec_koloru();
                    gra_z_graczem = false;
                }
                break;
            }

            else
            {
                Czerwony_kolor_tekstu();
                Console.WriteLine("prawdopodobnie wpisano tekst zamiast liczby");
                Koniec_koloru();
                continue;

            }
        }

 

    //Instrukcja go to w razie chęci kontynuacji gry 
    // wyrażonej na kończu każej rozgrywki 
    Gra:
    //restet punktów zdobytych w danej grze 
    //oraz licznika zliczającego kolejną rundę
        licznik = 0;
        punkty_1 = 0;
        punkty_2 = 0;



        //Gra w pętli while 

        while (true)
        {

            //Licznik punktów wyświetlany po 1 obiegu pętli 
            if (licznik > 0)
            {

                Console.WriteLine($"gracz pierwszy posiada ilość punktów ={punkty_1}");
                Console.WriteLine($"gracz drugi posiada ilość punktów ={punkty_2}");
                Nowa_linia();
            }

            //Warunki wygranej w całej rozgrywce przez obu użtkowników / użytkownika i komputer 
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            if (punkty_1 >= 3)
            {
                Console.WriteLine("gracz pierwszy wygrał grę jako pierwszy zobył 3 punky");
                Nowa_linia();
                punkty_całości_1++;
                break;
            }
            else if (punkty_2 >= 3)
            {
                Console.WriteLine("gracz drugi wygrał grę jako pierwszy dobył 3 punkty");
                Nowa_linia();
                punkty_całości_2++;
                break;
            }
            Koniec_koloru();

            /* na początku każdej rozgrywwki rsetuje b. 
            następnie gracze wpisując wartości liczbowe które odpowiadają 
            typowi int na wypadek nie wpisana typu int przez graczy komputer informuje o tym 
            i przenosi do ponownego wyboru 
            na wypadek wpisana liczby z poza zakresu 1-3 komputer przenosi gracza do pononego 
            wpisu danego gracza, bez konieczności wpisaywania przez obu nowych wartości 
            */

            b = 0;
            do_a:
            Console.WriteLine("gracz pierwszy:");
            string a_to_parse = (Console.ReadLine());
            if (int.TryParse(a_to_parse, out int a) && b != 0)
            {
                goto po_a;
            }
            else if (a !is int)
            {

                Czerwony_kolor_tekstu();
                Console.WriteLine("gracz 1 - podaj wartość liczbową, reset rundy w zakresie 1-3");
                Koniec_koloru();
                continue;
            }

        wybor_gracz_2:
            if (gra_z_graczem == true)
            
            {
                Console.WriteLine("gracz drugi:");
                string b_to_parse = (Console.ReadLine());
                if (int.TryParse(b_to_parse, out b))
                {

                }
                else if (b !is int)
                {
                    Czerwony_kolor_tekstu();
                    Console.WriteLine("gracz 2 - podaj wartość liczbową, w zakresie 1-3");
                    Koniec_koloru();
                    goto wybor_gracz_2;
                }
                    
            }

            if (gra_z_graczem == false)
            {

                Random liczby = new();
                b = liczby.Next(1, 4);

                Console.WriteLine(b);
            }

            //Warunek dla sytuacji w której gracze wybrali liczby z poza przedziału
            po_a:

            if (a > 3 || a < 1)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Gracz pierwszy wybrał liczbę z poza przedziału 1-3");
                Koniec_koloru();
                Nowa_linia();
                goto do_a;
            }
            else if(b > 3 || b < 1)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Gracz drugi wybrał liczbę z poza przedziału 1-3");
                Koniec_koloru();
                Nowa_linia();
                goto wybor_gracz_2;
            }


            licznik++;


            lista_1.Add(a);
            lista_2.Add(b);


            //Warunki remisu 
            if (a == b)
            {
                Czerwony_kolor_tekstu();
                Console.WriteLine("Remis brak puktów");
                Console.ResetColor();
                Nowa_linia();
                continue;
            }

            Console.ForegroundColor = ConsoleColor.Green;

            //Wygrana gracza 1 
            if ((a == 1 && b == 2) || (a == 2 && b == 3) || (a == 3 && b == 1))
            {
                Console.WriteLine("gracz pierwszy wygrywa");
                punkty_1++;
                Koniec_koloru();
                Nowa_linia();
                continue;
            }
            //Wygrana gracza 2 
            else
            {
                Console.WriteLine("gracz drugi wygrywa");
                punkty_2++;
                Koniec_koloru();
                Nowa_linia();
                continue;
            }

        }
        //podliczenie punktów całościowych
        Console.WriteLine($"gracz 1 posiada {punkty_całości_1} punktów w całej grze");
        Nowa_linia();
        Console.WriteLine($"gracz 2 posiada {punkty_całości_2} punktów w całej grze");
        Nowa_linia();

        //Pytanie o kontynuajcę gry wraz z możliwościa zakończenia

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("czy chcesz kontynuować gre? naciśnij 1 jeśli tak, naciśnij 2 jeśli nie");
        Koniec_koloru();

    wybór:


        String tak_nie = Console.ReadLine();
        if (int.TryParse(tak_nie, out int gra_dalej))
        {

            //jeśli liczby spoza zakresu go to do wyboru możliwości kontynuacji gry

            if (1 != gra_dalej && 2 != gra_dalej)
            {
                Czerwony_kolor_tekstu();
                Console.WriteLine("wybrano nie prawidłową watość!!!");
                Koniec_koloru();
                goto wybór;
            }
            //Go to do pętli while jako gry 
            else if (gra_dalej == 1)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("zaczynamy kolejną grę");
                Koniec_koloru();
                goto Gra;
            }
            //zakończenie gry 
            else
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("koniec na dziś jeszcze tylko wyniki :)");
                Nowa_linia();

            }
        }
        else
        {
            Console.WriteLine("podaj liczbę");
            goto wybór;
        }

        //kod podsumowywujący rozgrywkę

        if (punkty_całości_1 == punkty_całości_2)
        {
            Nowa_linia();
            Console.WriteLine("Czyli remis");
        }
        else if (punkty_całości_1 > punkty_całości_2)
        {
            Nowa_linia();
            Console.WriteLine("wygrał gracz 1");
        }
        else
        {
            Nowa_linia();
            Console.WriteLine("Wygrał gracz 2");
        }


        //wysłanie danych  z gry do innego pliku 
        for (int i = 0; i < lista_1.Count; i++)
        {
            Console.WriteLine($"ruch gracza 1 = {lista_1[i]} ruch gracza 2 = {lista_2[i]} w rundzie{i + 1}");
        }

        //podpis 

        Nowa_linia();
        Console.WriteLine("Autor Kuczu");
        Console.ReadKey();

    }


    static void Nowa_linia()
    {
        Console.WriteLine("\n");
    }

    static void Czerwony_kolor_tekstu()
    {
        Console.ForegroundColor = ConsoleColor.Red;
    }

    static void Koniec_koloru()
    {
        Console.ResetColor();
    }

    static void Start()
    {
        Console.Title = "kamień / papier / nożyce";
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("Hej witaj w mojej grze, polega ona na wybraniu:\n1-Kamień\n2-Nożyce\n3-Papier");
        Console.WriteLine("Zasady są proste kamien wygrywa z nożycami, nożyce z papierem a papier z kamieniem");
        Console.WriteLine("możesz w grę zagrać sam z komputerem lub z inną osobą.");
        Koniec_koloru();
    }


}