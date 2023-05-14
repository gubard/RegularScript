using System.Collections;
using RegularScript.Core.Common.Extensions;
using RegularScript.Core.Common.Interfaces;

namespace RegularScript.Core.Common.Services;

public class TaskCompletionSourceEnumerator : ITaskCompletionSourceEnumerator
{
    private Task current;
    private bool disposed;
    private TaskCompletionSource taskCompletionSource;

    public TaskCompletionSourceEnumerator()
    {
        taskCompletionSource = new TaskCompletionSource();
        current = taskCompletionSource.Task;
    }

    public Task Current
    {
        get
        {
            if (disposed) this.ThrowDisposedException();

            return current;
        }
    }

    object IEnumerator.Current => Current;

    public bool MoveNext()
    {
        if (disposed) this.ThrowDisposedException();

        taskCompletionSource.SetResult();
        taskCompletionSource = new TaskCompletionSource();
        current = taskCompletionSource.Task;

        return true;
    }

    public void Reset()
    {
        MoveNext();
    }

    public void Dispose()
    {
        Dispose(true);
    }

    public Task MoveNextAndGetCurrent()
    {
        MoveNext();

        return Current;
    }

    protected virtual void Dispose(bool disposing)
    {
        if (disposed) return;

        if (disposing)
        {
            taskCompletionSource.SetResult();
            taskCompletionSource = null!;
            current = null!;
        }

        disposed = true;
    }
}