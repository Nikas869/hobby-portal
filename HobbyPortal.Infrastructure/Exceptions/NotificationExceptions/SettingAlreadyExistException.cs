using System;

namespace HobbyPortal.Infrastructure.Exceptions.NotificationExceptions
{
    public class SettingAlreadyExistException : Exception
    {
        public SettingAlreadyExistException(string message) : base(message)
        {
        }
    }
}
