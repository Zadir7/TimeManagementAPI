using System;

namespace SharedData.DTO
{
    public sealed record ActivityDto(User User, double HoursSpent, DateTime Date, string Note);
}