﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using RegularScript.Core.Common.Extensions;

namespace RegularScript.Core.Expressions.Extensions;

public static class DelegateExtension
{
    private static readonly Type DelegateType;
    private static readonly MethodInfo DelegateInvokeDynamicType;

    static DelegateExtension()
    {
        DelegateType = typeof(Delegate);

        DelegateInvokeDynamicType = DelegateType
            .GetMethod(nameof(Delegate.DynamicInvoke))
            .ThrowIfNull();
    }

    public static Expression ToCall(this Delegate del, IEnumerable<Expression> arguments)
    {
        var target = del.Target.ThrowIfNull();
        var instance = target.ToConstant();

        if (del.Method.IsRTDynamicMethod())
        {
            var args = arguments.Where(x => !x.Type.IsClosure());
            var parameters = typeof(object).ToNewArrayInit(args);

            return DelegateInvokeDynamicType
                .ToCall(del.ToConstant(), parameters)
                .ToConvert(del.Method.ReturnType);
        }

        return del.Method.ToCall(instance, arguments);
    }

    public static Expression ToCall(this Delegate del, params Expression[] arguments)
    {
        return del.ToCall(arguments.AsEnumerable());
    }
}