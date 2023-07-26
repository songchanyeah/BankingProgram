using System;
/// <summary>
/// Represents the main program class.
/// </summary>
class Program
{
    /// <summary>
    /// The entry point of the program.
    /// </summary>
    /// <param name="args">Command-line arguments (not used).</param>
    static void Main(string[] args)
    {
        IArrayBank bank = new ArrayBank();
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("1. Create Account");
            Console.WriteLine("2. Search Account");
            Console.WriteLine("3. Display All Accounts");
            Console.WriteLine("4. Exit");
            Console.Write("Enter your choice (1-4): ");

            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                switch (choice)
                {
                    case 1:
                        CreateAccount(bank);
                        break;
                    case 2:
                        SearchAccount(bank);
                        break;
                    case 3:
                        DisplayAllAccounts(bank);
                        break;
                    case 4:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }
        }
    }

    /// <summary>
    /// Prompts the user to create a new account and adds it to the bank.
    /// </summary>
    /// <param name="bank">The bank to store the account.</param>
    static void CreateAccount(IArrayBank bank)
    {
        Console.WriteLine("Enter account type (Savings/Checking/CD): ");
        string accountType = Console.ReadLine().ToLower();

        Console.WriteLine("Enter account holder's name: ");
        string name = Console.ReadLine();

        Console.WriteLine("Enter account holder's address: ");
        string address = Console.ReadLine();

        Account account;

        switch (accountType)
        {
            case "savings":
                account = new SavingsAccount(name, address);
                break;
            case "checking":
                account = new CheckingAccount(name, address);
                break;
            case "cd":
                account = new CDAccount(name, address);
                break;
            default:
                Console.WriteLine("Invalid account type.");
                return;
        }

        if (bank.StoreAccount(account))
        {
            Console.WriteLine($"Account created successfully. Account Number: {account.AccountNumber}");
        }
        else
        {
            Console.WriteLine("Account creation failed. Account Number already exists.");
        }
    }

    /// <summary>
    /// Prompts the user to enter an account number and searches for the account in the bank.
    /// </summary>
    /// <param name="bank">The bank to search for the account.</param>
    static void SearchAccount(IArrayBank bank)
    {
        Console.WriteLine("Enter account number to search: ");
        string accountNumber = Console.ReadLine();

        Account account = bank.FindAccount(accountNumber);

        if (account != null)
        {
            Console.WriteLine($"Account found. Account Number: {account.AccountNumber}");
            account.DisplayAccountType();
            Console.WriteLine($"Account Holder: {account.Name}");
            Console.WriteLine($"Address: {account.Address}");
            Console.WriteLine($"Balance: {account.Balance}");
            Console.WriteLine($"State: {account.State}");
            Console.WriteLine($"Service Fee: {account.ServiceFee}");
        }
        else
        {
            Console.WriteLine("Account not found.");
        }
    }
     /// <summary>
    /// Displays information about all accounts stored in the bank.
    /// </summary>
    /// <param name="bank">The bank containing the accounts.</param>
    static void DisplayAllAccounts(IArrayBank bank)
    {
        Account[] accounts = bank.GetAllAccounts();

        if (accounts.Length > 0)
        {
            foreach (var account in accounts)
            {
                Console.WriteLine($"Account Number: {account.AccountNumber}");
                account.DisplayAccountType();
                Console.WriteLine($"Account Holder: {account.Name}");
                Console.WriteLine($"Address: {account.Address}");
                Console.WriteLine($"Balance: {account.Balance}");
                Console.WriteLine($"State: {account.State}");
                Console.WriteLine($"Service Fee: {account.ServiceFee}");
                Console.WriteLine("------------------------");
            }
        }
        else
        {
            Console.WriteLine("No accounts found.");
        }
    }
}
