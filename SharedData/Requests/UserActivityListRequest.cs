using SharedData.ViewModels;

namespace SharedData.Requests
{
    public sealed record UserActivityListRequest(UserVm user, int Month);
}