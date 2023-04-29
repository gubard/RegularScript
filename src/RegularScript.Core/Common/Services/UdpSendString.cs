using System.Net;
using System.Text;
using RegularScript.Core.Common.Extensions;

namespace RegularScript.Core.Common.Services;

public class UdpSendString : UdpSend<string>
{
    public UdpSendString(IPEndPoint ipEndPoint, Encoding encoding)
        : base(ipEndPoint, converter: s => encoding.GetBytes(s))
    {
        encoding.ThrowIfNull(paramName: nameof(encoding));
    }
}