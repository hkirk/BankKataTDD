namespace BankLib;

public class Account
{
    public int Balance { get; }

    public Account()
    {
        Balance = 0;
    }
    public Account(int initialBalance)
    {
        Balance = initialBalance;
    }
    
    public Account Deposit(int amount)
    {
        if (amount > 0)
        {
            return new Account(Balance + amount);
        }

        return this;
    }
}