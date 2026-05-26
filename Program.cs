using System;
using System.Collections.Generic;
using System.Linq;



namespace Student_Budget_Tracker
{
    internal class Program
    {
        // ── Shared application state ─────────────────────────────────
        static List<Transaction> _transactions = new List<Transaction>();
        static double _maxSpendingLimit = 0;
        static int _nextId = 1; // auto-incrementing transaction ID

        // ── Entry point ──────────────────────────────────────────────
        static void Main(string[] args)
        {

            Console.WriteLine("---STUDENT BUDGET TRACKER---");

            Console.Write("Enter your name: ");
            string userName = Console.ReadLine();

            bool running = true;

            while (running)
            {
                ShowMainMenu(userName);

                int choice = GetValidInt("Enter choice (1-7): ");

                switch (choice)
                {
                    case 1:
                        AddIncome(userName);
                        break;

                    case 2:
                        AddExpense(userName);
                        break;

                    case 3:
                        ViewCategories();
                        break;

                    case 4:
                        CalculateMonthlyTotal();
                        break;

                    case 5:
                        SetSpendingLimit();
                        break;

                    case 6:
                        ViewAllTransactions();
                        break;

                    case 7:
                        Console.WriteLine("\nExiting... Goodbye, " + userName + "!");
                        running = false;
                        break;

                    default:
                        Console.WriteLine("\n[!] Invalid choice. Please enter a number between 1 and 7.\n");
                        break;
                }
            }
        }

        // ── Menus ─────────────────────────────────────────────────────

        static void ShowMainMenu(string userName)
        {

            Console.WriteLine("  Hi, " + userName + "! What would you like to do?");
            Console.WriteLine(" 1. Add Income");
            Console.WriteLine(" 2. Add Expense");
            Console.WriteLine(" 3. View Categories");
            Console.WriteLine(" 4. View Monthly Total");
            Console.WriteLine(" 5. Set Max Spending Limit");
            Console.WriteLine(" 6. View All Transactions");
            Console.WriteLine(" 7. Exit");
            Console.WriteLine("-----------------------------------------");
        }

        // ── Add Income ────────────────────────────────────────

        static void AddIncome(string userName)
        {
            Console.WriteLine("\n--- Add Income ---");
            Console.Write("Enter a description (e.g. 'Part-time job'): ");
            string description = Console.ReadLine();

            double amount = GetValidDouble("Enter income amount (R): ");

            Transaction newTransaction = new Transaction
            {
                TransactionID = _nextId++,
                UserName = userName,
                Type = "Income",
                Category = "Income",
                Description = description,
                Amount = amount,
                Date = DateTime.Now
            };

            _transactions.Add(newTransaction);
            Console.WriteLine("\n[+] Income of R" + amount.ToString("F2") + " added successfully!");
        }

        // ── Add Expense ───────────────────────────────────────

        static void AddExpense(string userName)
        {
            Console.WriteLine("\n--- Add Expense ---");
            Console.WriteLine("Select a category:");
            Console.WriteLine(" 1. Rent");
            Console.WriteLine(" 2. Groceries");
            Console.WriteLine(" 3. Entertainment");
            Console.WriteLine(" 4. Transport");
            Console.WriteLine(" 5. Student Materials");

            int categoryChoice = GetValidInt("Enter category (1-5): ");

            string category;
            switch (categoryChoice)
            {
                case 1: category = "Rent"; break;
                case 2: category = "Groceries"; break;
                case 3: category = "Entertainment"; break;
                case 4: category = "Transport"; break;
                case 5: category = "Student Materials"; break;
                default:
                    Console.WriteLine("[!] Invalid category. Expense not added.");
                    return; // exits the method early on invalid input
            }

            Console.Write("Enter a description (e.g. 'Woolworths run'): ");
            string description = Console.ReadLine();

            double amount = GetValidDouble("Enter expense amount (R): ");

            Transaction newTransaction = new Transaction
            {
                TransactionID = _nextId++,
                UserName = userName,
                Type = "Expense",
                Category = category,
                Description = description,
                Amount = amount,
                Date = DateTime.Now
            };

            _transactions.Add(newTransaction);
            Console.WriteLine("\n[-] Expense of R" + amount.ToString("F2") + " added under '" + category + "'.");

            CheckSpendingLimit();
        }

        // ── View Categories ───────────────────────────────────

        static void ViewCategories()
        {
            Console.WriteLine("\n--- View Categories ---");
            Console.WriteLine(" 1. Rent");
            Console.WriteLine(" 2. Groceries");
            Console.WriteLine(" 3. Entertainment");
            Console.WriteLine(" 4. Transport");
            Console.WriteLine(" 5. Student Materials");
            Console.WriteLine(" 6. All Categories");

            int viewChoice = GetValidInt("Enter choice (1-6): ");

            switch (viewChoice)
            {
                case 1: DisplayCategoryTotal("Rent"); break;
                case 2: DisplayCategoryTotal("Groceries"); break;
                case 3: DisplayCategoryTotal("Entertainment"); break;
                case 4: DisplayCategoryTotal("Transport"); break;
                case 5: DisplayCategoryTotal("Student Materials"); break;
                case 6: DisplayAllCategories(); break;
                default:
                    Console.WriteLine("[!] Invalid choice.");
                    break;
            }
        }

        // ── Monthly Total ─────────────────────────────────────

        static void CalculateMonthlyTotal()
        {
            Console.WriteLine("\n--- Monthly Total (" + DateTime.Now.ToString("MMMM yyyy") + ") ---");

            // Only looks at transactions from the current month and year
            var thisMonth = _transactions.Where(t =>
                t.Date.Month == DateTime.Now.Month &&
                t.Date.Year == DateTime.Now.Year).ToList();

            if (!thisMonth.Any())
            {
                Console.WriteLine("[!] No transactions found for this month.");
                return;
            }

            double totalIncome = thisMonth.Where(t => t.Type == "Income").Sum(t => t.Amount);
            double totalExpense = thisMonth.Where(t => t.Type == "Expense").Sum(t => t.Amount);
            double balance = totalIncome - totalExpense;

            Console.WriteLine("  Total Income  : R" + totalIncome.ToString("F2"));
            Console.WriteLine("  Total Expenses: R" + totalExpense.ToString("F2"));
            Console.WriteLine("  -----------------------------------");
            Console.WriteLine("  Balance       : R" + balance.ToString("F2"));

            if (balance < 0)
                Console.WriteLine("  [!] Warning: You are spending more than you earn!");

            CheckSpendingLimit();
        }

        // ── Set Spending Limit ────────────────────────────────

        static void SetSpendingLimit()
        {
            Console.WriteLine("\n--- Set Max Spending Limit ---");
            _maxSpendingLimit = GetValidDouble("Enter your max spending limit (R): ");
            Console.WriteLine("[+] Spending limit set to R" + _maxSpendingLimit.ToString("F2"));
            CheckSpendingLimit(); // checks immediately after setting
        }

        // ── View All Transactions ─────────────────────────────

        static void ViewAllTransactions()
        {
            Console.WriteLine("\n--- All Transactions ---");

            if (!_transactions.Any())
            {
                Console.WriteLine("[!] No transactions recorded yet.");
                return;
            }

            Console.WriteLine(
                " {0,-4} {1,-12} {2,-18} {3,-22} {4,10}  {5}",
                "ID", "Type", "Category", "Description", "Amount", "Date"
            );
            Console.WriteLine(new string('-', 85));

            foreach (var t in _transactions)
            {
                string sign = t.Type == "Income" ? "+" : "-";
                Console.WriteLine(
                    " {0,-4} {1,-12} {2,-18} {3,-22} {4,10}  {5}",
                    t.TransactionID,
                    t.Type,
                    t.Category,
                    t.Description.Length > 20 ? t.Description.Substring(0, 20) : t.Description,
                    sign + "R" + t.Amount.ToString("F2"),
                    t.Date.ToString("dd/MM/yyyy HH:mm")
                );
            }
        }

        // ── Display total for one category ────────────────────

        static void DisplayCategoryTotal(string categoryName)
        {
            var categoryTransactions = _transactions
                .Where(t => t.Category == categoryName)
                .ToList();

            if (!categoryTransactions.Any())
            {
                Console.WriteLine("[!] No transactions found for '" + categoryName + "'.");
                return;
            }

            double categoryTotal = categoryTransactions.Sum(t => t.Amount);
            Console.WriteLine("\n  " + categoryName + " Total: R" + categoryTotal.ToString("F2"));
            Console.WriteLine("  Transactions:");
            foreach (var t in categoryTransactions)
            {
                Console.WriteLine(
                    "    [ID {0}] {1} - R{2} on {3}",
                    t.TransactionID,
                    t.Description,
                    t.Amount.ToString("F2"),
                    t.Date.ToString("dd/MM/yyyy")
                );
            }
        }

        // ── Display totals for all expense categories ─────────

        static void DisplayAllCategories()
        {
            string[] categories = { "Rent", "Groceries", "Entertainment", "Transport", "Student Materials" };

            Console.WriteLine("\n  Category Breakdown:");
            Console.WriteLine(new string('-', 35));

            foreach (var cat in categories)
            {
                double total = _transactions
                    .Where(t => t.Category == cat)
                    .Sum(t => t.Amount);

                Console.WriteLine("  {0,-20}: R{1}", cat, total.ToString("F2"));
            }
        }

        // ── Check if spending limit has been exceeded ─────────

        static void CheckSpendingLimit()
        {
            if (_maxSpendingLimit <= 0) return; // no limit set, skip check

            double totalExpense = _transactions
                .Where(t => t.Type == "Expense")
                .Sum(t => t.Amount);

            double percentUsed = (totalExpense / _maxSpendingLimit) * 100;

            if (totalExpense > _maxSpendingLimit)
            {
                Console.WriteLine("\n  *** ALERT: You have exceeded your spending limit! ***");
                Console.WriteLine("  Spent: R" + totalExpense.ToString("F2") +
                                  " / Limit: R" + _maxSpendingLimit.ToString("F2"));
            }
            else if (totalExpense >= _maxSpendingLimit * 0.8)
            {
                Console.WriteLine("\n  [!] Warning: You have used " + percentUsed.ToString("F0") +
                                  "% of your spending limit.");
                Console.WriteLine("  Spent: R" + totalExpense.ToString("F2") +
                                  " / Limit: R" + _maxSpendingLimit.ToString("F2"));
            }
        }



        // Keeps asking until the user enters a valid integer
        static int GetValidInt(string prompt)
        {
            int result;
            Console.Write(prompt);
            while (!int.TryParse(Console.ReadLine(), out result))
            {
                Console.WriteLine("[!] Invalid input. Please enter a whole number.");
                Console.Write(prompt);
            }
            return result;
        }

        // Keeps asking until the user enters a valid positive decimal
        static double GetValidDouble(string prompt)
        {
            double result;
            Console.Write(prompt);
            while (!double.TryParse(Console.ReadLine(), out result) || result <= 0)
            {
                Console.WriteLine("[!] Invalid input. Please enter a positive number (e.g. 150.00).");
                Console.Write(prompt);
            }
            return result;
        }



        // Represents a single financial event (income or expense)
        class Transaction
        {
            public int TransactionID { get; set; } // unique ID, auto-assigned
            public string UserName { get; set; } // name of the user who added it
            public string Type { get; set; } // "Income" or "Expense"
            public string Category { get; set; } // e.g. "Rent", "Groceries"
            public string Description { get; set; } // short user-provided note
            public double Amount { get; set; } // in Rands (R)
            public DateTime Date { get; set; } // automatically set to now
        }
    }
}
