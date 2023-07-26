using System;
using System.Collections.Generic;
using System.Linq;
/// <summary>
/// Represents a bank account storage system.
/// </summary>
public class ArrayBank : IArrayBank
{
    private Dictionary<string, Account> accounts;
    private int accountCount;

    /// <summary>
    /// Initializes a new instance of the ArrayBank class.
    /// </summary>
    public ArrayBank()
    {
        // accounts = new Account[maxAccounts];
        accounts = new Dictionary<string, Account>();
        accountCount = 0;
    }

    /// <summary>
    /// Stores an account in the bank.
    /// </summary>
    /// <param name="account">The account to store.</param>
    /// <returns>True if the account was stored successfully, otherwise false.</returns>
    public bool StoreAccount(Account account)
    {
        if (!accounts.ContainsKey(account.AccountNumber))
        {
            accounts[account.AccountNumber] = account;
            return true;
        }
        return false;
    }

    /// <summary>
    /// Finds an account in the bank based on the account number.
    /// </summary>
    /// <param name="accountNumber">The account number to search for.</param>
    /// <returns>The account object if found, otherwise null.</returns>
    public Account FindAccount(string accountNumber)
    {
        if (accounts.TryGetValue(accountNumber, out Account account))
        {
            return account;
        }
        return null;
    }

    public Account[] GetAllAccounts()
    {
        // return accounts;
        return accounts.Values.ToArray();
    }
}
