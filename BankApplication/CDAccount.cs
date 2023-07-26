using System;
/// <summary>
/// Represents a certificate of deposit account.
/// </summary>
public class CDAccount : Account
{
    private const decimal minimumBalance = 500;

    public CDAccount(string name, string address)
    {
        Name = name;
        Address = address;
        SetInitialBalance(minimumBalance);
        ServiceFee = 8.0m;
        State = AccountState.New;
    }

    public override void DisplayAccountType()
    {
        Console.WriteLine("Account Type: CD Account");
    }
}


