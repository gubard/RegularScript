﻿using System;
using RegularScript.Core.Common.Extensions;
using RegularScript.Core.Common.Interfaces;

namespace RegularScript.Core.Common.Services;

public class FuncHumanizing<TInput> : IHumanizing<TInput, string> where TInput : notnull
{
    private readonly Func<TInput, string> func;

    public FuncHumanizing(Func<TInput, string> func)
    {
        this.func = func.ThrowIfNull();
    }

    public string Humanize(TInput input)
    {
        return func.Invoke(input);
    }
}