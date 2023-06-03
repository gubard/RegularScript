using System;
using System.IO;
using System.Threading.Tasks;
using RegularScript.Service.Interfaces;

namespace RegularScript.Service.Services;

public class IdempotentService : IIdempotentService
{
    public Task AddAsync(Guid id, Stream stream)
    {
        throw new NotImplementedException();
    }

    public Task<Stream?> GetOrNullAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}