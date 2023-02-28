using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace movie_makerV1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List<string> avaliableSnacks = new List<string>() { "popcorn", "chips", "chocolate" };
            List<float> snackPrices = new List<float>() { 2.50f, 1.50f, 2 };

            List<string> avaliabledrinks = new List<string>() { "Fanta", "l&P" };
            List<float> drinkPrices = new List<float>() { 2.50f, 1.50f };

            float ticketPrice = 5f;

            TicketHolder testTH = new TicketHolder("Charlie", 16, 3);


            List<int> S = new List<int>() { 0, 2 };
            List<int> Sq = new List<int>() { 2, 1 };

            testTH.AddSnacks(S, Sq);

            List<int> D = new List<int>() { 1 };
            List<int> Dq = new List<int>() { 2 };

            testTH.AddDrinks(D, Dq);

            testTH.SetCredit(true);
                
            Console.WriteLine($"{testTH.GenerateRecipet(ticketPrice, avaliableSnacks, snackPrices, avaliabledrinks, drinkPrices)}");

            Console.ReadLine();
        }
    }
}
