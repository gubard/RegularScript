using System;
using System.Linq;
using System.Text;

namespace RegularScript.Core.StringFormat.Services;

public class Formatter
{
    const char startArg = '{';
    const char endArg = '}';
    const string argChars = "QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnm1234567890_";

    public string Format(string template, object args)
    {
        if (string.IsNullOrWhiteSpace(template))
        {
            return template;
        }

        var type = args.GetType();
        var argCharsSpan = new Span<char>(argChars.ToArray());
        var templateSpan = new Span<char>(template.ToArray());
        var stringBuilder = new StringBuilder();
        var currentStart = 0;
        var currentStartArg = 0;
        var isArg = false;

        for (var index = 0; index < templateSpan.Length; index++)
        {
            if (!isArg && templateSpan[index] == startArg)
            {
                isArg = true;
                currentStartArg = index + 1;
            }
            else if (isArg)
            {
                if (templateSpan[index] == endArg)
                {
                    if (currentStartArg == index)
                    {
                        isArg = false;
                    }
                    else
                    {
                        var argName = templateSpan.Slice(currentStartArg, index - currentStartArg).ToString();
                        var property = type.GetProperty(argName);

                        if (property is null)
                        {
                            isArg = false;

                            continue;
                        }

                        var textLength = currentStartArg - 1 - currentStart;
                        var text = templateSpan.Slice(currentStart, textLength);
                        stringBuilder.Append(text);
                        currentStart = index + 1;
                        var value = property.GetValue(args)?.ToString() ?? string.Empty;
                        stringBuilder.Append(value);
                        isArg = false;
                    }
                }
                else if (!argCharsSpan.Contains(templateSpan[index]))
                {
                    isArg = false;
                }
            }
        }

        stringBuilder.Append(templateSpan.Slice(currentStart, templateSpan.Length - currentStart));

        return stringBuilder.ToString();
    }
}