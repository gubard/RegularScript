using System.Linq.Expressions;
using RegularScript.Core.Common.Models;

namespace RegularScript.Core.DependencyInjection.Interfaces;

public interface IExpressionCache
{
    void CacheExpression(TypeInformation type);
    Expression? GetCacheExpression(TypeInformation type);
}