using RegularScript.Core.Common.Extensions;
using RegularScript.Core.Common.Interfaces;

namespace RegularScript.Core.Common.Services;

public class ToStringHumanizing<TInput> : IHumanizing<TInput, string> where TInput : notnull
{
    public string Humanize(TInput input)
    {
        var result = input.ToString().ThrowIfNull();

        return result;
    }
}