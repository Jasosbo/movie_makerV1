using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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

        private List<string> availableSnacks = new List<string>() { "popcorn", "chips", "chocolate" };
        private List<float> snackPrices = new List<float>() { 2.50f, 1.50f, 2 };

        List<string> availableDrinks = new List<string>() { "Fanta", "l&P" };
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
            availableSnacks.Add(snack);
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

        //calculate and return gross profit for ticket sales
        private float CalculateTicketGrossProfit()
        {
            int sumTicketSold = 0;

            foreach (TicketHolder ticketHolder in ticketHolders)
            {

                sumTicketSold += ticketHolder.GetTickets();

            }

            return sumTicketSold * ticketPrice;
        }



        private int sumItemsSold(string itemType)
        {

            List<string> availableItems;
            


            if (itemType.Equals("snacks"))
            {
                availableItems = availableSnacks;
            }
            else
            {
                availableItems = availableDrinks;
            }

            //collection storing the total quantities sold for item

            List<int> sumItemsSold = new List<int>();

            for (int availableSItemIndex = 0; availableSItemIndex < availableItems.Count; availableSItemIndex++)
            {
                sumItemsSold.Add(0);
            }

            foreach (TicketHolder ticketHolder in ticketHolders)
            {
                List<int> orderedItems, itemsQuantitys;

                if (itemType.Equals("snacks"))
                {
                    orderedItems = ticketHolder.GetSnackOrder();
                    itemsQuantitys = ticketHolder.GetSnackQuantity();
                }
                else
                {
                    orderedItems = ticketHolder.GetDrinkOrder();
                    itemsQuantitys = ticketHolder.GetDrinkQuantity();
                }

                //loop through ordered item
                for (int orderIndex = 0; orderIndex < orderedItems.Count; orderIndex++)
                {

                    //loop through ordered item
                    for (int itemIndex = 0; itemIndex < availableItems.Count; itemIndex++)
                    {

                        //check if ticketholder has purchaced item
                        if (itemIndex == orderedItems[orderIndex])
                        {
                            //add quantity to sumSnacksSold
                            sumItemsSold[itemIndex] += itemsQuantitys[orderIndex];
                        }

                    }


                }

            }

        }
        private float CalculateItemGrossProfit()
        {


        }

        //calculate gross profit for snacks and drinks sales
        private float CalculateSnackOrderGrossProfit()
        {
            //collection storing the total quantitys sold for snacks and drinks

            List<int> sumSnackSold = new List<int>();
            List<int> sumDrinkSold = new List<int>();


            //setup sum lists with the correct number of items
            for (int availableSnackIndex = 0; availableSnackIndex < availableSnacks.Count; availableSnackIndex++)
            {
                sumSnackSold.Add(0);

            }
            for (int availableDrinksIndex = 0;  availableDrinksIndex < availableDrinks.Count;  availableDrinksIndex++)
            {
                sumDrinkSold.Add(0);
                
            }

            //loop through ticketholders calculating the sum of quantitys sold for each snack and drink

            foreach (TicketHolder ticketHolder in ticketHolders)
            {

                //store the ticketholders ordered snacks and their quantitys
                List<int> orderedSnacks = ticketHolder.GetSnackOrder();
                List<int> snackQuantitys = ticketHolder.GetSnackQuantity();


                // loop through the ordered snacks
                for (int orderIndex = 0; orderIndex < orderedSnacks.Count; orderIndex++)
                {

                    for (int snackIndex = 0; snackIndex < availableSnacks.Count; snackIndex++)
                    {

                        //check if ticketholder has purchased snack

                        if (snackIndex == orderedSnacks[orderIndex])
                        {
                            //add quantity to sumSnackSold
                            snackQuantitys[snackIndex] += snackQuantitys[orderIndex];

                        }




                    }

                }


                //store the ticketholders ordered snacks and their quantitys
                List<int> orderedDrinks = ticketHolder.GetDrinkOrder();
                List<int> drinkQuantity = ticketHolder.GetDrinkQuantity();


                // loop through the ordered snacks
                for (int orderIndex = 0; orderIndex < orderedDrinks.Count; orderIndex++)
                {

                    for (int drinkIndex = 0; drinkIndex < availableDrinks.Count; drinkIndex++)
                    {

                        //check if ticketholder has purchased snack

                        if (drinkIndex == orderedDrinks[orderIndex])
                        {
                            //add quantity to sumSnackSold
                            drinkQuantity[drinkIndex] += drinkQuantity[orderIndex];

                        }




                    }

                }

            }

            //calculate total gross profit bo multiplying the sum quantity of each item with its price

            float grossProfit = 0;


            for (int snackIndex = 0; snackIndex < sumSnackSold.Count; snackIndex++)
            {
                grossProfit += sumSnackSold[snackIndex] * snackPrices[snackIndex];
            }


            for (int drinkIndex = 0; drinkIndex < sumDrinkSold.Count; drinkIndex++)
            {
                grossProfit += sumDrinkSold[drinkIndex] * drinkPrices[drinkIndex];
            }

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
