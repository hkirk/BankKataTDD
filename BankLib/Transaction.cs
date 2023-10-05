namespace BankLib;

public class Transaction
{
    public TransactionType Type { get; }
    public int Amount { get; }

    public Transaction(TransactionType type, int amount)
    {
        Type = type;
        Amount = amount;
    }
}