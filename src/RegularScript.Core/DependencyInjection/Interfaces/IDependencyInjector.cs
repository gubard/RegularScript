using System;
using RegularScript.Core.Common.Models;

namespace RegularScript.Core.DependencyInjection.Interfaces;

public interface IDependencyInjector : IResolver, IInvoker, IDependencyStatusGetter
{
    ReadOnlyMemory<TypeInformation> Inputs { get; }
    ReadOnlyMemory<TypeInformation> Outputs { get; }
}