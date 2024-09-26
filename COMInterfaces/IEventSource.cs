using System.Runtime.InteropServices;

namespace COMInterfaces;

[ComVisible(true)]
[Guid(ContractGuids.IEventSource)]
public interface IEventSource
{
    public void AddObserver(IObserver observer);

    public void NotifyObservers();
}

#region COM interop

[ComImport]
[ComVisible(true)]
[CoClass(typeof(EventSourceCoClass))]
[Guid(ContractGuids.IEventSource)]
public interface EventSource : IEventSource
{
}

[ComImport]
[ComVisible(true)]
[Guid(ContractGuids.CLSID_EventSource)]
public class EventSourceCoClass
{
}

public static partial class ContractGuids
{
    public const string IEventSource = "c2f92e33-5412-4798-beb1-9a0fa202f99c";
    public const string CLSID_EventSource = "af9bc4e5-cf5e-4df0-8436-1b778cf7e189";
}

#endregion
