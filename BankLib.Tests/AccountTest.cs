using System.Runtime.InteropServices;

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

    
    [Theory]
    [InlineData(0)]
    [InlineData(100)]
    [InlineData(10000)]
    public void Account_balance_should_be_balance_minus_withdrawal_amount_when_withdrawing(int amount)
    {
        var changeAccount = account.Withdrawal(amount);
        
        Assert.Equal(-1*amount, changeAccount.Balance);
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(-11)]
    [InlineData(-1100)]
    public void Withdrawal_should_increase_balance(int negativeAmount)
    {
        var changedAccount = account.Withdrawal(negativeAmount);
        
        Assert.True(changedAccount.Balance == 0);
    }

    [Fact]
    public void Not_withdrawing_from_account_should_not_change_account_object()
    {
        var changedAccount = account.Withdrawal(-100);
        
        Assert.Equal(account, changedAccount);
    }
}