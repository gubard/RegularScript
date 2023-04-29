using RegularScript.Core.Common.Interfaces;
using RegularScript.Core.Common.Models;

namespace RegularScript.Core.Common.Services;

public class RandomUInt16 : IRandom<ushort>
{
    private readonly Interval<ushort> interval;
    private readonly IRandom<ushort, Interval<ushort>> random;

    public RandomUInt16(IRandom<ushort, Interval<ushort>> random, Interval<ushort> interval)
    {
        this.random = random;
        this.interval = interval;
    }

    public ushort GetRandom()
    {
        var value = random.GetRandom(interval);

        return value;
    }
}