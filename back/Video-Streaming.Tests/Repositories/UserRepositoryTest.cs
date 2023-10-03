namespace Video_Streaming.Tests.Repositories
{
    public class UserRepositoryTest
    {
        private readonly Mock<IUserRepository> mock = new Mock<IUserRepository>();

        User user = new User
        {
            UserDatabaseId = 1,
            UserId = Guid.NewGuid(),
            Name = "John Doe",
            Email = "JohnDoe@gmail.com",
            Password = "321y46216w312",
        };

        [Fact]
        public async Task CreateUser()
        {
            // Arrange
            mock.Setup(m => m.CreateUser(user)).ReturnsAsync(user);

            // Act
            var result = await mock.Object.CreateUser(user);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(user, result);
        }

        [Fact]
        public async Task FindByEmail()
        {
            // Arrange
            mock.Setup(m => m.FindByEmail(user.Email)).ReturnsAsync(user);

            // Act
            var result = await mock.Object.FindByEmail(user.Email);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(user, result);
        }

        [Fact]
        public async Task FindById()
        {
            // Arrange
            mock.Setup(m => m.FindById(user.UserId)).ReturnsAsync(user);

            // Act
            var result = await mock.Object.FindById(user.UserId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(user, result);
        }

        [Fact]
        public async Task UpdateUser()
        {
            // Arrange
            mock.Setup(m => m.UpdateUser(user)).ReturnsAsync(user);

            // Act
            var result = await mock.Object.UpdateUser(user);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(user, result);
        }

        [Fact]
        public async Task DeleteUser()
        {
            // Arrange
            mock.Setup(m => m.DeleteUser(user.UserId)).Verifiable();

            // Act
            await mock.Object.DeleteUser(user.UserId);

            // Assert
            mock.Verify(m => m.DeleteUser(user.UserId), Times.Once);
        }

        [Fact]
        public async Task ValidateUser()
        {
            // Arrange
            mock.Setup(m => m.ValidateUser(user.Password, user.Email)).ReturnsAsync(user);

            // Act
            var result = await mock.Object.ValidateUser(user.Password, user.Email);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(user, result);
        }
    }
}
