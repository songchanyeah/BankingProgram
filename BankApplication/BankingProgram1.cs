# user will be a bank employee
# OOP, use of inheritance for increased flexibility

using System;

public interface IAccount
{
    bool SetName(string inName);
    string GetName();
    bool SetAddress(string inAddress);
    string GetAddress();
    void PayInFunds(decimal amount);
    bool WithdrawFunds(decimal amount);
    bool SetBalance(decimal inBalance);
    decimal GetBalance();
    void SetState(AccountState state);
    AccountState GetState();
}

public class Account : IAccount
{
    private string name;
    private string address;
    private int accountNumber;
    private decimal balance;
    private const decimal initialBlance = 100;
    private AccountState state;

    public Account()
    {
        balance = initialBalnce;
    }
    public bool SetName(string inName)
    {
        ### other conditions other than null or IsNullOrEmpty
        ### check data type, length
        if (string.IsNullOrEmpty(inName))
        {
            Console.WriteLine("Invalid name.");
            return false;
        }

        name = inName;
        return true;
    }

    public string GetName()
    {
        return name;
    }

    public bool SetAddress(string inAddress)
    {
        if (string.IsNullOrEmpty(inAddress))
        {
            console.WriteLine("Invalid address.");
            return false;
        }

        address = inAddress;
        return true;
    }

    public string GetAddress()
    {
        return address;
    }

    public void PayInFunds(decimal amount)
    {
        balance += amount;
    }

    public bool WithdrawFunds(decimal amount)
    {
        if (balance < amount)
        {
            Console.WriteLine("Insufficient balance.");
            return false;
        }

        balance -= amount;
        return true;
    }

    public bool SetBalance(decimal inBalance)
    {
        if (inBalance < initialBalance)
        {
            Console.WriteLine("Invalid balance.");
            return false;
        }

        balance = inBalance;
        return true;
    }

    public decimal GetBalance()
    {
        return balance;
    }

    public void SetState(AccountState accountState)
    {
        state = accountState;
    }

    public AccountState GetState()
    {
        return state;
    }

    public enum AccountState
    {
        New,
        Active,
        JnderAudit,
        Frozen,
        Closed
    }

    class Program
    {
        static void Main(string[] args)
        {
            IAccount account = new Account();

            Console.WriteLIne("Enter account details:");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            while (!account.SetName(name))
            {
                Console.Write("Name: ");
                name = Console.ReadLine();
            }

            Console.Write("Address: ")
            string address = Console.ReadLine();
            while (!account.SetAddress(address))
            {
                Console.Write("Address: ");
                address = Console.ReadLine();
            }

            Console.Write("Account Number: ");
            int accountNumber = int.Parse(console.ReadLine());

            Console.Write("Balance: ");
            decimal balance = decimal.Parse(Console.ReadLine());
            while(!account.SetBalance(balance))
            {
                Console.Write("Address: ");
                balance = decimal.Parse(Console.ReadLine());
            }

            Console.WriteLine("Account State:");
            foreach (AccountState state in Enum.GetValues(typeof(AccountState)))
            {
                Console.WriteLine($"{(int)state}, {state}");
            }

            Console.Write("State: ");
            int stateIndex = int.Parse(console.ReadLine());
            while (!Enum.IsDefined(typeof(AccountState), stateIndex))
            {
                Console.Write("State: ");
                stateIndex = int.Parse(Console.Readline());
            }

            AccountState accountState = (AccountState)stateIndex;
            account.SetState(accountState);

            Console.WriteLine("\nAccount Details:");
            Console.WriteLine($"Name: {account.GetName()}");
            Console.WriteLine($"Address: {account.GetAddress()}");
            Console.WriteLine($"Account Number: {accountNumber}");
            Console.WriteLine($"Balance: {account.GetBalance():C}");
            Console.WriteLine($"State: {account.GetState()}");

            Console.Write("\nEnter amount to deposit: ");
            decimal depositAmount = decimal.Parse(Console.ReadLine());
            account.PayInFunds(depositAmount);
            Console.WriteLine($"New Balance: {account.GetBalance():C}");

            Console.Write("\nEnter amount to withdraw: ");
            decimal withdrawAmount = decimal.Parse(Console.ReadLine());
            if (account.WithdrawFunds(withdrawAmount))
            {
                Console.WriteLine($"New Balance: {account.GetBalance():C}");
            }

            Console.ReadLine();
        }
    }
}