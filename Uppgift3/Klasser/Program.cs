using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Klasser
{
    

    class Program
    {
        static Program()
        {
            Console.WriteLine("Välkomen till YR - Köp/Sälja Bil!\n");
            Console.WriteLine("[1] Registera en bil\n[2] Söka bil info\n[3] Stänga programmet");

            Console.Write("Välja ett nr : ");
            string menu_val = Console.ReadLine();
            bool continue_prog = true;

            while (continue_prog)
            {

                if (menu_val == "1")
                {
                    Register_bil.Reg_menu();
                }
                else if (menu_val == "2")
                {
                    Console.WriteLine("2");
                    break;
                }
                else if (menu_val == "3")
                {
                    Console.WriteLine("3");

                    continue_prog = false;

                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Fel val försök igen");
                    Console.WriteLine("Välkomen till YR - Köp/Sälja Bil!\n");
                    Console.WriteLine("[1] Registera en bil\n[2] Söka bil info\n[3] Stänga programmet");
                    Console.Write("Välja ett nr : ");
                    menu_val = Console.ReadLine();
                }
            }


        }
        public Dictionary<string, Register_bil> car_database = new Dictionary<string, Register_bil>();
        static void Main(string[] args)
        {
            Program menu = new Program();
            

        }            
    }

    class Register_bil
    {
        
        private DateTime registrerades;
        private string Logo;
        private bool Elbil;
        private string Modell { get; set; }
        private string Reg_nummer { get; set; }
        private int Vikt { get; set; }
        public static void Reg_menu ()
        {
            Console.Clear();

            Console.Write("Vill du lägga till ny bil. (Ja / Nej) : ");
            string user_ans = Console.ReadLine();

            bool keep_rolling = true;

            while (keep_rolling)
            {

                if (user_ans.ToUpper() == "JA")
                {
                    string logo, model, regnummer, el_or_not;
                    int vikt;

                    DateTime registrerades = DateTime.Now;

                    Console.Write("Bil Märke : ");
                    logo = Console.ReadLine();

                    Console.Write("Bil model : ");
                    model = Console.ReadLine();

                    Console.Write("Bil Regnummer : ");
                    regnummer = Console.ReadLine();

                    Console.Write("Bil Vikt : ");
                    vikt = Convert.ToInt32(Console.ReadLine());

                    Console.Write("El Bil (ja eller nej) : ");
                    el_or_not = Console.ReadLine();

                    Register_bil car = new Register_bil();

                    car.Ge_value(registrerades, logo, model, regnummer, vikt, el_or_not);


                    Console.Write("Vill du lägga till ny bil. (Ja / Nej) : ");
                    user_ans = Console.ReadLine();
                }
                else if (user_ans.ToUpper() == "NEJ" )
                {
                    keep_rolling = false;
                    break()
                }
            }
            Program menu = new Program();
           


        }


        private void Ge_value(DateTime datum, string logo, string modell, string reg_nummer, int vikt, string el_or_not )
        {

            this.registrerades = datum;
            this.Logo = logo;
            this.Modell = modell;
            this.Reg_nummer = reg_nummer;
            this.Vikt = vikt;

            if (el_or_not.ToLower() == "yes")
            {
                this.Elbil = true;
            }
            else
            {
                this.Elbil = false;
            }
        }



    }
    
    


}