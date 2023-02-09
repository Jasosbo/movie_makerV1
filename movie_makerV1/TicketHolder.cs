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
        private List<string> snackOrder = new List<string>();
        private List<int> snackQuantity = new List<int>();
        private List<string> drinkOrder = new List<string>();
        private List<int> drinkQuantity = new List<int>();

        //constructor - constructs an object of this class

        public TicketHolder()
        {




        }


        //returns the value in the private age variable
        public int GetAge()
        {

            return 0;
        
        }

        //sets the value of the private age value
        public void SetAge(int newAge)
        { 
        
        
        }

        //returns the total cost for the ticket holders purchased items
        public float CalculateToatalCost()
        {

            return 0.0f;

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
