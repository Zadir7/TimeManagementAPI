using System;
using SharedData.ViewModels;

namespace SharedData.DTO
{
    public sealed record ActivityDto(UserVm User, double HoursSpent, DateTime Date, string Note);
}