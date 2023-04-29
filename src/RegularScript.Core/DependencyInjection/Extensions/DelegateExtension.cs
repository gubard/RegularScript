namespace RegularScript.Core.DependencyInjection.Extensions;

public static class DelegateExtension
{
    public static Type[] GetParameterTypes(this Delegate del)
    {
        return del.Method.GetParameters().Select(selector: x => x.ParameterType).ToArray();
    }
}