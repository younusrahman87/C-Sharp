using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Klasser
{
    class Car_propertis
    {


        private static Dictionary<string, Car_propertis> Car_Database_Dict = new Dictionary<string, Car_propertis>();
        
        public string User_name { get; private set; }
        public DateTime registrerades;
        public string Logo;
        public bool Elbil;
        public int Vikt { get; set; }
        public string Modell { get; private set; }
        public string Reg_nummer { get; private set; }
        public decimal Milmätare { get; private set; }

        public void Odometer(decimal mil_change)
        {
            while (true)
            {
                if (mil_change > Milmätare)
                {
                    Milmätare = mil_change;
                    break;
                }
                else if (mil_change <= Milmätare)
                {
                    Console.Write($"Värde kan inte bara samma eller mindre än ( {Milmätare} ).\n" +
                        $"\nFörsök igen : ");
                    mil_change = Convert.ToDecimal(Console.ReadLine());

                }
                else
                {
                    break;
                }
            }
        }

        //-------------------------------------------------- Databas skapare -----------------------------------------------

        private void Hide_database(DateTime registrerades_, string Logo_, string Modell_, string Reg_nummer_, int Vikt_, decimal dometer_, bool Elbil_, Car_propertis Set_new_car_info, string Current_user)
        {
            this.User_name = Current_user;
            this.registrerades = registrerades_;
            this.Logo = Logo_;
            this.Modell = Modell_;
            this.Reg_nummer = Reg_nummer_;
            this.Vikt = Vikt_;
            this.Milmätare = dometer_;
            this.Elbil = Elbil_;
            try
            {
                Car_Database_Dict.Add(this.Reg_nummer, Set_new_car_info);

            }
            catch (Exception)
            {

                Console.WriteLine("\n** Denna Registering nummer finns redan **\n" +
                                    "\n** Tryck valfri knapp för försöka igen. **   ");
                Console.ReadKey();
                Menu.Car_Propertis_Menu();
            }


        }

        //-------------------------------------------------- Databas skapare  slut -----------------------------------------------

        public static void Set_Car_database(DateTime registrerades, string Logo, string Modell, string Reg_nummer, int Vikt, decimal dometer, bool Elbil, string Current_user)
        {
            Car_propertis set_new_car_info = new Car_propertis();
            set_new_car_info.Hide_database(registrerades, Logo, Modell, Reg_nummer, Vikt, dometer, Elbil, set_new_car_info, Current_user);

        }

        //-------------------------------------------------- Ändra bil information -----------------------------------------------


        public static void Car_info_edit()
        {
            if (Program.count > 0)
            {

                Console.Write("\nSkriv registering nummer till bilen : ");
                string serach_reg = Console.ReadLine();

                if (Car_Database_Dict.Keys.Contains(serach_reg) == true && Menu.Current_user == Car_Database_Dict[serach_reg].User_name)
                {
                    Console.Clear();
                    Console.WriteLine($"\n---------------------------------------------------------------------\n" +
                                            $"Bil Märke : {Car_Database_Dict[serach_reg].Logo}\nBil Modell : {Car_Database_Dict[serach_reg].Modell}\n" +
                                            $"Bil Regnummer : {Car_Database_Dict[serach_reg].Reg_nummer}\nBil vikt : {Car_Database_Dict[serach_reg].Vikt} Kg\n" +
                                            $"Bile har gått : {Car_Database_Dict[serach_reg].Milmätare.ToString()}\n" +
                                            $"Bilen Registerade : {Car_Database_Dict[serach_reg].registrerades}" +
                                            $"\n---------------------------------------------------------------------");

                    Console.Write("\nVill du ändra bil milmätare ? ( Ja ) eller tryck bara 'Enter' : ");
                    string change_car_info = Console.ReadLine();

                    if (change_car_info.ToUpper() == "JA")
                    {
                        while (true)
                        {
                            decimal nya_värdet = 0;
                            try
                            {
                                Console.Write("\nSkriv den nya värdet : ");
                                nya_värdet = Convert.ToDecimal(Console.ReadLine());
                            }
                            catch (Exception)
                            {

                                Console.WriteLine("\n**Fel inmatning, bara decimaltal tilllåtet.**\n");
                            }

                            if (nya_värdet > Car_Database_Dict[serach_reg].Milmätare)
                            {
                                Car_Database_Dict[serach_reg].Milmätare = nya_värdet;
                                break;

                            }

                            else if (nya_värdet < Car_Database_Dict[serach_reg].Milmätare)
                            {
                                Console.WriteLine($"\nVärdet på {Car_Database_Dict[serach_reg].Reg_nummer} kan inte bara minde än {Car_Database_Dict[serach_reg].Milmätare}\n");


                            }
                        }
                    }
                }
                else

                {
                    while (true)
                    {

                        Console.Write("\n ** Tyvärr hittade inget **\n" +
                                          "Vill du försöka igen skriv ( JA ) eller tryck bara 'Enter' : ");
                        string user_ans = Console.ReadLine();
                        if (user_ans.ToUpper() == "JA")
                        {
                            Car_info_edit();
                        }
                        else
                        {
                            Menu.Huvud_Menu();
                        }

                    }

                }
                Menu.Huvud_Menu();
            }
            else
            {
                Console.WriteLine("\n** Opps.. Det finns inge registerad bil i vår system **\n[Trycke valfri knapp... ]");
                Console.ReadKey();
                Menu.Huvud_Menu();
            }
        }

        public static Dictionary<string, Car_propertis> Getting_car_dict()
        {
            return Car_Database_Dict;
        }

    }
}