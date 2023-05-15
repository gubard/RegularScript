using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using RegularScript.Core.Common.Extensions;
using RegularScript.Core.DependencyInjection.Interfaces;
using RegularScript.Core.DependencyInjection.Models;

namespace RegularScript.Core.DependencyInjection.Extensions;

public static class RegisterScopeAutoInjectMemberExtension
{
    public static void RegisterScopeAutoInject(
        this IRegisterScopeAutoInjectMember register,
        Expression path,
        Expression value
    )
    {
        switch (path)
        {
            case LambdaExpression lambdaExpression:
            {
                var type = lambdaExpression.Parameters.Single().Type;
                var memberExpression = lambdaExpression.Body.ThrowIfIsNot<MemberExpression>();
                var identifier = new AutoInjectMemberIdentifier(type, memberExpression.Member);
                register.RegisterScopeAutoInjectMember(identifier, value);

                break;
            }
            default:
            {
                throw new UnreachableException();
            }
        }
    }
}