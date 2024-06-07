using AccessFinanceBank;

namespace AccessFinanceTest;

public class UnitTest1
{
    [Fact]
    public void CanCreateAccount()
    {
        var account = new Account
        {
            Name = "Hrisy",
            Balance = 200.34,
            Number = 12345
        };

        var bank = new Bank();
        
        bank.CreateAccount(account.Name, account.Balance, account.Number);

        var checkAccount = bank.GetAccount(account.Number);
        
        Assert.Equal(account.Name, checkAccount.Name);
        Assert.Equal(account.Balance, checkAccount.Balance);
        Assert.Equal(account.Number, checkAccount.Number);
        
    }
    
    [Fact]
    public void CanWithdrawMoney()
    {
        var account = new Account
        {
            Name = "Hrisy",
            Balance = 200.34,
            Number = 12345
        };

        var bank = new Bank();
        
        bank.CreateAccount(account.Name, account.Balance, account.Number);

        var checkAccount = bank.GetAccount(account.Number);
        
        bank.WithdrawMoney(20, account.Number);
        
        Assert.Equal(180.34, checkAccount.Balance);
        
    }
    
    [Fact]
    public void CanDepositMoney()
    {
        var account = new Account
        {
            Name = "Hrisy",
            Balance = 200.34,
            Number = 12345
        };

        var bank = new Bank();
        
        bank.CreateAccount(account.Name, account.Balance, account.Number);

        var checkAccount = bank.GetAccount(account.Number);
        
        bank.DepositMoney(20, account.Number);
        
        Assert.Equal(220.34, checkAccount.Balance);
        
    }
    
    [Fact]
    public void CanCheckCurrentBalance()
    {
        var account = new Account
        {
            Name = "Hrisy",
            Balance = 200.34,
            Number = 12345
        };

        var bank = new Bank();
        
        bank.CreateAccount(account.Name, account.Balance, account.Number);

        var checkAccount = bank.GetAccount(account.Number);
        
        Assert.Equal(account.Balance, checkAccount.Balance);
        
    }
    
    [Fact]
    public void CanTransferMoney()
    {
        var sender = new Account
        {
            Name = "Sender",
            Balance = 200,
            Number = 1
        };
        
        var receiver = new Account
        {
            Name = "Receiver",
            Balance = 200,
            Number = 2
        };


        var bank = new Bank();
        
        bank.CreateAccount(sender.Name, sender.Balance, sender.Number);
        bank.CreateAccount(receiver.Name, receiver.Balance, receiver.Number);

        var checkSenderAccount = bank.GetAccount(sender.Number);
        
        var checkReceiverAccount = bank.GetAccount(receiver.Number);
        
        bank.SendMoney(sender.Number, receiver.Number, 20);
        
        Assert.Equal(180, checkSenderAccount.Balance);
        Assert.Equal(220, checkReceiverAccount.Balance);
        
    }
    
}