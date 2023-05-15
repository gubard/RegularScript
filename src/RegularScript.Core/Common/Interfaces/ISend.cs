using System.Threading;
using System.Threading.Tasks;

namespace RegularScript.Core.Common.Interfaces;

public interface ISend<in TMessage>
{
    void Send(TMessage message);
    Task SendAsync(TMessage message, CancellationToken token);
}