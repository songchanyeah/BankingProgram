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
}
