using System;
using System.Diagnostics;
using System.Threading;
using Npgsql;

namespace Extensions;

public static class DbConnectionExtension
{
    public static void WaitConnection(this string connectionString, TimeSpan timeout)
    {
        var stopwatch = Stopwatch.StartNew();
        Exception lastException = null;

        while (true)
        {
            try
            {
                using var npgsqlConnection = new NpgsqlConnection(connectionString);
                npgsqlConnection.Open();
                Thread.Sleep(500);

                if (stopwatch.ElapsedMilliseconds > timeout.TotalMilliseconds)
                {
                    throw new TimeoutException("Timeout NpgsqlConnection.", lastException);
                }
                
                return;
            }
            catch (Exception e)
            {
                lastException = e;
            }
        }
    }
}