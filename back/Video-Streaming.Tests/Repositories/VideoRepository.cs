namespace Video_Streaming.Tests.Repositories
{
    public class VideoRepositoryTest
    {
        private readonly Mock<IVideoRepository> mock = new Mock<IVideoRepository>();

        Video video = new Video
        {
            VideoId = Guid.NewGuid(),
            Description = "This is a video",
            Title = "Video",
            Thumbnail = "thumbnail",
            Url = "url",
            VideoDatabaseId = 1,
        };

        [Fact]
        public async Task CreateVideo()
        {
            // Arrange
            mock.Setup(m => m.CreateAsync(video)).ReturnsAsync(video);

            // Act
            var result = await mock.Object.CreateAsync(video);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(video, result);
        }

        [Fact]
        public async Task FindById()
        {
            // Arrange
            mock.Setup(m => m.FindByIdAsync(video.VideoId)).ReturnsAsync(video);

            // Act
            var result = await mock.Object.FindByIdAsync(video.VideoId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(video, result);
        }

        [Fact]
        public async Task UpdateVideo()
        {
            // Arrange
            mock.Setup(m => m.UpdateAsync(video)).ReturnsAsync(video);

            // Act
            var result = await mock.Object.UpdateAsync(video);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(video, result);
        }

        [Fact]
        public async Task DeleteVideo()
        {
            // Arrange
            mock.Setup(m => m.DeleteAsync(video.VideoId));

            // Act
            await mock.Object.DeleteAsync(video.VideoId);

            // Assert
            mock.Verify(m => m.DeleteAsync(video.VideoId), Times.Once);
        }
    }
}
