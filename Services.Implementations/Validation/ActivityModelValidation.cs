using System;
using SharedData.DTO;
using Utilities;

namespace Services.Implementations.Validation
{
    public class ActivityModelValidation
    {
        private readonly ActivityDto _activityDto;

        public ActivityModelValidation(ActivityDto activityDto)
        {
            _activityDto = activityDto;
        }

        public bool RequiredFieldsAreNotFilled => IsDateTimeEmpty || IsNoteNullOrEmpty || IsTimeSpentZero || IsUserNull;

        private bool IsTimeSpentZero => _activityDto.HoursSpent == 0;
        private bool IsDateTimeEmpty => _activityDto.Date == DateTime.MinValue;
        private bool IsNoteNullOrEmpty => _activityDto.Note.IsNullOrEmpty();
        private bool IsUserNull => _activityDto.User is null;

    }
}