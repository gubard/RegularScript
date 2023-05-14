using RegularScript.Core.Common.Helpers;
using RegularScript.Core.Common.Interfaces;
using RegularScript.Core.Common.Models;

namespace RegularScript.Core.Common.Services;

public class RandomUInt16InInterval : IRandom<ushort, Interval<ushort>>
{
    public ushort GetRandom(Interval<ushort> options)
    {
        var value = CommonConstants.Random.Next(options.Min, options.Max + 1);

        return (ushort)value;
    }
}