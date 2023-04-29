using RegularScript.Core.Common.Exceptions;
using RegularScript.Core.Common.Helpers;
using RegularScript.Core.Common.Interfaces;

namespace RegularScript.Core.Common.Services;

public class RandomArrayItem<TValue> : IRandomArrayItem<TValue>
{
    public static readonly RandomArrayItem<TValue> IncludeDefault = new (includeDefault: true);
    public static readonly RandomArrayItem<TValue> ExcludeDefault = new (includeDefault: false);

    private readonly bool includeDefault;

    public RandomArrayItem(bool includeDefault)
    {
        this.includeDefault = includeDefault;
    }

    public TValue? GetRandom(TValue[] values)
    {
        if (values.Length == 0)
        {
            return includeDefault ? default : throw new EmptyEnumerableException(enumerableName: nameof(values));
        }

        var min = includeDefault ? -1 : 0;
        var index = CommonConstants.Random.Next(min, values.Length);

        if (index == -1)
        {
            return default;
        }

        return values[index];
    }
}