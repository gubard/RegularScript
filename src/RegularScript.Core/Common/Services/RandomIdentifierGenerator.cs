using RegularScript.Core.Common.Extensions;
using RegularScript.Core.Common.Interfaces;

namespace RegularScript.Core.Common.Services;

public class RandomIdentifierGenerator<TKey> : IIdentifierGenerator<TKey>
{
    private readonly IRandom<TKey> random;

    public RandomIdentifierGenerator(IRandom<TKey> random)
    {
        this.random = random;
    }

    public TKey Generate()
    {
        return random.GetRandom().ThrowIfNull();
    }
}