using System;
using System.Collections.Generic;
using System.Text;

namespace Klasser
{
    class Menu
    {
        public static string Current_user;
        public static int count = 0;

        public static void Car_Propertis_Menu()
        {
            bool keep_rolling = true;

            while (keep_rolling)
            {

                Console.Clear();

                DateTime registrerades = DateTime.Now;

                Console.Write("Bil Märke : ");
                string Logo = Console.ReadLine();
                while (Logo == "")
                {
                    Console.Write("\n** Du måste skriva något **\n\nFörsök igen : ");
                    Logo = Console.ReadLine();
                }

                Console.Write("Bil model : ");
                string Modell = Console.ReadLine();
                while (Modell == "")
                {
                    Console.Write("\n** Du måste skriva något **\n\nFörsök igen : ");
                    Modell = Console.ReadLine();
                }
                Console.Write("Bil Regnummer : ");
                string Reg_nummer = Console.ReadLine();
                while (Reg_nummer == "")
                {
                    Console.Write("\n** Du måste skriva något **\n\nFörsök igen : ");
                    Reg_nummer = Console.ReadLine();
                }

                Console.Write("Bil Vikt : ");
                int Vikt = 0;
                while (!int.TryParse(Console.ReadLine(), out Vikt))
                {
                    Console.Write("\n** Bara siffror tillåtet **\n** Du får inte lämna tom**\nFörsök igen : ");
                }




                Console.Write("Hur långt har bilen gått? : ");
                decimal dometer = 0;
                while (!decimal.TryParse(Console.ReadLine(), out dometer))
                {
                    Console.Write("\n** Bara Decimal tillåtet **\n** Du får inte lämna tom**\nFörsök igen : ");
                }

                Console.Write("El Bil (ja eller nej) : ");

                bool Elbil = false;

                while (!Elbil)
                {
                    string el_or_not = Console.ReadLine();


                    if (el_or_not.ToUpper() == "JA")
                    {
                        Elbil = true;
                    }
                    else if (el_or_not.ToUpper() == "NEJ")
                    {
                        Elbil = false;
                        break;
                    }
                    else
                    {
                        Console.Write("** Vänligen svara med ( Ja / Nej ) **\nFörsök igen : ");
                    }
                }
                Car_propertis.Set_Car_database(registrerades, Logo, Modell, Reg_nummer, Vikt, dometer, Elbil, Current_user);


                Console.Write($"\n ** Bilen med Reg.nummer ( { Reg_nummer } ) är registerat. **\n");
                bool keep_rolling2 = true;

                while (keep_rolling2)
                {

                    Console.Write("\nVill du lägga till mer bil ( Ja / Nej ) : ");
                    string waiting_ans = Console.ReadLine();

                    if (waiting_ans.ToUpper() == "JA")
                    {
                        Car_Propertis_Menu();

                    }
                    else if (waiting_ans.ToUpper() == "NEJ")
                    {
                        keep_rolling2 = false;
                        keep_rolling = false;
                        Huvud_Menu();

                    }
                    else
                    {
                        Console.Write("\nVänligen svara med Ja eller Nej.");

                    }
                }
                break;

            }

            
        }


        public static void Huvud_Menu()

        {
            count = 0;
            Console.Clear();
            foreach (var item in Car_propertis.Getting_car_dict())
            {
                if (item.Value.User_name == Current_user)
                {
                    count++;
                }
            }
            Console.WriteLine("Välkomen till YR - Köp/Sälja Bil!\n");
            Console.WriteLine($"[1] Registera bil\n[2] Visa alla registerade bilar\n[3] Söka / Ändra bil info\n[4] Loga UT [ {Current_user} ]");

            Console.Write("\nVälja ett nr : ");
            string menu_val = Console.ReadLine();

            bool continue_prog = true;

            while (continue_prog)
            {

                if (menu_val == "1")
                {
                    Car_Propertis_Menu();
                    Huvud_Menu();
                    return;
                }
                else if (menu_val == "2")
                {

                    Program.All_car();
                    return;
                }
                else if (menu_val == "3")
                {
                    Car_propertis.Car_info_edit();
                    return;
                }
                else if (menu_val == "4")
                {
                    Console.Clear();
                    User_info_menu();
                    return;
                    

                }

                else
                {
                    Console.Clear();
                    Console.WriteLine("Fel val försök igen");
                    Huvud_Menu();

                }
            }

        }
        public static void User_info_menu()
        {

            bool Keep_asking = true;

            while (Keep_asking)
            {
                Console.Clear();
                Console.WriteLine("Välkomen till YR - Köp/Sälja Bil!\n");
                Console.WriteLine("[1] Log in\n[2] Registera dig \n[3] Stänga programmet");
                Console.Write("\nVälja ett nr : ");
                try
                {
                    int user_val = Convert.ToInt32(Console.ReadLine());
                    switch (user_val)
                    {
                        case 1:
                            if (Person_info.Get_person_info() > 0)
                            {
                                Console.Clear();
                                Console.Write("Användare namn : ");
                                string user_name = Console.ReadLine();
                                Console.Write("Användare Lössenord : ");
                                string user_pass = Console.ReadLine();
                                Person_info.Login(user_name, user_pass);
                                return;
                            }
                            else
                            {
                                Console.WriteLine("\n** Vi har ingen registerade member just nu **\n** Registera dig nu. Enkel och Gratis **");
                                Console.WriteLine("\n [ Trycke valfri knapp ... ]");
                                Console.ReadKey();                              

                            }
                            return;
                        case 2:

                            Console.Clear();
                            Person_info new_person = new Person_info();
                            Console.Write("Registera dig här.\n\nDin namn : ");
                            string name = Console.ReadLine();

                            while (name == "")
                            {
                                Console.Write("\n** Du måste skriva något **\n\nFörsök igen : ");
                                name = Console.ReadLine();
                            }
                            Console.Write("\nVälja än unikt lössenord : ");

                            string password = Console.ReadLine();
                            while (password == "")
                            {
                                Console.Write("\n** Du måste skriva något **\n\nFörsök igen : ");
                                password = Console.ReadLine();
                            }

                            Console.Write("\nGe samma lössenord igen : ");
                            string password_check = Console.ReadLine();

                            while (!password.Equals(password_check))
                            {
                                Console.Write("\n**Lössenord matcher inte varandra**\n\nFörsök igen : ");
                                password_check = Console.ReadLine();
                            }
                            new_person.Register_now(name, password, password_check, new_person);
                            Keep_asking = false;
                            break;


                        case 3:
                            Keep_asking = false;
                            return;
                        default:
                            Console.Write("\n** Du måste välja mellan 1 - 3**\n[ Trycke valfri knapp ... ]");
                            Console.ReadKey();
                            break;

                    }

                }
                catch (Exception)
                {
                    Console.Write("\n** Fel inmatning.**\n[ Trycke valfri knapp ... ]");
                    Console.ReadKey();

                }

            }

        }
    }
}
