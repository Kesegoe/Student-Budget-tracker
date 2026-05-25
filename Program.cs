using System;
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
    
    
