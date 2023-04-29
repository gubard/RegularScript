using System.Linq.Expressions;

namespace RegularScript.Core.DependencyInjection.Interfaces;

public interface IRegisterSingleton
{
    void RegisterSingleton(Type type, Expression expression);
}