using Data.Entities;
using SharedData.DTO;
using Utilities;

namespace Services.Implementations.Validation
{
    internal sealed class UserModelValidation
    {
        private readonly UserDto _userModel;
        private readonly User _user;

        public UserModelValidation(UserDto userModel, User user)
        {
            _userModel = userModel;
            _user = user;
        }
        
        public bool UserAlreadyExists => _user is not null;
        public bool RequiredFieldsAreNotFilled => (IsEmailEmpty || IsFirstNameEmpty || IsLastNameEmpty);
        public static implicit operator bool(UserModelValidation validation) => validation.Passed;

        private bool IsFirstNameEmpty => _userModel.FirstName.IsNullOrEmpty();
        private bool IsLastNameEmpty => _userModel.LastName.IsNullOrEmpty();
        private bool IsEmailEmpty => _userModel.Email.IsNullOrEmpty();
        private bool Passed => !(IsEmailEmpty || IsFirstNameEmpty || IsLastNameEmpty || UserAlreadyExists);

        
        
        
    }
}