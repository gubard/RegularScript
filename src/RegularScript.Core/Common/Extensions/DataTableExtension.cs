using System.Data;

namespace RegularScript.Core.Common.Extensions;

public static class DataTableExtension
{
    public static string ToCsv(this DataTable dataTable)
    {
        return dataTable.ToCsv(separator: ";", Environment.NewLine);
    }

    public static string GetTableString(this DataTable dataTable)
    {
        return dataTable.GetTableString(Environment.NewLine, padding: -2);
    }

    public static Task<string> GetTableStringAsync(this Task<DataTable> task)
    {
        return task.GetTableStringAsync(Environment.NewLine, padding: -2);
    }

    public static string ToCsv(this DataTable dataTable, string separator, string rowSeparator)
    {
        return $"{
            dataTable.Columns.ToCsv(separator)
        }{
            rowSeparator
        }{
            dataTable.Rows.ToCsv(dataTable.Columns, separator, rowSeparator)
        }";
    }

    public static string GetTableString(this DataTable dataTable, string rowSeparator, int padding)
    {
        var columnNames = dataTable.Columns.Cast<DataColumn>().ToArray();
        var valueRows = dataTable.Rows.OfType<DataRow>().ToArray();
        var values = new string[valueRows.Length][];
        var maxLengths = new int[columnNames.Length];

        for (var index = 0; index < columnNames.Length; index++)
        {
            maxLengths[index] = columnNames[index].ColumnName.Length;
        }

        for (var rowIndex = 0; rowIndex < valueRows.Length; rowIndex++)
        {
            var valuesRow = columnNames
               .Select(selector: x => valueRows[rowIndex][x].ToString() ?? string.Empty)
               .ToArray();

            values[rowIndex] = new string[columnNames.Length];

            for (var columnIndex = 0; columnIndex < columnNames.Length; columnIndex++)
            {
                var value = valuesRow[columnIndex];
                values[rowIndex][columnIndex] = value;
                maxLengths[columnIndex] = Math.Max(value.Length, val2: maxLengths[columnIndex]);
            }
        }

        var formatColumnNames = new string[columnNames.Length];

        for (var index = 0; index < formatColumnNames.Length; index++)
        {
            var template = $"{{0,{-maxLengths[index] + padding}}}";
            formatColumnNames[index] = string.Format(template, arg0: columnNames[index]);
        }

        var formatRows = new string[valueRows.Length];

        for (var rowIndex = 0; rowIndex < valueRows.Length; rowIndex++)
        {
            var formatRow = new List<string>();

            for (var columnIndex = 0; columnIndex < columnNames.Length; columnIndex++)
            {
                formatRow.Add(item: "{" + columnIndex + "," + (-maxLengths[columnIndex] + padding) + "}");
            }

            var @params = values[rowIndex].Cast<object>();
            formatRows[rowIndex] = string.Format(format: formatRow.JoinString(separator: ""), @params);
        }

        var result =
            $"{formatColumnNames.JoinString(separator: "")}{rowSeparator}{formatRows.JoinString(Environment.NewLine)}";

        return result;
    }

    public static async Task<string> GetTableStringAsync(
        this Task<DataTable> task,
        string rowSeparator,
        int padding
    )
    {
        var dataTable = await task;

        return dataTable.GetTableString(rowSeparator, padding);
    }
}