using System;
using System.Collections.Generic;
using System.Text;

namespace Klasser
{
    class Person_info
    {

        private static List<Person_info> Person_database = new List<Person_info>();

        public DateTime P_register { get; private set; }
        public string Person_namn { get; private set; }
        public string P_password { get; private set; }

        private void Hidding_person_info(DateTime P_register_, string Person_namn_, string P_password_, Person_info Set_new_paseron)
        {
            this.P_register = P_register_;
            this.Person_namn = Person_namn_;
            this.P_password = P_password_;
            Person_database.Add(Set_new_paseron);
        }

        private void check_register_info(string name, string password, string password_check, Person_info Set_new_paseron)
        {
            if (Person_database.Count <= 0 && password.Equals(password_check) == true)
            {
                Hidding_person_info(DateTime.Now, name, password, Set_new_paseron);
                Console.WriteLine("\n\n** Registering Klar **\n[Trycke valfri knapp... ]");
                Console.ReadKey();
                Menu.User_info_menu();
                
            }
            else if (Person_database.Count >= 1 && password.Equals(password_check) == true)
            {
                for (int i = 0; i < Person_database.Count; i++)
                {
                    if (Person_database[i].Person_namn.Equals(name) == true)
                    {
                        Console.WriteLine("\n\n** Användare namn finns redan **\n[Trycke valfri knapp... ]");
                        Console.ReadKey();
                        Menu.User_info_menu();
                        break;
                    }
                }
                Hidding_person_info(DateTime.Now, name, password, Set_new_paseron);
                Console.WriteLine("\n\n** Registering Klar **\n[Trycke valfri knapp... ]");
                Console.ReadKey();
                Menu.User_info_menu();
            }
            else
            {
                Console.WriteLine("\n** Lössenord matcher inte med varandra **\n[Trycke valfri knapp... ]");
                Console.ReadKey();
                Menu.User_info_menu();
            }
        }

        public void Register_now(string name, string password, string password_check, Person_info Set_new_paseron)
        {
            check_register_info(name, password, password_check, Set_new_paseron);
        }



        private static void Login_check(string name, string password)
        {

            foreach (var item in Person_database)
            {
                if (item.Person_namn == name && item.P_password == password)
                {
                    Menu.Current_user = name;
                    Menu.Huvud_Menu();
                    
                }
            }
            Console.WriteLine("\n** Vi hittar inte dig i vår system **\n[Trycke valfri knapp... ]");
            Console.ReadKey();
            Menu.User_info_menu();

        }
        public static void Login(string user_name, string user_pass)
        {
            Person_info.Login_check(user_name, user_pass);
        }

        public static int Get_person_info()
        {

            return Person_database.Count;
        }

    }
}
