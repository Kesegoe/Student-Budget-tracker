using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Student_Budget_tracker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool running = true; // allows us to  loop the program until the user chooses to exit
            while (running)
            {
                Console.WriteLine("== Student Budget Tracker ==");
                Console.WriteLine("1. Add Income");
                Console.WriteLine("2. Add Expense");
                Console.WriteLine("3. View Catagories");
                Console.WriteLine("4. View Monthly total");
                Console.WriteLine("5. Exit");

                int choice = Convert.ToInt32(Console.ReadLine()); // gets user input which is a int and stores it in choice

                switch (choice)
                {

                    case 1:

                        Console.WriteLine("Add Income");  // code to add income

                        break;

                    case 2:

                        Console.WriteLine("Add Expense"); // code to add expense
                        break;

                    case 3:

                        Console.WriteLine("View Catagories"); // code to view catagories
                        break;

                    case 4:

                        Console.WriteLine("View Monthly total"); // code to view monthly total
                        break;

                    case 5:


                        Console.WriteLine("Exiting..."); // code to exit the program
                        running = false;// this will break the loop and end the program
                        break;

                    default:

                        Console.WriteLine("Incorrect choice. Please try again."); // code to handle invalid input such as a number that is not 1-5
                        break;
                }

            }
        }

        ///////this is the main menu of the program. its made to loop until the user chooses to exit. it also has a switch statement to handle the different choices the user can make. each case is a different option in the menu. the code for each option is not yet implemented, but it will be added later.

        ///////this section is where we'll use classes to create objects for the different catagories of income and expenses./////

        class Transaction      // this is a class that will be used to create objects for each transaction (income or expense) that the user adds. it has properties for the transaction id, category, and amount.
        {
            public int TransactionID { get; set; }// this will be used to uniquely identify each transaction

            public string type { get; set; } // this will be used to differentiate between income and expenses

            public string Category { get; set; }// this will be used to categorize the transaction (e.g. rent, groceries, etc.)

            public double Amount { get; set; } // this will be used to store the amount of the transaction
        }

        List<Transaction> _transactions = new List<Transaction>();  // this is a list that will be used to store all the transactions that the user adds. it will be used to calculate the monthly total and to view the categories.hopefully :)

        




    }  

}
