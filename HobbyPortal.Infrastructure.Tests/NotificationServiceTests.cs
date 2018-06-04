using HobbyPortal.Infrastructure.Exceptions.NotificationExceptions;
using HobbyPortal.Infrastructure.Models;
using HobbyPortal.Infrastructure.Services;
using Microsoft.AspNetCore.Identity;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;
using Microsoft.EntityFrameworkCore;

namespace HobbyPortal.Infrastructure.Tests
{
    public class NotificationServiceTests
    {
        const string userId = "userId";
        const string userName = "userName";

        [Fact]
        public void CheckExistingSettings_ThrowsException_WhenSettingIsAlreadyExist()
        {
            // Arrange
            var context = GetFakeContext();

            var userStoreMock = new Mock<IUserStore<ApplicationUser>>();

            var userMock = new Mock<ApplicationUser>();
            userMock.Setup(user => user.Id)
                .Returns(userId);
            Mock<UserManager<ApplicationUser>> userManagerMock = GetUserManagerMock(userStoreMock, userMock);

            var service = new NotificationService(null, context, userManagerMock.Object, null);

            // Act & Assert
            Assert.ThrowsAsync<SettingAlreadyExistException>(() => service.TryCreateUserNotificationSettings(userName));
        }

        private static Mock<UserManager<ApplicationUser>> GetUserManagerMock(Mock<IUserStore<ApplicationUser>> userStoreMock, Mock<ApplicationUser> userMock)
        {
            var userManagerMock = new Mock<UserManager<ApplicationUser>>(userStoreMock.Object, null, null, null, null, null, null, null, null);
            userManagerMock.Setup(manager => manager.FindByNameAsync(userName))
                .Returns(Task.FromResult(userMock.Object));
            return userManagerMock;
        }

        private static ApplicationDbContext GetFakeContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var context = new ApplicationDbContext(options);
            context.NotificationUserSettings.Add(new NotificationUserSetting(NotificationProvider.Telegram.ToString(), string.Empty, userId));
            context.SaveChanges();
            return context;
        }
    }
}
