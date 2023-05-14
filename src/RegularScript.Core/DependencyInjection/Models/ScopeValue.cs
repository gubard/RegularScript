using System.Linq.Expressions;

namespace RegularScript.Core.DependencyInjection.Models;

public readonly record struct ScopeValue(ParameterExpression Parameter, Expression Expression);