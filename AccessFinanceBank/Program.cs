// See https://aka.ms/new-console-template for more information

using AccessFinanceBank;

var bank = new Bank();
while (true)
{
    Console.WriteLine("1. Create an Account");
    Console.WriteLine("2. Deposit Money");
    Console.WriteLine("3. Withdraw Money");
    Console.WriteLine("4. Check Account Balance");
    Console.WriteLine("5. Transfer Money");



    Console.Write("Select a number: ");



    var input = Console.ReadLine();

    int result = 0;

    try
    {
        result = Int32.Parse(input);
    }
    catch(FormatException)
    {
        Console.WriteLine("Invalid input. Please pick a number between 1-5"!);
        return;
    }

    if (!(result > 0 && result < 6))
    {
        Console.WriteLine("The number is invalid. Please select a number between 1 and 5!");
        return;
    }

    var accountNumber = 0;

    try
    {
        switch (result)
        {
            case 1:
                Console.Write("Input your name: ");
                var name = Console.ReadLine();
                Console.Write("Input the initial balance of your account: ");
                var initialBalance = double.Parse(Console.ReadLine());
                Console.Write("Input unique account number: ");
                accountNumber = Int32.Parse(Console.ReadLine());

                bank.CreateAccount(name, initialBalance, accountNumber);


                break;
            case 2:
                Console.Write("To deposit money to your account provide your number: ");
                accountNumber = Int32.Parse(Console.ReadLine());
                if (!(bank.AccountValidation(accountNumber)))
                {
                    Console.WriteLine($"Couldn't find an account with this number: {accountNumber}");
                    break;
                }

                Console.Write("Input the amount of money you want to deposit: ");
                var amount = Double.Parse(Console.ReadLine());

                bank.DepositMoney(amount, accountNumber);
                break;

            case 3:

                Console.Write("To withdraw money from your account provide your number: ");
                accountNumber = Int32.Parse(Console.ReadLine());
                if (!(bank.AccountValidation(accountNumber)))
                {
                    Console.WriteLine($"Couldn't find an account with this number: {accountNumber}");
                    break;
                }

                Console.Write("Input the amount of money you want to deposit: ");
                var money = Double.Parse(Console.ReadLine());

                bank.WithdrawMoney(money, accountNumber);
                break;

            case 4:
                Console.Write("To see your current balance provide your number: ");
                accountNumber = Int32.Parse(Console.ReadLine());
                if (!(bank.AccountValidation(accountNumber)))
                {
                    Console.WriteLine($"Couldn't find an account with this number: {accountNumber}");
                    break;
                }

                Console.WriteLine($"Your current balance is: {bank.GetAccount(accountNumber).Balance}");
                break;
            case 5:
                Console.Write("Provide the account number of the sender: ");
                var senderNumber = Int32.Parse(Console.ReadLine());
                Console.Write("Provide the account number of the receiver: ");
                var receiverNumber = Int32.Parse(Console.ReadLine());
                Console.Write("Provide the amount you want to transfer: ");
                var tranferMoney = double.Parse(Console.ReadLine());


                bank.SendMoney(senderNumber, receiverNumber, tranferMoney);
                break;
            default:
                break;
        }
    }
    catch (Exception e)
    {
        Console.WriteLine(e);
    }



}


