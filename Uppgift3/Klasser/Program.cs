using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Klasser
{
    class Program : Menu
    {
        public static void All_car()
        {
            Console.Clear();
            if (Menu.count < 1)
            {
                Console.WriteLine("\n*Du har ingen registe bil i vår system*\n");
            }
            
            foreach (var item in Car_propertis.Getting_car_dict())
            {

                if (item.Value.User_name == Current_user)
                {
                    Console.WriteLine($"Bil Märke : {item.Value.Logo }\nBil Modell : {item.Value.Modell}\n" +
                    $"Bil Regnummer : {item.Value.Reg_nummer}\nBil vikt : {item.Value.Vikt} Kg\n" +
                    $"Bile har gått : {item.Value.Milmätare.ToString()}\n" +
                    $"Bilen Registerade : {item.Value.registrerades}");

                    if (item.Value.Elbil == true)
                    {
                        Console.WriteLine("\"Detta är en El-Bil\"");
                    }
                    Console.WriteLine("\n ----------------------------------");
                }
           
            }
            Console.WriteLine("\n*Tryck valfritt knapp föratt gå tillbaka till huvud meny.*");
            Console.ReadKey();
            Huvud_Menu();

        }
        //-------------------------------------------------- Vissas alla bilar som registerad SLUT-----------------------------------------------
        //-------------------------------------------------- Huvud menu func Slut-----------------------------------------------
        static void Main(string[] args)
        {

            User_info_menu();

        }
    }
}