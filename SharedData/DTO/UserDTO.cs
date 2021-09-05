namespace SharedData.DTO
{
    public sealed record UserDto(
        string Email,
        string FirstName,
        string LastName,
        string MiddleName
    );
}