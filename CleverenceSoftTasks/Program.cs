using CleverenceSoftTasks.Task1;

public class Program
{
    public static void Main()
    {
        var tasks = new List<Task>();
        int value = 1;
        int numberOfRequests = 100;

        for (int i = 0; i < numberOfRequests; i++)
        {
            tasks.Add(Task.Factory.StartNew(() => Server.AddToCount(value)));
            Console.WriteLine("Current count {0}", Server.GetCount());
        }
    }
}