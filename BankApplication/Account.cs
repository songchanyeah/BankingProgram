public enum AccountState
{
    New,
    Active,
    UnderAudit,
    Frozen,
    Closed
}

public class Account : IAccount
{
    private string name;
    private string address;
    private int accountNumber;
    private decimal balance;
    private const decimal initialBalance = 100;
    private AccountState state;

    public bool SetName(string inName)
    {
        if (string.IsNullOrEmpty(inName))
            return false;

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
            return false;

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
        if (balance - amount < 0)
            return false;

        balance -= amount;
        return true;
    }

    public bool SetBalance(decimal inBalance)
    {
        if (inBalance < initialBalance)
            return false;

        balance = inBalance;
        return true;
    }

    public decimal GetBalance()
    {
        return balance;
    }

    public void SetState(AccountState state)
    {
        this.state = state;
    }
}
