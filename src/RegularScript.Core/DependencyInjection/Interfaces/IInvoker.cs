using RegularScript.Core.Common.Models;

namespace RegularScript.Core.DependencyInjection.Interfaces;

public interface IInvoker
{
    object? Invoke(Delegate del, DictionarySpan<TypeInformation, object> arguments);
}