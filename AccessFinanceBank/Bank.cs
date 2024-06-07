namespace AccessFinanceBank;

public class Bank
{
        private Dictionary<Int32, Account> Accounts { get; set; }

    private Mutex _Mutex { get; set; }

    public Bank()
    {
        Accounts = new Dictionary<int, Account>();
        _Mutex = new Mutex();
    }

    public void CreateAccount(string name, double initialBalance, int number)
    {
        
        _Mutex.WaitOne();
        if (Accounts.ContainsKey(number))
        {
            Console.WriteLine("An account with this number already exists.");
            _Mutex.ReleaseMutex();
            return;
        }
        
        
        var account = new Account
        {
            Name = name,
            Balance = initialBalance,
            Number = number,
        };
    
        Accounts.Add(number, account);
        
        _Mutex.ReleaseMutex();
    
        Console.WriteLine($"{name} your account has been created! :)");

    }

    public bool AccountValidation(int number)
    {
        return (Accounts.ContainsKey(number));
    }

    public void DepositMoney(double amount, int accountNumber)
    {
        _Mutex.WaitOne();
        
        if (!(AccountValidation(accountNumber)))
        {
            _Mutex.ReleaseMutex();
            throw new Exception($"An account with this number {accountNumber} doesn't exist.");
        }

        if (amount <= 0.0)
        {
            _Mutex.ReleaseMutex();
            throw new Exception("Invalid input. The amount cannot be negative or 0.");
        }
    

        var account = Accounts[accountNumber];

    
        account.Balance = account.Balance + amount;
        
        _Mutex.ReleaseMutex();
    
        Console.WriteLine($"You successfully deposit {amount} to your account");
    
    }

    public void WithdrawMoney(double amount, int accountNumber)
    {
        _Mutex.WaitOne();
        if (!(AccountValidation(accountNumber)))
        {
            _Mutex.ReleaseMutex();
            throw new Exception($"An account with this number {accountNumber} doesn't exist.");
        }

        if (amount <= 0.0)
        {
            _Mutex.ReleaseMutex();
            throw new Exception("Invalid input. The amount cannot be negative or 0.");
        }

        var account = Accounts[accountNumber];
    
        if (amount > account.Balance)
        {
            _Mutex.ReleaseMutex();
            throw new Exception("Insufficint balance!");
        }


        account.Balance = account.Balance - amount;
        
        _Mutex.ReleaseMutex();
    
        Console.WriteLine($"You successfully withdrawn {amount} from your account");

    }
    public Account GetAccount(int number)
    {
        return Accounts[number];
    }

    public void SendMoney(int sender, int receiver, double amount)
    {
        if (!(AccountValidation(sender)))
        {
            Console.WriteLine($"An account with this number {sender} doesn't exist.");
            return;
        }
        
        if (!(AccountValidation(receiver)))
        {
            Console.WriteLine($"An account with this number {receiver} doesn't exist.");
            return;
        }
        
        if (amount > GetAccount(sender).Balance)
        {
            Console.WriteLine("Insufficint balance!");
            return;
        }

        try
        {
            WithdrawMoney(amount, sender);
            DepositMoney(amount, receiver);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
        
    }
}