using System;
using System.Threading.Tasks;
using RegularScript.Core.Common.Extensions;
using RegularScript.Core.Common.Interfaces;

namespace RegularScript.Core.Common.Services;

public readonly struct DelayService : IDelay
{
    public Task DelayAsync(TimeSpan delay)
    {
        return delay.Delay();
    }
}