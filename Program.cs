using System;
using System.ComponentModel;
using System.ComponentModel.Design;

namespace Kamień_papier_nożyce;

class Program
{


    static void Main(string[] args)
    //Początek gry instrukcja, przywitanie 
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("Hej witaj w mojej grze, polega ona na wybraniu:\n1-Kamień\n2-Nożyce\n3-Papier");
        Console.WriteLine("Zasady są proste kamien wygrywa z nożycami, nożyce z papierem a papier z kamieniem");
        Console.WriteLine("możesz w grę zagrać sam z komputerem lub z inną osobą.");
        koniec_koloru();

        //wprowadzenie zmiennej odpowiadającej grze z komputerem bazowo true
        bool gra_z_graczem = true;
        //wprowadzenie zmiennej b, zostanie zastąpiona w pierwszym obiegu pętli gra przez gracza lub komputer
        //pamiętać że b mozna zastąpić wartość w kodzie ale nie mozna jej zadeklarować dwa razy jakieś 1,5h szukałem błędu 
        //po ponownym zadeklarowaniu b w insstrukcjach warunkowych gry z komputerem 

        
        int b = 0;
       


        while (true)
        {

            Console.WriteLine("Czy chcesz zagrać z innym graaczem? - wybierz 1, czy komputerem? wybierz 2");
            String gvsk = Console.ReadLine();
            if (int.TryParse(gvsk, out int gracz))
            {
                if (gracz != 1 && gracz != 2)
                {
                    czerwony_kolor_tekstu();
                    Console.WriteLine("wybrano nie właściwą liczbę wybierz liczbę z przedziału 1-2");
                    koniec_koloru();
                    continue;
                }
                else if (gracz == 1)
                {
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine("wybrano grę z innym graczem");
                    koniec_koloru();
                }
                else if (gracz == 2)
                {
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine("wybrano grę z komputerem, powodzenia!");
                    koniec_koloru();
                    gra_z_graczem = false;
                }
                break;
            }

            else
            {
                czerwony_kolor_tekstu();
                Console.WriteLine("prawdopodobnie wpisano tekst zamiast liczby");
                koniec_koloru();
                continue;

            }
        }

        int punkty_całości_1 = 0;
        int punkty_całości_2 = 0;
       
    //Instrukcja go to w razie chęci kontynuacji gry 
    Gra:
        //zmienne licznik do obliczania przebiegu pętli
        int licznik = 0;
        int punkty_1 = 0;
        int punkty_2 = 0;
       


        //Pętla jako sama gra 

        while (true)
        {
            
            //Licznik punktów wyświetlany po 1 obiegu pętli 
            if (licznik > 0)
            {

                Console.WriteLine($"gracz pierwszy posiada ilość punktów ={punkty_1}");
                Console.WriteLine($"gracz drugi posiada ilość punktów ={punkty_2}");
                nowa_linia();
            }

            //Warunki wygranej
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            if (punkty_1 >= 3)
            {
                Console.WriteLine("gracz pierwszy wygrał grę jako pierwszy zobył 3 punky");
                nowa_linia();
                punkty_całości_1++;
                break;
            }
            else if (punkty_2 >= 3)
            {
                Console.WriteLine("gracz drugi wygrał grę jako pierwszy dobył 3 punkty");
                nowa_linia();
                punkty_całości_2++;
                break;
            }
            koniec_koloru();

            //wpisuwanie przez graczy wartości
            Console.WriteLine("gracz pierwszy:");
            string a_to_parse = (Console.ReadLine());
            if (int.TryParse(a_to_parse, out int a))
            {

            }
            else
            {

                czerwony_kolor_tekstu();
                Console.WriteLine("gracz 1 - podaj wartość liczbową, reset rundy");
                koniec_koloru();
                continue;
            }

            if (gra_z_graczem == true)
                  
            {
                
                Console.WriteLine("gracz drugi:");
                string b_to_parse = (Console.ReadLine());
             
                if (int.TryParse(b_to_parse, out  b))
                {
                    
                }
                else
                {
                    czerwony_kolor_tekstu();
                    Console.WriteLine("gracz 2 - podaj wartość liczbową, reset rundy!");
                    koniec_koloru();
                    continue;
                }
               
            }

            if  (gra_z_graczem == false)
            {

                Random liczby = new Random();
                b = liczby.Next(1, 4);
             
                Console.WriteLine(b);
            }

            //Warunek dla sytuacji w której gracze wybrali liczby z poza przedziału
            
            if (a > 3 || a < 1 || b > 3 || b < 1)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("któryś z graczy nie wybrał liczby z przedziału 1-3");
                koniec_koloru();
                nowa_linia();
                continue;
            }

            //Zwiększenie licznika 
            
           

            //Warunki remisu 
            if (a == b)
            {
                czerwony_kolor_tekstu();
                Console.WriteLine("Remis brak puktów");
                Console.ResetColor();
                nowa_linia();
                continue;
            }

            Console.ForegroundColor = ConsoleColor.Green;

            //Wygrana gracza 1 
            if ((a == 1 && b == 2) || (a == 2 && b == 3) || (a == 3 && b == 1))
            {
                Console.WriteLine("gracz pierwszy wygrywa");
                punkty_1++;
                koniec_koloru();
                nowa_linia();
                continue;
            }
            //Wygrana gracza 2 
            else
            {
                Console.WriteLine("gracz drugi wygrywa");
                punkty_2++;
                koniec_koloru();
                nowa_linia();
                continue;
            }

        }
        //podliczenie punktów całościowych
        Console.WriteLine($"gracz 1 posiada {punkty_całości_1} punktów w całej grze");
        nowa_linia();
        Console.WriteLine($"gracz 2 posiada {punkty_całości_2} punktów w całej grze");
        nowa_linia();

        //Pytanie o kontynuajcę gry wraz z możliwościa zakończenia

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("czy chcesz kontynuować gre? naciśnij 1 jeśli tak, naciśnij 2 jeśli nie");
        koniec_koloru();

    wybór:


        String tak_nie = Console.ReadLine();
        if (int.TryParse(tak_nie, out int gra_dalej))
        {

            //jeśli liczby spoza zakresu go to do wyboru możliwości kontynuacji gry

            if (1 != gra_dalej && 2 != gra_dalej)
            {
                czerwony_kolor_tekstu();
                Console.WriteLine("wybrano nie prawidłową watość!!!");
                koniec_koloru();
                goto wybór;
            }
            //Go to do pętli while jako gry 
            else if (gra_dalej == 1)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("zaczynamy kolejną grę");
                koniec_koloru();
                goto Gra;
            }
            //zakończenie gry 
            else
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("koniec na dziś jeszcze tylko wyniki :)");
                nowa_linia();

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
            nowa_linia();
            Console.WriteLine("Czyli remis");
        }
        else if (punkty_całości_1 > punkty_całości_2)
        {
            nowa_linia();
            Console.WriteLine("wygrał gracz 1");
        }
        else
        {
            nowa_linia();
            Console.WriteLine("Wygrał gracz 2");
        }

        //podpis 

        nowa_linia();
        Console.WriteLine("Autor Kuczu");

    }


    static void nowa_linia()
    {
        Console.WriteLine("\n");
    }

    static void czerwony_kolor_tekstu()
    {
        Console.ForegroundColor = ConsoleColor.Red;
    }

    static void koniec_koloru()
    {
        Console.ResetColor();
    }

 
}