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
                Console.WriteLine("5. Add Max Spending Limit");
                Console.WriteLine("6. Exit");

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

                        CheckSpendingLimit(); // checks if the expense is over the max limit


                        break;

                    case 3:

                        Console.WriteLine("View Catagories"); // code to view catagories

                        ViewCatagories(); // this links to the catagory switch case section

                        break;

                    case 4:

                        Console.WriteLine("View Monthly total"); // code to view monthly total

                        CalculateMonthlyTotal();  // links this back to the method added later

                        break;

                    case 5:

                        Console.WriteLine("Add Max Spending Limit"); // code to add max spending limit
                        maxSpendingLimit = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("Max Spending Limit Added");
                        CheckSpendingLimit(); // checks the spending limit straight away

                        break;

                    case 6:


                        Console.WriteLine("Exiting..."); // code to exit the program
                        running = false;// this will break the loop and end the program
                        break;

                    default:

                        Console.WriteLine("Incorrect choice. Please try again."); // code to handle invalid input such as a number that is not 1-6
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
            CheckSpendingLimit(); // checks if the user has gone over their limit
        }

        ///this is the section for viewing the catagories with a switch statement ///
        static void ViewCatagories()
        {
            Console.WriteLine("==== View Categories ====");
            Console.WriteLine("1. Rent");
            Console.WriteLine("2. Groceries");
            Console.WriteLine("3. Entertainment");
            Console.WriteLine("4. Transport");
            Console.WriteLine("5. Student material");
            Console.WriteLine("6. All Catagories");

            int ViewCatagoryChoice = Convert.ToInt32(Console.ReadLine());

            switch (ViewCatagoryChoice)
            {
                case 1:
                    DisplayCatagoryTotal("Rent");
                    break;
                case 2:
                    DisplayCatagoryTotal("Groceries");
                    break;
                case 3:
                    DisplayCatagoryTotal("Entertainment");
                    break;
                case 4:
                    DisplayCatagoryTotal("Transport");
                    break;
                case 5:
                    DisplayCatagoryTotal("Student material");
                    break;
                case 6:
                    foreach (var transaction in _transactions) // helps us print out Rands for all the transactions
                    {
                        Console.WriteLine(transaction.Category + " R" + transaction.Amount);
                    }
                    break;
                default:
                    Console.WriteLine("Invalid category. Please try again.");
                    break;
            }
        }

        ///this method prints the total for one catagory ///
        static void DisplayCatagoryTotal(string catagoryName)
        {
            double catagoryTotal = 0;

            foreach (var transaction in _transactions)
            {
                if (transaction.Category == catagoryName)
                {
                    catagoryTotal += transaction.Amount;
                }
            }

            Console.WriteLine(catagoryName + " Total: R" + catagoryTotal);
        }

        ///this method checks if the user is over the max spending limit ///
        static void CheckSpendingLimit()
        {
            double totalExpense = 0;

            foreach (var transaction in _transactions)
            {
                if (transaction.type == "Expense")
                {
                    totalExpense += transaction.Amount;
                }
            }

            if (maxSpendingLimit > 0 && totalExpense > maxSpendingLimit)
            {
                Console.WriteLine("WARNING: You have gone over your max spending limit!");
            }
            else if (maxSpendingLimit > 0 && totalExpense >= (maxSpendingLimit * 0.8))
            {
                Console.WriteLine("WARNING: You are close to your max spending limit!");
            }
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
        static double maxSpendingLimit = 0; // this will store the max spending limit for the user

        




    }  

}
