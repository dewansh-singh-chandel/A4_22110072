using System;
using System.Threading;

public class AlarmEventArgs : EventArgs
{
    public DateTime Time { get; set; }
}

public class AlarmPublisher
{
    public event EventHandler<AlarmEventArgs> RaiseAlarm;

    protected virtual void OnRaiseAlarm(DateTime targetTime)
    {
        RaiseAlarm?.Invoke(this, new AlarmEventArgs() { Time = targetTime });
    }

    public void Start(DateTime targetTime)
    {
        while (true)
        {
            if (DateTime.Now.TimeOfDay >= targetTime.TimeOfDay)
            {
                OnRaiseAlarm(targetTime);
                break;
            }
            Thread.Sleep(1000); // Check every second
        }
    }
}

public class AlarmSubscriber
{
    public void RingAlarm(object sender, AlarmEventArgs e)
    {
        Console.WriteLine($"Alarm! It's now {e.Time:HH:mm:ss}");
    }
}

class Program
{
    static void Main()
    {
        Console.Write("Enter target time in HH:MM:SS format: ");
        string input = Console.ReadLine();

        if (TimeSpan.TryParse(input, out TimeSpan targetTime))
        {
            AlarmPublisher publisher = new AlarmPublisher();
            AlarmSubscriber subscriber = new AlarmSubscriber();

            publisher.RaiseAlarm += subscriber.RingAlarm;
            publisher.Start(DateTime.Today.Add(targetTime));
        }
        else
        {
            Console.WriteLine("Invalid time format. Use HH:MM:SS.");
        }
    }   
}
