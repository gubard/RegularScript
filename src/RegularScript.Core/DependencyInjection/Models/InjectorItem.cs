using System.Linq.Expressions;

namespace RegularScript.Core.DependencyInjection.Models;

public readonly record struct InjectorItem(InjectorItemType Type, Expression Expression);