using System.Runtime.InteropServices;

namespace COMInterfaces;

[ComVisible(true)]
[Guid(ContractGuids.IObserver)]
public interface IObserver
{
    public void OnMessage(string message);
}

#region COM interop

public static partial class ContractGuids
{
    public const string IObserver = "90f8103a-037d-4517-8572-804dc0ac4ffb";
}

#endregion
