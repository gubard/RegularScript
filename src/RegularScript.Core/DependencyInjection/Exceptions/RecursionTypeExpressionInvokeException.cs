using System.Linq.Expressions;

namespace RegularScript.Core.DependencyInjection.Exceptions;

public class RecursionTypeExpressionInvokeException : Exception
{
    public Type Type { get; }
    public Expression Expression { get; }

    public RecursionTypeExpressionInvokeException(Type type, Expression expression)
        : base(message: $"{type} contains in parameters {expression}.")
    {
        Type = type;
        Expression = expression;
    }
}