using System.Text;
using RegularScript.Core.Common.Extensions;
using RegularScript.Core.Common.Interfaces;

namespace RegularScript.Core.Common.Services;

public class StreamHumanizing : IHumanizing<Stream, string>
{
    private readonly string breakString;
    private readonly ulong charSize;
    private readonly Encoding encoding;
    private readonly ushort encodingCharSize;
    private readonly string splitString;

    public StreamHumanizing(
        string splitString,
        ulong charSize,
        string breakStrings,
        Encoding encoding,
        ushort encodingCharSize
    )
    {
        this.splitString = splitString;
        this.charSize = charSize;
        breakString = breakStrings;
        this.encoding = encoding.ThrowIfNull();
        this.encodingCharSize = encodingCharSize;
    }

    public StreamHumanizing() : this(
        splitString: " ",
        charSize: 2,
        Environment.NewLine,
        Encoding.UTF8,
        encodingCharSize: 4)
    {
    }

    public string Humanize(Stream stream)
    {
        var stringBuilder = new StringBuilder();
        var buffer = new Span<byte>(array: new byte[encodingCharSize * charSize]);

        while (stream.Read(buffer) != 0)
        {
            for (var index = 0; index < buffer.Length; index++)
            {
                stringBuilder.Append(value: buffer[index].ToString(format: "X2"));
                stringBuilder.Append(splitString);
            }

            stringBuilder.Append(value: encoding.GetString(buffer));
            stringBuilder.Append(breakString);
        }

        return stringBuilder.ToString();
    }
}