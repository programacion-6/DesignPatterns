namespace FactoryMethod;

/// <summary>
/// Es un patron de diseño creacional
/// que provee una interfaz para crear objetos en una superclass, permitiendonos entidades (subclasses)
/// alterar el tipo de objetos que van a ser creados. 
/// 
/// CUANDO:
/// - ...ES UTIL CUANDO UNA CLASE NO PUEDE ANTICIPAR EL TIPO DE OBJETO QUE NECESITA SER CREADO.
/// - Es cuando se incrementa la complejidad de codigo al seleccionar el un tipo de objeto bajo mismo contexto
/// 
/// PROS
/// - Encapsulacion: 
/// - Mantenibilidad:
/// - Flexible: 
/// - Consistencia:
/// 
/// CONSEJOS:
/// - Si se encuentran con que la logica entre los objetos es muy similar o casi igual
///   podria ser mejor:
///   1. Crear un dictionary donde se retorna delegates con los distintas formas de crear o genear una instancia
///   2. Tener una clase abstracta como DEFAULT y clases especializadas en la creacion de objectos mas especificos
///   * 3. Quizas solo necesites un strategy.
/// </summary>
/// 

// WITHOUT

//public class Notfication
//{
//    public void SendNotification(string type, string message)
//    {
//        if (type == "Email")
//        {
//            Console.WriteLine($"Send Email: {message}");
//        }
//        else if (type == "SMS")
//        {
//            Console.WriteLine($"Send SMS: {message}");
//        }
//        else if (type == "Push")
//        {
//            Console.WriteLine($"Sending Push Notification: {message}");
//        }
//        else
//        {
//            Console.WriteLine("Unkwon notification type");
//        }
//    }
//}

// WITH

public interface INotification
{
    void Send(string message);
}

public class EmailNotification : INotification
{
    public void Send(string message)
    {
        Console.WriteLine($"Send Email: {message}");
    }
}

public class SMSNotification : INotification
{
    public void Send(string message)
    {
        Console.WriteLine($"Send SMS: {message}");
    }
}

public class PushNotification : INotification
{
    public void Send(string message)
    {
        Console.WriteLine($"Sending Push Notification: {message}");
    }
}

public enum NotificationType
{
    Email,
    SMS,
    Push
}

public class NotificationFactory
{
    public static readonly Dictionary<NotificationType, Func<INotification>> _notificationMap = new()
    {
        { NotificationType.Email, () => new EmailNotification() },
        { NotificationType.SMS, () => new SMSNotification() },
        { NotificationType.Push, () => new PushNotification() },
    };

    public static INotification CreateNotification2(NotificationType type)
    {
        if (_notificationMap.TryGetValue(type, out var createNotification))
        {
            return createNotification();
        }
        else
        {
            throw new ArgumentException("Invalid Notification Type");
        }
    }

    public static INotification CreateNotification(NotificationType type)
    {
        return type switch
        { 
            NotificationType.Email => new EmailNotification(),
            NotificationType.SMS => new SMSNotification(),
            NotificationType.Push => new PushNotification(),
            _ => throw new ArgumentException("Invalid Notification Type")
        };
    }
}

public class Program
{
    static void Main(string[] args)
    {
        //var notification = new Notfication();
        //notification.SendNotification("Email", "Hello via Email");
        //notification.SendNotification("SMS", "Hello via SMS");
        //notification.SendNotification("Push", "Hellos via Push");

        var emailNotification = NotificationFactory.CreateNotification(NotificationType.Email);
        emailNotification.Send("Hello via Email");

        var smsNotification = NotificationFactory.CreateNotification(NotificationType.SMS);
        smsNotification.Send("Hello via SMS");

        var pushNotification = NotificationFactory.CreateNotification(NotificationType.Push);
        pushNotification.Send("Hello via Push");
    }
}
