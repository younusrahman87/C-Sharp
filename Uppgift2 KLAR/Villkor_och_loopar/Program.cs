using Microsoft.VisualBasic;
using System;

namespace Villkor_och_loopar
{
    class Program
    {
        static int winner = 0, winner_startnummer = 0, antal_spelare = 0;
        //------------------------------------------------------------HÄR PRINTER UT TILL KONSOLE-------------------------------------------------------------
        static void Printer ()
        {
            if (antal_spelare > 0)
            {
                Console.Clear();
                int hour = winner / 3600;
                int min = (winner % 3600) / 60;
                int latest_sec = winner % 60;

                Console.WriteLine($"::. Vinnare startnr är: {winner_startnummer} .::\n" +
                                    $"::. {hour} : Timmar, {min} : Minuter, {latest_sec} : Sekunder .::\n" +
                                      $"::. Antal tävlande: {antal_spelare} .::");
            }
            else
            {
                Console.WriteLine("::. Inga tävlande .:: ");
            }


        }

        //-------------------------------------------------------------------------RÄKNAR TID TILL SEKUND OCH RÄNKAR DAG------------------------------------------------

        static void Calculate_time(int start_timmer, int start_minut, int start_sekund, int slut_timmer, int slut_minut, int slut_seckund, int startstartnummer)
        {
            if (start_timmer < slut_timmer)
            {
                int day1_sec = (start_timmer * 3600) + (start_minut * 60) + start_sekund;
                int day2_sec = (slut_timmer * 3600) + (slut_minut * 60) + slut_seckund;
                int diff2 = day2_sec - day1_sec;
                Calcul_winner(diff2, startstartnummer);

            }
            else
            {
                int day1_sec = (start_timmer * 3600) + (start_minut * 60) + start_sekund;
                int diff1 = 86400 - day1_sec;

                int day2_sec = (slut_timmer * 3600) + (slut_minut * 60) + slut_seckund;
                int diff2 = diff1 + day2_sec;
                Calcul_winner(diff2, startstartnummer);
            }
        }

        //-------------------------------------------------------------------------¨JÄMFÖR TID FÖRATT HITTA VINNARE------------------------------------------------
        static void Calcul_winner(int next_runtime, int next_startnummer)
        {
            
            if (winner != 0 && winner < next_runtime)
            {
                Console.WriteLine("jag är här");
            }
            else
            {
                winner_startnummer = next_startnummer;

               winner = next_runtime;
            }

        }

        //------------------------------------------------------------------------------START MENU-------------------------------------------
        static void Main(string[] args)
        {            

            Console.Write("Ange startnummer: ");
            int startstartnummer = Convert.ToInt32(Console.ReadLine());
 
            while (startstartnummer > 0)
            {
                antal_spelare += 1;
                Console.Write("Ange timme för start: ");
                int start_timmer = Convert.ToInt32(Console.ReadLine());
                Console.Write("Ange minut för start: ");
                int start_minut = Convert.ToInt32(Console.ReadLine());
                Console.Write("Ange sekund för start: ");
                int start_sekund = Convert.ToInt32(Console.ReadLine());
                Console.Write("Ange timme för mål: ");
                int slut_timmer = Convert.ToInt32(Console.ReadLine());
                Console.Write("Ange minut för mål: ");
                int slut_minut = Convert.ToInt32(Console.ReadLine());
                Console.Write("Ange sekund för mål: ");
                int slut_seckund = Convert.ToInt32(Console.ReadLine());
                //-------------------------------------------------------------------------------------------------------------------------
                Calculate_time(start_timmer, start_minut, start_sekund, slut_timmer, slut_minut, slut_seckund, startstartnummer);
                //-------------------------------------------------------------------------------------------------------------------------
                Console.Clear();
                Console.Write("Ange nästa startnummer: ");
                startstartnummer = Convert.ToInt32(Console.ReadLine());
            }
            Printer();

        }
    }
}
