using System.Text;
using System.Text.RegularExpressions;
using HtmlAgilityPack;

namespace RegularScript.Helper;

public class LanguagesLoader
{
    private static readonly Regex regex = new (pattern: @"\(([^)]+)\)");

    public async Task ShowLanguagesAsync()
    {
        using var httpClient = new HttpClient();

        var response =
            await httpClient.GetAsync(requestUri: "https://www.loc.gov/standards/iso639-2/php/code_list.php");

        var html = await response.Content.ReadAsStringAsync();
        var htmlDoc = new HtmlDocument();
        htmlDoc.LoadHtml(html);
        var table = htmlDoc.DocumentNode.SelectSingleNode(xpath: "//body/table/tr/td/table");
        var data = table.ChildNodes.Skip(count: 2).ToArray();
        var stringBuilder = new StringBuilder();

        foreach (var item in data)
        {
            var names = item.ChildNodes[index: 5].InnerText.Split(separator: ';');

            var name = regex.Replace(input: names[^1], replacement: "")
               .Replace(oldValue: "languages", newValue: "")
               .Replace(oldChar: '�', newChar: 'u')
               .Trim();

            stringBuilder.AppendLine(
                handler: $"new Language {{ Id = Guid.Parse(\"{
                    Guid.NewGuid()
                }\"), CodeIso3 = \"{
                    item.ChildNodes[index: 1].InnerText.Substring(startIndex: 0, length: 3)
                }\", Name = \"{
                    name
                }\" }},");
        }

        var text = stringBuilder.ToString();
        Console.WriteLine(text);
    }
}