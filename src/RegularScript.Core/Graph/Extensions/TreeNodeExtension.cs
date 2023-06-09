﻿using System.Collections.Generic;
using RegularScript.Core.Common.Extensions;
using RegularScript.Core.Graph.Models;

namespace RegularScript.Core.Graph.Extensions;

public static class TreeNodeExtension
{
    public static IEnumerable<TreeNode<TKey, TValue>> GetEnds<TKey, TValue>(
        this TreeNode<TKey, TValue> root
    ) where TKey : notnull
    {
        if (root.Nodes.IsEmpty())
        {
            yield return root;
            yield break;
        }

        foreach (var node in root.Nodes)
        foreach (var end in node.GetEnds())
        {
            yield return end;
        }
    }
}