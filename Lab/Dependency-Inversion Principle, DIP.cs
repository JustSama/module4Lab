public interface INotificationService
{
    void Send(string message);
}

public class EmailService : INotificationService
{
    public void Send(string message)
    {
        Console.WriteLine($"Отправка Email: {message}");
    }
}

public class SmsService : INotificationService
{
    public void Send(string message)
    {
        Console.WriteLine($"Отправка SMS: {message}");
    }
}

public class Notification
{
    private readonly INotificationService _notificationService;

    public Notification(INotificationService notificationService)
    {
        _notificationService = notificationService;
    }

    public void Send(string message)
    {
        _notificationService.Send(message);
    }
}


public class Program
{
    public static void Main(string[] args)
    {
        INotificationService emailService = new EmailService();
        Notification emailNotification = new Notification(emailService);
        emailNotification.Send("Привет, это тестовое сообщение!");

        INotificationService smsService = new SmsService();
        Notification smsNotification = new Notification(smsService);
        smsNotification.Send("Привет, это SMS сообщение!");
    }
}
