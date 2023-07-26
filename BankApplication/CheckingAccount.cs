using System;
/// <summary>
/// Represents a checking account.
/// </summary>
public class CheckingAccount : Account
{
    private const decimal minimumBalance = 10;

    public CheckingAccount(string name, string address)
    {
        Name = name;
        Address = address;
        SetInitialBalance(minimumBalance);
        ServiceFee = 5.0m;
        State = AccountState.New;
    }

    public override void DisplayAccountType()
    {
        Console.WriteLine("Account Type: Checking Account");
    }
}
