using RegularScript.Core.Common.Helpers;
using RegularScript.Core.Common.Interfaces;
using RegularScript.Core.Common.Models;

namespace RegularScript.Core.Common.Services;

public class RandomUInt64InInterval : IRandom<ulong, Interval<ulong>>
{
    public ulong GetRandom(Interval<ulong> options)
    {
        var value = CommonConstants.Random.Next(minValue: (int)options.Min, maxValue: (int)options.Max + 1);

        return (ulong)value;
    }
}