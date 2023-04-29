using System.Net;
using System.Net.Sockets;
using RegularScript.Core.Common.Extensions;
using RegularScript.Core.Common.Interfaces;

namespace RegularScript.Core.Common.Services;

public class UdpSend<TMessage> : ISend<TMessage>, IDisposable
{
    private readonly UdpClient client;
    private bool disposed;
    public IPEndPoint IpEndPoint { get; }
    public Func<TMessage, byte[]> Converter { get; }

    public UdpSend(IPEndPoint ipEndPoint, Func<TMessage, byte[]> converter)
    {
        IpEndPoint = ipEndPoint.ThrowIfNull(paramName: nameof(ipEndPoint));
        client = new ();
        Converter = converter.ThrowIfNull(paramName: nameof(converter));
        disposed = false;
    }

    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(obj: this);
    }

    public Task SendAsync(TMessage message, CancellationToken token)
    {
        var data = Converter.Invoke(message);
        token.ThrowIfCancellationRequested();

        return client.SendAsync(data, data.Length, IpEndPoint);
    }

    public void Send(TMessage message)
    {
        var data = Converter.Invoke(message);
        client.Send(data, data.Length, IpEndPoint);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (disposed)
        {
            return;
        }

        if (disposing)
        {
            client.Dispose();
        }

        disposed = true;
    }
}