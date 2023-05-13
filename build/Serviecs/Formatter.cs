using System.Linq;
using System.Text.RegularExpressions;

namespace Serviecs;

public class Formatter
{
    private readonly Regex parameterRegex = new("{([A-Za-z0-9]+)}");

    public string Format(string input, object args)
    {
        var properties = args.GetType().GetProperties();

        return parameterRegex.Replace(input, match =>
        {
            var property = properties.SingleOrDefault(x => x.Name == match.Groups[1].Value);
            var value = property.GetValue(args);

            return value.ToString();
        });
    }
}