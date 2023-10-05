namespace BankLib.Tests;

public class AccountTest
{
    private Account account;
    public AccountTest()
    {
        account = new Account();
    }
    [Fact]
    public void Account_balance_should_be_zero_when_initialized()
    {
        
        Assert.Equal(0, account.Balance);
    }

    [Theory]
    [InlineData(10)]
    [InlineData(100000)]
    [InlineData(0)]
    public void Account_balance_should_equal_earlier_balance_plus_deposit_value(int amount)
    {
        var changedAccount = account.Deposit(amount);

        Assert.Equal(0, account.Balance);
        Assert.Equal(amount, changedAccount.Balance);
    }

    [Fact]
    public void Account_balance_should_not_be_less_than_earlier_balance_when_depositing()
    {  
        var changedAccount = account.Deposit(-1);
        
        Assert.Equal(0, changedAccount.Balance);
        Assert.Equal(0, account.Balance);
    }

    [Fact]
    public void Depositing_to_account_that_do_not_change_balance_should_not_change_object()
    {
        var changeAccount = account.Deposit(0);
        
        Assert.Equal(changeAccount, account);
    }
}