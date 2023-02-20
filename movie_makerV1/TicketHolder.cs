using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace movie_makerV1
{
    internal class TicketHolder
    {

        //attributes or fields

        private string name;
        private int age;
        private int numberTickets;
        private bool credit;
        //stores the indexs of the snacks that has been ordered
        private List<int> snackOrder = new List<int>();
        private List<int> snackQuantity = new List<int>();
        //stroes the indexs of the drinks that has been ordered
        private List<int> drinkOrder = new List<int>();
        private List<int> drinkQuantity = new List<int>();

        //constructor - constructs an object of this class

        public TicketHolder(string name, int age, int nTickets)
        {


            this.name = name;
            this.age = age;
            numberTickets = nTickets;

        }


        //returns the value in the private age variable
        public int GetAge()
        {

            return this.age;

        }

        //sets the value of the private age value
        public void SetAge(int newAge)
        {
            this.age = newAge;

        }

        //set the value 
        public void SetCredit(bool newPaymentType)
        {

            credit = newPaymentType;


        }


        //add snacks and quantitys to the snackorder list and snackquantity list
        public void AddSnacks(List<int> snacks, List<int> quantities)
        {

            snackOrder = snacks;
            snackQuantity = quantities;
        
        }

        //add drinks and quantitys to the drinkorder list and drinkquantity list
        public void AddDrinks(List<int> drinks, List<int> quantities)
        {

            drinkOrder = drinks;
            drinkQuantity = quantities;

        }


        //returns string stating if the ticket holder is paying cash or credit

        private string PaymentType()
        {

            string paymentType = "credit";
            if (credit == false) 
            {
                paymentType = "cash";
            }

            return paymentType;
        }


        //returns the total cost for the ticket holders purchased items
        public float CalculateToatalCost(List<float> sPrice,List<float> dPrice)
        {
            float totalCost = 0f;


            //loop through snack order and calculate the cost for each snack

            for (int snackIndex = 0; snackIndex < snackOrder.Count; snackIndex++)
            {

                float snackPrice = sPrice[snackOrder[snackIndex]];

                //add the cost of each snack to totalCost
                totalCost += snackPrice * snackQuantity[snackIndex];


            }
            
            //loop through drink order and calculate the cost for each drink
            for (int drinkIndex = 0; drinkIndex < drinkOrder.Count; drinkIndex++)
            {
                float drinkPrice = dPrice[drinkOrder[drinkIndex]];

                //add the cost of each drink to totalCost
                totalCost += drinkPrice * drinkQuantity[drinkIndex];


            }



            return totalCost;

        }


        //calcualte the ticket cost

        public float CalculateTicketCost(float ticketPrice)
        {

            return numberTickets * ticketPrice;


        }



        // returns a string displaying the recipet of the ticket holders puruchased items
        public string GenerateRecipet()
        {

            return "";

        }

        //returns a string collating all the values stored in the private variables
        public override string ToString()
        {

            return "";
        
        }





    }
}
