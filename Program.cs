<<<<<<< Updated upstream
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRG_172_Project_2_Budget_Tracker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<String> transactionTypes = new List<String>();
            List<int> amount = new List<int>();
            List<String> categories = new List<String>();
            int totalIncome = 0;
            int totalExpenses = 0;
            int choice = 0;
            string category;


            while (choice != 5)
            {
                Console.WriteLine("1. Add Income ");
                Console.WriteLine("2. Add Expense ");
                Console.WriteLine("3  View Transaction ");
                Console.WriteLine("4. Generate Summary ");
                Console.WriteLine("5. Exit  ");


                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.WriteLine(" Enter an Amount ");
                        amount.Add(Convert.ToInt32(Console.ReadLine()));
                        Console.WriteLine("Enter Category");
                        categories.Add(Console.ReadLine());
                        transactionTypes.Add("Income");
                        // foreach (int run  in amount)
                        // totalIncome = totalIncome + run;
                        totalIncome = totalIncome + amount[amount.Count - 1];
                        Console.WriteLine("You have successfully added an Amount.");
                        break;
                    case 2:
                        Console.WriteLine(" Add an Expense ");
                        //totalExpenses = Convert.ToInt32(Console.ReadLine());
                        amount.Add(Convert.ToInt32(Console.ReadLine()));
                        //you can do the same thing and remove the foreach
                        Console.WriteLine("Enter Category");
                        categories.Add(Console.ReadLine());
                        transactionTypes.Add("Expense");
                        totalExpenses = totalExpenses + amount[amount.Count - 1];
                        //foreach (int run in amount)
                        //    totalIncome = totalIncome + run;
                        Console.WriteLine("You have successfully added an Expense.");
                        break;
                    case 3:
                        if (transactionTypes.Count == 0)
                        {
                            Console.WriteLine("No transactions found");
                        }
                        else
                        {
                            for (int i = 0; i < transactionTypes.Count; i++)
                            {
                                Console.WriteLine(transactionTypes[i] + " | " + amount[i] + " | " + categories[i]);
                            }
                        }
                        break;

                    case 4:
                        Console.WriteLine("Total Income: " + totalIncome);
                        Console.WriteLine("Total Expenses: " + totalExpenses);
                        Console.WriteLine("Balance: " + (totalIncome - totalExpenses));
                        break;

                    case 5:
                        Console.WriteLine("Goodbye, have a great day! ");
                        break;

                    default:
                        Console.WriteLine("Invalid option selected, please try again. ");
                        break;






                }

            }
        }
    }
}
    
    
=======
﻿using System;
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


                        //further additions to the case statements are added 20:21 pm 24/05/2026
                        Transaction newTransation = new Transaction();
                        newTransation.type = "Income";
                        newTransation.Category = "Income";
                        newTransation.Amount = Convert.ToDouble(Console.ReadLine());
                        _transactions.Add(newTransation);
                        Console.WriteLine("Income Added");


                        break;

                    case 2:

                        Console.WriteLine("Add Expense"); // code to add expense

                        //05:23AM changes to the case statements to add catagories //
                        Transaction newTransaction =new Transaction();
                        newTransaction.type = "Expense";
                        ////////////////////////////////////////////
                        Console.WriteLine("==== Expense Categories ====");
                        Console.WriteLine("1. Rent");
                        Console.WriteLine("2. Groceries");
                        Console.WriteLine("3. Entertainment");
                        Console.WriteLine("4. Transport");
                        Console.WriteLine("5. Student material");

                        int ChoiceCatagory = Convert.ToInt32(Console.ReadLine());

                        switch (ChoiceCatagory)
                        {
                            case 1:
                                newTransaction.Category = "Rent";
                                break;
                            case 2:
                                newTransaction.Category = "Groceries";
                                break;
                            case 3:
                                newTransaction.Category = "Entertainment";
                                break;
                            case 4:
                                newTransaction.Category = "Transport";
                                break;
                            case 5:
                                newTransaction.Category = "Student material";
                                break;
                            default:
                                Console.WriteLine("Invalid category. Please try again.");
                                break;
                        }

                        Console.WriteLine("Enter the amount of the expense: ");
                        newTransaction.Amount = Convert.ToDouble(Console.ReadLine());
                        _transactions.Add(newTransaction);
                            Console.WriteLine("Expense Added");



                        break;

                    case 3:

                        Console.WriteLine("View Catagories"); // code to view catagories

                        foreach (var transaction in _transactions) // helps us print out Rands for all the transactions
                        {
                            Console.WriteLine(transaction.Category + " R" + transaction.Amount);
                        }

                        break;

                    case 4:

                        Console.WriteLine("View Monthly total"); // code to view monthly total

                        CalculateMonthlyTotal();  // links this back to the method added later

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

        ///////this is the main menu of the program. itss made to loop until the user chooses to exit. it also has a switch statement to handle the different choices thee user can make. each case is a different option in the menu. the code for each option is not yet implemented, but it will be added later.
       
        ///im puting the methods for calcuculating the mothly totals ///
        static void CalculateMonthlyTotal()// loops through the list and calculates the total
        {
            double totalIncome = 0;
            double totalExpense = 0;
            foreach (var transaction in _transactions)
            {
                if (transaction.type == "Income")
                {
                    totalIncome += transaction.Amount;
                }
                else if (transaction.type == "Expense")
                {
                    totalExpense += transaction.Amount;
                }
            }
            double monthlyTotal = totalIncome - totalExpense;
            Console.WriteLine($"Monthly Total: {monthlyTotal}");
        }
        ///////this section is where we'll use classes to create objects for the different catagories of income and expenses./////

        class Transaction      // this is a class that will be used to create objects for each transaction (income or expense) that the user adds. it has properties for the transaction id, category, and amount.
        {
            public string UserName { get; set; } // this will be for adding usernames
            public int TransactionID { get; set; }// this will be used to uniquely identify each transaction

            public string type { get; set; } // this will be used to differentiate between income and expenses

            public string Category { get; set; }// this will be used to categorize the transaction (e.g. rent, groceries, etc.)

            public double Amount { get; set; } // this will be used to store the amount of the transaction
        }


        //DO NOT FORGET TO MAKE IT STATIC OTHERWISE IT WONT WORK IN THE MAIN METHOD. this is because the main method is static and it can only access static members of the class. if we make the list of transactions static, then we can access it from the main method and add transactions to it.
        static List<Transaction> _transactions = new List<Transaction>();  // this is a list that will be used to store all the transactions that the user adds. it will be used to calculate the monthly total and to view the categories.hopefully :)

        




    }  

}
>>>>>>> Stashed changes
