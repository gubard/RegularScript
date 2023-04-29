using RegularScript.Core.Common.Interfaces;
using RegularScript.Core.Common.Models;

namespace RegularScript.Core.Common.Services;

public class RandomUInt64 : IRandom<ulong>
{
    private readonly Interval<ulong> interval;
    private readonly IRandom<ulong, Interval<ulong>> random;

    public RandomUInt64(IRandom<ulong, Interval<ulong>> random, Interval<ulong> interval)
    {
        this.random = random;
        this.interval = interval;
    }

    public ulong GetRandom()
    {
        return random.GetRandom(interval);
    }
}