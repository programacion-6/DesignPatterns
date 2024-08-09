using Strategy.Database;

namespace Strategy;

/// <summary>
/// Without
/// </summary>
/// 

//public class PaymentProcessor
//{
//    public void ProcessPayment(string paymentType)
//    {
//        if (paymentType == "CreditCard")
//        {
//            Console.WriteLine("Processing payment using Credit Card.");
//        }
//        else if (paymentType == "PayPal")
//        {
//            Console.WriteLine("Processing payment using PayPal");
//        }
//        else
//        {
//            Console.WriteLine("Unknown payment method.");
//        }
//    }
//}

/// <summary>
/// With
/// </summary>

public interface IPaymentStrategy
{
    void ProcessPayment();
}

public class CreditCardPayment : IPaymentStrategy
{
    public void ProcessPayment()
    {
        Console.WriteLine("Processing payment using Credit Card.");
    }
}

public class BankTransferPayment : IPaymentStrategy
{
    public void ProcessPayment()
    {
        Console.WriteLine("Processing payment using Bank Transer.");
    }
}

public class PaymentProcessor
{
    private IPaymentStrategy _strategy;

    public void SetPaymentStrategy(IPaymentStrategy strategy)
    {
        _strategy = strategy;
    }

    public void ProcessPayment()
    {
        _strategy.ProcessPayment();
    }
}

/// <summary>
/// STRATEGY PATTERN
///     1. Si existe un proceso prestablecido
///     2. Se pone complejo el codigo a medida que crece
///
/// </summary>

public class Program
{
    static void Main()
    {
        //var paymentProcessor = new PaymentProcessor();
        //paymentProcessor.ProcessPayment("CreditCard");
        //paymentProcessor.ProcessPayment("PayPal");
        var paymentProcessor = new PaymentProcessor();
        paymentProcessor.SetPaymentStrategy(new CreditCardPayment());
        paymentProcessor.SetPaymentStrategy(new BankTransferPayment());

        // Databae Strategy
        var dbContext = new DatabaseContext();

        dbContext.SetDatabaseStrategy(new SQLServerStrategy());
        dbContext.Connect();
        dbContext.ExecuteQuery("SELECT * FROM Users");
    }
}
