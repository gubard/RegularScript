using System.Collections.Generic;
using RegularScript.Core.AdoDotNet.Models;

namespace RegularScript.Core.AdoDotNet.Interfaces;

public interface IConnectionParameters
{
    IEnumerable<ConnectionParameter> Parameters { get; }
    IEnumerable<ConnectionParameter> SafeParameters { get; }
}
