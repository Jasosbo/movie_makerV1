using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace movie_makerV1
{
    internal class TicketManager
    {

        //attributes
        private List<TicketHolder> ticketHolders = new List<TicketHolder>(); 

        private List<string> avaliableSnacks = new List<string>() { "popcorn", "chips", "chocolate" };
        private List<float> snackPrices = new List<float>() { 2.50f, 1.50f, 2 };

        List<string> avaliabledrinks = new List<string>() { "Fanta", "l&P" };
        List<float> drinkPrices = new List<float>() { 2.50f, 1.50f };

        float ticketPrice = 5f;

        private List<int> ageLimit = new List<int>() { 12 };

        private const int SEATLIMIT = 150; 

        //constructor - constructs a ticketmanager object
        public TicketManager()
        {


        }

        //reterns true if the purchasers age meets the age requirments else it returns back false
        public bool checkAge(int buyerAge,int ageLimitIndex)
        {

            bool isOfAge = true;

            if (buyerAge < ageLimit[ageLimitIndex])
            {
                isOfAge= false;
            
            
            }

            return isOfAge;

        }

        public int calculateAvaliableSeats()
        {

            int numTickets = 0;

            foreach ( TicketHolder ticketHolder in ticketHolders)
            {
                numTickets += ticketHolder.GetTickets();

            }

            return SEATLIMIT - numTickets;

        }

        //check avaliable seats, returns true if there are avaliable seat
        public bool checkAvaliableSeats(int requestNoTickets)
        {
            if ((calculateAvaliableSeats() - requestNoTickets) < 0 )
            {
            
                return false;

            }

            return true; 
        
        }

        //add new snack and snack prices to the snack and price list
        public void addSnack(string snack,float price)
        {
            avaliableSnacks.Add(snack);
            snackPrices.Add(price);


        }
        
        //adds new age to the age limit lists
        public void addAgeLimit(int newAge)
        {
            ageLimit.Add(newAge);
            ageLimit.Sort();

        }

        //sets a new value for the ticket price
        public void changeTicketPrice(float newTicketPrice)
        {

            ticketPrice = newTicketPrice;

        }

        private float CalculateTicketGrossProfit()
        {

            return 0f;
        }

        private float CalculateSnackOrderGrossProfit()
        {
            return 0f;
        }



        //calculates the total net profit for the sales
        public float CalculateTotalProfit()
        {

            return 0f;

        }

        //returns a string listing the total number for snacks ordered
        public string totalSnacksOrdered()
        {

            return totalSnacksOrdered(); 

        }

        //returns all atributes as a string
        public string Tostring()
        {
           
            return base. ToString();


        }





    }
}
