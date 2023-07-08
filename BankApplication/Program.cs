using System;

public class Program
{
    static void Main(string[] args)
    {
        IAccount account = new Account();

        // Set account data
        Console.WriteLine("Enter name:");
        string name = Console.ReadLine();
        while (!account.SetName(name))
        {
            Console.WriteLine("Invalid name. Please try again:");
            name = Console.ReadLine();
        }

        Console.WriteLine("Enter address:");
        string address = Console.ReadLine();
        while (!account.SetAddress(address))
        {
            Console.WriteLine("Invalid address. Please try again:");
            address = Console.ReadLine();
        }

        Console.WriteLine("Enter account number:");
        int accountNumber;
        while (!int.TryParse(Console.ReadLine(), out accountNumber))
        {
            Console.WriteLine("Invalid account number. Please enter a whole number:");
        }

        Console.WriteLine("Enter initial balance:");
        decimal initialBalance;
        while (!decimal.TryParse(Console.ReadLine(), out initialBalance))
        {
            Console.WriteLine("Invalid initial balance. Please enter a decimal number:");
        }
        while (!account.SetBalance(initialBalance))
        {
            Console.WriteLine("Initial balance must be at least $100. Please enter a valid initial balance:");
            while (!decimal.TryParse(Console.ReadLine(), out initialBalance))
            {
                Console.WriteLine("Invalid initial balance. Please enter a decimal number:");
            }
        }

        Console.WriteLine("Enter account state (New, Active, UnderAudit, Frozen, or Closed):");
        string accountStateInput = Console.ReadLine();
        AccountState accountState;
        while (!Enum.TryParse(accountStateInput, true, out accountState))
        {
            Console.WriteLine("Invalid account state. Please enter a valid account state:");
            accountStateInput = Console.ReadLine();
        }
        account.SetState(accountState);

        // Display account data
        Console.WriteLine("\nAccount Information");
        Console.WriteLine("Name: " + account.GetName());
        Console.WriteLine("Address: " + account.GetAddress());
        Console.WriteLine("Account Number: " + accountNumber);
        Console.WriteLine("Balance: " + account.GetBalance().ToString("C"));
        Console.WriteLine("State: " + accountState);

        // Test payInFunds method
        Console.WriteLine("\nEnter deposit amount:");
        decimal depositAmount;
        while (!decimal.TryParse(Console.ReadLine(), out depositAmount))
        {
            Console.WriteLine("Invalid deposit amount. Please enter a decimal number:");
        }
        account.PayInFunds(depositAmount);
        Console.WriteLine("New Balance after deposit: " + account.GetBalance().ToString("C"));

        // Test withdrawFunds method
        Console.WriteLine("\nEnter withdrawal amount:");
        decimal withdrawalAmount;
        while (!decimal.TryParse(Console.ReadLine(), out withdrawalAmount))
        {
            Console.WriteLine("Invalid withdrawal amount. Please enter a decimal number:");
        }
        if (account.WithdrawFunds(withdrawalAmount))
        {
            Console.WriteLine("New Balance after withdrawal: " + account.GetBalance().ToString("C"));
        }
        else
        {
            Console.WriteLine("Insufficient funds for withdrawal.");
        }
    }
}
