using System;
using System.IO;
using System.Threading.Tasks;

namespace RegularScript.Service.Interfaces;

public interface IIdempotentService
{
    Task AddAsync(Guid id, Stream stream);
    Task<Stream?> GetOrNullAsync(Guid id);
}