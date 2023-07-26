/// <summary>
/// Represents the bank account management interface.
/// </summary>

public interface IArrayBank
{
    bool StoreAccount(Account account);
    Account FindAccount(string accountNumber);
    Account[] GetAllAccounts();
}
