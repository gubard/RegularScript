using System.Linq.Expressions;

namespace RegularScript.Core.Expressions.Extensions;

public static class ObjectExtension
{
    public static ConstantExpression ToConstant(this object obj)
    {
        return Expression.Constant(obj);
    }

    public static ConstantExpression ToConstant(this object obj, Type type)
    {
        return Expression.Constant(obj, type);
    }
}