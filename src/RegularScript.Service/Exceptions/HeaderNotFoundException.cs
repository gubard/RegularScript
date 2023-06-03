using System;

namespace RegularScript.Service.Exceptions;

public class HeaderNotFoundException : Exception
{
    public HeaderNotFoundException(string headerKey)
    {
        HeaderKey = headerKey;
    }

    public string HeaderKey { get; }
}