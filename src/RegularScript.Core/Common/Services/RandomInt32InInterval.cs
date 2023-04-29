using RegularScript.Core.Common.Helpers;
using RegularScript.Core.Common.Interfaces;
using RegularScript.Core.Common.Models;

namespace RegularScript.Core.Common.Services;

public class RandomInt32InInterval : IRandom<int, Interval<int>>
{
    public static readonly RandomInt32InInterval Default = new ();

    public int GetRandom(Interval<int> options)
    {
        var value = CommonConstants.Random.Next(options.Min, maxValue: options.Max + 1);

        return value;
    }
}