using COMInterfaces;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace COMServer;

[ComVisible(true)]
[Guid(ContractGuids.CLSID_EventSource)]
public sealed class EventSource : IEventSource
{
    private readonly ConcurrentQueue<IObserver> _observers = new();

    public void AddObserver(IObserver observer)
    {
        _observers.Enqueue(observer);
    }

    public void NotifyObservers()
    {
        foreach (IObserver observer in _observers)
        {
            observer.OnMessage(Message);
        }
    }

    private string Message =>
        $"Hello from {GetType().Name} " +
        $"(framework='{RuntimeInformation.FrameworkDescription}', " +
        $"process='{Process.GetCurrentProcess().ProcessName}.exe')";
}
