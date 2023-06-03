using System;

namespace RegularScript.Db.Entities;

public class IdempotentItemDb
{
    public Guid Id { get; set; }
    public byte[] Data { get; set; }
    public DateTimeOffset Created { get; set; } = DateTimeOffset.Now;
}