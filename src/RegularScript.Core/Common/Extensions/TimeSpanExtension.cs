namespace RegularScript.Core.Common.Extensions;

public static class TimeSpanExtension
{
    public static Task Delay(this TimeSpan timeSpan)
    {
        return Task.Delay(timeSpan);
    }
}