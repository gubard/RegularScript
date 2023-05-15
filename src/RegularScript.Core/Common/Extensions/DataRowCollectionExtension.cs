using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace RegularScript.Core.Common.Extensions;

public static class DataRowCollectionExtension
{
    public static string ToCsv(
        this DataRowCollection rowCollection,
        DataColumnCollection columnCollection,
        string separator,
        string rowSeparator
    )
    {
        rowCollection.ThrowIfNull();
        columnCollection.ThrowIfNull();
        var result = new List<string>();

        foreach (DataRow row in rowCollection)
            result.Add(
                columnCollection
                    .OfType<DataColumn>()
                    .Select(x => row[x].ToString() ?? string.Empty)
                    .JoinString(separator)
            );

        return result.JoinString(rowSeparator);
    }
}