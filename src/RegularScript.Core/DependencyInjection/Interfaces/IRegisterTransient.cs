using System;
using System.Linq.Expressions;

namespace RegularScript.Core.DependencyInjection.Interfaces;

public interface IRegisterTransient
{
    void RegisterTransient(Type type, Expression expression);
}