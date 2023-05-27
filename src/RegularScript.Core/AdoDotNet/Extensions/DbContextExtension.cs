using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using RegularScript.Core.Common.Extensions;

namespace RegularScript.Core.AdoDotNet.Extensions;

public static class DbContextExtension
{
    public static void Execute<TContext>(
        this TContext context,
        Action<TContext, IDbContextTransaction> execute
    )
        where TContext : DbContext
    {
        execute.ThrowIfNull();
        var transaction = context.Database.CurrentTransaction;

        try
        {
            transaction ??= context.Database.BeginTransaction();
            execute.Invoke(context, transaction);
            transaction.Commit();
        }
        catch
        {
            transaction?.Rollback();

            throw;
        }
    }

    public static async Task ExecuteAsync<TContext>(
        this TContext context,
        Func<TContext, Task> execute
    )
        where TContext : DbContext
    {
        execute.ThrowIfNull();
        var database = context.Database;
        var transaction = database.CurrentTransaction;

        try
        {
            transaction ??= await database.BeginTransactionAsync();
            await execute.Invoke(context);
            await transaction.CommitAsync();
        }
        catch
        {
            if (transaction is not null)
            {
                await transaction.RollbackAsync();
            }

            throw;
        }
    }

    public static TResult Execute<TContext, TResult>(
        this TContext context,
        Func<TContext, IDbContextTransaction, TResult> execute
    )
        where TContext : DbContext
    {
        execute.ThrowIfNull();
        var transaction = context.Database.CurrentTransaction;

        try
        {
            transaction ??= context.Database.BeginTransaction();
            var result = execute.Invoke(context, transaction);
            transaction.Commit();

            return result;
        }
        catch
        {
            transaction?.Rollback();

            throw;
        }
    }

    public static async Task<TResult> ExecuteAsync<TContext, TResult>(
        this TContext context,
        Func<TContext, Task<TResult>> execute
    )
        where TContext : DbContext
    {
        execute.ThrowIfNull();
        var transaction = context.Database.CurrentTransaction;

        try
        {
            transaction ??= await context.Database.BeginTransactionAsync();
            var result = await execute.Invoke(context);
            await transaction.CommitAsync();

            return result;
        }
        catch
        {
            if (transaction is not null)
            {
                await transaction.RollbackAsync();
            }

            throw;
        }
    }
}