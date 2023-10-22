using System;

namespace Kamień_papier_nożyce;

class Program
{
    static void Main(string[] args)
        //Początek gry instrukcja, przywitanie 
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("Hej witaj w mojej grze, polega ona na wybraniu:\n1-Kamień\n2-Nożyce\n3-Papier");
        Console.WriteLine("Zasady są proste kamien wygrywa z nożycami, nożyce z papierem a papier z kamieniem");
        Console.WriteLine("potrzebujesz kolegi który zaga z toba");
        Console.ResetColor();

        //W planie jest zrobienie później jeszcze wersji w której można będzie grć z komputerem
        //definicja zmiennych dla punktów zdobytych ogółem
        int punkty_całości_1 = 0;
        int punkty_całości_2 = 0;
        //Instrukcja go to w razie chęci kontynuacji gry 
    Gra:
        int licznik = 0;
        int punkty_1 = 0;
        int punkty_2 = 0;

        
        //Pętla jako sama gra 
        
        while (true)
        {
            //spytać o to jak by to przeparsowac metodą try pare żeby nie wywalało mi programu 
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
            Console.ResetColor();

            //wpisuwanie przez graczy wartości
            nowa_linia();
            Console.WriteLine("gracz pierwszy:");
            int a = Convert.ToInt32(Console.ReadLine());
            nowa_linia();
            Console.WriteLine("gracz drugi:");
            int b = Convert.ToInt32(Console.ReadLine());
            nowa_linia();

            //Warunek dla sytuacji w której gracze wybrali liczby z poza przedziału

            if (a > 3 || a < 1 || b > 3 || b < 1)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("któryś z graczy nie wybrał liczby z przedziału 1-3");
                Console.ResetColor();
                nowa_linia();
                continue;
            }

            //Zwiększenie licznika 

            licznik++;

            //Warunki remisu 
            if (a == b)
            {
                Console.ForegroundColor = ConsoleColor.Red;
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
                Console.ResetColor();
                nowa_linia();
                continue;
            }
            //Wygrana gracza 2 
            else
            {
                Console.WriteLine("gracz drugi wygrywa");
                punkty_2++;
                Console.ResetColor();
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

        Console.WriteLine("czy chcesz kontynuować gre? naciśnij 1 jeśli tak, naciśnij 2 jeśli nie");
        wybór:
        int Tak_nie = Convert.ToInt32(Console.ReadLine());

        
        //jeśli liczby spoza zakresu go to do wyboru możliwości kontynuacji gry
    
        if (1 != Tak_nie && 2 != Tak_nie)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("wybrano nie prawidłową watość!!!");
            Console.ResetColor();
            goto wybór;
        }
        //Go to do pętli while jako gry 
        else if (Tak_nie == 1)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("zaczynamy kolejną grę");
            Console.ResetColor();
            goto Gra;
        }
        //zakończenie gry 
        else
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("koniec na dziś jeszcze tylko wyniki :)");
            nowa_linia();

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

}