using System;
using RegularScript.Core.AdoDotNet.Extensions;
using RegularScript.Core.AdoDotNet.Interfaces;

namespace RegularScript.Core.AdoDotNet.Exceptions;

public class ConnectionParametersException<TConnectionParameters> : Exception
    where TConnectionParameters : IConnectionParameters
{
    public TConnectionParameters ConnectionParameters { get; }

    public ConnectionParametersException(
        TConnectionParameters connectionParameters,
        Exception inner
    )
        : base($"Exception in {connectionParameters.GetSafeConnectionString()}", inner)
    {
        ConnectionParameters = connectionParameters;
    }
}
