using System;

namespace SharedData.DTO
{
    public sealed record User(Guid Id, string FullName);
}