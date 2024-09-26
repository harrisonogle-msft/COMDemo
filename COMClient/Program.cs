using COMInterfaces;
using System.Diagnostics;
using System.Runtime.InteropServices;



Console.WriteLine("Hello, world!");

IEventSource src = new EventSource();

src.AddObserver(new Observer { Name = "Listener1" });
src.AddObserver(new Observer { Name = "Listener2" });
src.AddObserver(new Observer { Name = "Listener3" });

src.NotifyObservers();

Console.WriteLine("Done.");



[ComVisible(true)]
public sealed class Observer : IObserver
{
    public required string Name { get; init; }

    public void OnMessage(string message)
    {
        Console.WriteLine(
            $"{GetType().Name}/{Name} " +
            $"(framework={RuntimeInformation.FrameworkDescription}, " +
            $"process={Process.GetCurrentProcess().ProcessName}.exe) " +
            $"received a message: {message}");
    }
}
