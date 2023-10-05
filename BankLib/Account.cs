
namespace BankLib;

public class Account
{
    public int Balance { get; }
    private Transaction Transaction;

    public Account()
    {
        Balance = 0;
    }
    public Account(int initialBalance)
    {
        Balance = initialBalance;
    }

    private Account(int initialBalance, TransactionType type)
    {
        Transaction = new Transaction(type, 100);
        Balance = initialBalance;
    }

    public Account Deposit(int amount)
    {
        if (amount > 0)
        {
            return new Account(Balance + amount, TransactionType.Deposit);
        }

        return this;
    }

    public Account Withdrawal(int amount)
    {
        if (amount > 0)
        {
            return new Account(Balance - amount, TransactionType.Withdrawal);
        }


        return this;
    }


    public Transaction LastTransaction()
    {
        return Transaction;
    }
}