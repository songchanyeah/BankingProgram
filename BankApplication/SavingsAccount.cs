using System;

/// <summary>
/// Represents a savings account.
/// </summary>
public class SavingsAccount : Account
{
    private const decimal minimumBalance = 100;

    public SavingsAccount(string name, string address)
    {
        Name = name;
        Address = address;
        SetInitialBalance(minimumBalance);
        ServiceFee = 0;
        State = AccountState.New;
    }

    public override void DisplayAccountType()
    {
        Console.WriteLine("Account Type: Savings Account");
    }
}

