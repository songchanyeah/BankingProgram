using System;

/// <summary>
/// Represents the state of an account.
/// </summary>
public enum AccountState
{
    New,
    Active,
    UnderAudit,
    Frozen,
    Closed
}



/// <summary>
/// Represents an abstract bank account.
/// </summary>
public abstract class Account
{
    private string name;
    private string address;
    private string accountNumber;
    protected decimal balance;
    private AccountState state;
    private decimal serviceFee;
    
    private static int accountNumberCounter = 1000;


    public Account()
    {
        GenerateAccountNumber();
    }
    /// <summary>
    /// Gets or sets the account name.
    /// </summary>
    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    /// <summary>
    /// Gets or sets the account address.
    /// </summary>
    public string Address
    {
        get { return address; }
        set { address = value; }
    }

    /// <summary>
    /// Gets the account number.Get
    /// </summary>
    public string AccountNumber
    {
        get { return accountNumber; }
    }

    /// <summary>
    /// Gets the account balance.
    /// </summary>
    public decimal Balance
    {
        get { return balance; }
    }

    /// <summary>
    /// Gets or sets the account state.
    /// </summary>
    public AccountState State
    {
        get { return state; }
        set { state = value; }
    }

    /// <summary>
    /// Gets or sets the account service fee.
    /// </summary>
    public decimal ServiceFee
    {
        get { return serviceFee; }
        set { serviceFee = value; }
    }

    /// <summary>
    /// Displays the account type.
    /// </summary>
    public abstract void DisplayAccountType();

    /// <summary>
    /// Generates the account number based on the account type.
    /// </summary>
    protected virtual void GenerateAccountNumber()
    {
        int currentAccountNumber = accountNumberCounter++;
        accountNumber = $"{currentAccountNumber:D6}";
    }

    /// <summary>
    /// Sets the initial balance based on the account type.
    /// </summary>
    protected virtual void SetInitialBalance(decimal minimumBalance)
    {
        balance = minimumBalance;
    }

    /// <summary>
    /// Checks if the account has the minimum required balance.
    /// </summary>
    protected bool HasMinimumBalance(decimal minimumBalance)
    {
        return balance >= minimumBalance;
    }
}