using System;
using System.Reflection;
using RegularScript.Core.Common.Models;

namespace RegularScript.Core.DependencyInjection.Interfaces;

public interface IInvoker
{
    object? Invoke(Delegate del, DictionarySpan<TypeInformation, object> arguments);
    object? Invoke(object? obj, MethodInfo method, DictionarySpan<TypeInformation, object> arguments);
}