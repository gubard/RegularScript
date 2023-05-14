﻿using RegularScript.Core.Common.Helpers;
using RegularScript.Core.Common.Interfaces;
using RegularScript.Core.Common.Models;

namespace RegularScript.Core.Common.Services;

public class RandomInt32 : IRandom<int>
{
    private readonly Interval<int> interval;

    public RandomInt32(Interval<int> interval)
    {
        this.interval = interval;
    }

    public int GetRandom()
    {
        var value = CommonConstants.Random.Next(interval.Min, interval.Max + 1);

        return value;
    }
}