using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Text;
using RegularScript.Core.Common.Exceptions;

namespace RegularScript.Core.Common.Extensions;

public static class StringExtension
{
    public static string? GetEnvironmentVariable(this string key)
    {
        return Environment.GetEnvironmentVariable(key);
    }

    public static Uri ToUri(this string str)
    {
        return new (str);
    }

    public static string ThrowIfNullOrWhiteSpace(
        this string? str,
        [CallerArgumentExpression(parameterName: nameof(str))]
        string paramName = ""
    )
    {
        str = str.ThrowIfNull(paramName);

        if (str.IsNullOrWhiteSpace())
        {
            throw new WhiteSpaceException(paramName);
        }

        return str;
    }

    public static bool IsNullOrWhiteSpace([NotNullWhen(returnValue: false)] this string? str)
    {
        return string.IsNullOrWhiteSpace(str);
    }

    public static FileInfo ToFile(this string path)
    {
        return new (path);
    }

    public static DirectoryInfo ToDirectory(this string path)
    {
        return new (path);
    }

    public static string ToConsoleLine(this string line)
    {
        Console.WriteLine(line);

        return line;
    }

    public static async Task<MemoryStream> ToStreamAsync(this string str, Encoding encoding)
    {
        var bytes = str.ToByteArray(encoding);
        var stream = new MemoryStream();
        await stream.WriteAsync(bytes, offset: 0, bytes.Length);

        return stream;
    }

    public static Task<MemoryStream> ToStreamAsync(this string str)
    {
        return str.ToStreamAsync(Encoding.UTF8);
    }

    public static byte[] ToByteArray(this string str, Encoding encoding)
    {
        return encoding.GetBytes(str);
    }

    public static byte[] ToByteArray(this string str)
    {
        return str.ToByteArray(Encoding.UTF8);
    }

    public static string ToWriteToFile(this string str, FileInfo file, Encoding encoding)
    {
        if (file.Exists)
        {
            file.Delete();
        }

        using var stream = file.Create();
        var bytes = encoding.GetBytes(str);
        stream.Write(bytes, offset: 0, bytes.Length);

        return str;
    }

    public static string ToWriteToFile(this string str, FileInfo file)
    {
        return str.ToWriteToFile(file, Encoding.UTF8);
    }

    public static string? AddLine(this string? str, string? line)
    {
        if (str is null)
        {
            return line;
        }

        if (line is null)
        {
            return str;
        }

        return $"{str}{line}{Environment.NewLine}";
    }
}