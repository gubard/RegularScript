using System.Linq.Expressions;

namespace RegularScript.Core.DependencyInjection.Interfaces;

public interface IRegisterScope
{
    void RegisterScope(Type type, Expression expression);
}