using System;

namespace RegularScript.Core.Common.Models;

public class DisposableItem<TItem> : IDisposable
{
    private readonly IDisposable disposable;

    public DisposableItem(TItem item, IDisposable disposable)
    {
        Item = item;
        this.disposable = disposable;
    }

    public TItem Item { get; }

    public void Dispose()
    {
        disposable.Dispose();
    }
}