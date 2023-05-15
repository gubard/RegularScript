using System;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace RegularScript.Helper;

public class LanguagesLoader
{
    private static readonly Regex regex = new(@"\(([^)]+)\)");

    public async Task ShowLanguagesAsync()
    {
        using var httpClient = new HttpClient();

        var response =
            await httpClient.GetAsync("https://www.loc.gov/standards/iso639-2/php/code_list.php");

        var html = await response.Content.ReadAsStringAsync();
        var htmlDoc = new HtmlDocument();
        htmlDoc.LoadHtml(html);
        var table = htmlDoc.DocumentNode.SelectSingleNode("//body/table/tr/td/table");
        var data = table.ChildNodes.Skip(2).ToArray();
        var stringBuilder = new StringBuilder();

        foreach (var item in data)
        {
            var names = item.ChildNodes[5].InnerText.Split(';');

            var name = regex.Replace(names[^1], "")
                .Replace("languages", "")
                .Replace('�', 'u')
                .Trim();

            stringBuilder.AppendLine(
                $"new Language {{ Id = Guid.Parse(\"{
                    Guid.NewGuid()
                }\"), CodeIso3 = \"{
                    item.ChildNodes[1].InnerText.Substring(0, 3)
                }\", Name = \"{
                    name
                }\" }},"
            );
        }

        var text = stringBuilder.ToString();
        Console.WriteLine(text);
    }
}