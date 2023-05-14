﻿using System.Net;
using System.Net.Sockets;
using RegularScript.Core.Common.Extensions;
using RegularScript.Core.Common.Interfaces;

namespace RegularScript.Core.Common.Services;

public class UdpSend<TMessage> : ISend<TMessage>, IDisposable
{
    private readonly UdpClient client;
    private bool disposed;

    public UdpSend(IPEndPoint ipEndPoint, Func<TMessage, byte[]> converter)
    {
        IpEndPoint = ipEndPoint.ThrowIfNull(nameof(ipEndPoint));
        client = new UdpClient();
        Converter = converter.ThrowIfNull(nameof(converter));
        disposed = false;
    }

    public IPEndPoint IpEndPoint { get; }
    public Func<TMessage, byte[]> Converter { get; }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
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
        if (disposed) return;

        if (disposing) client.Dispose();

        disposed = true;
    }
}