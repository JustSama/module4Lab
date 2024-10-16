public interface IWorker
{
    void Work();
}

public interface IHuman
{
    void Eat();
    void Sleep();
}

public class HumanWorker : IWorker, IHuman
{
    public void Work()
    {
        // Логика работы
    }

    public void Eat()
    {
        // Логика питания
    }

    public void Sleep()
    {
        // Логика сна
    }
}

public class RobotWorker : IWorker
{
    public void Work()
    {
        // Логика работы
    }
}


public class Program
{
    public static void Main(string[] args)
    {
        IWorker humanWorker = new HumanWorker();
        humanWorker.Work();

        IWorker robotWorker = new RobotWorker();
        robotWorker.Work();
    }
}
