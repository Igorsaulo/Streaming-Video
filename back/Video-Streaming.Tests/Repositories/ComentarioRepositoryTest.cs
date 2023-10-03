namespace Video_Streaming.Tests.Repositories
{
    public class ComentarioRepositoryTest
    {
        private readonly Mock<IComentarioRepository> mock = new Mock<IComentarioRepository>();

        Comentario comentario = new Comentario
        {
            ComentarioId = Guid.NewGuid(),
            Text = "This is a comment",
            VideoId = Guid.NewGuid(),
            UserId = Guid.NewGuid(),
        };

        [Fact]
        public async Task CreateComentario()
        {
            // Arrange
            mock.Setup(m => m.CreateAsync(comentario)).ReturnsAsync(comentario);

            // Act
            var result = await mock.Object.CreateAsync(comentario);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(comentario, result);
        }

        [Fact]
        public async Task FindById()
        {
            // Arrange
            mock.Setup(m => m.FindByIdAsync(comentario.ComentarioId)).ReturnsAsync(comentario);

            // Act
            var result = await mock.Object.FindByIdAsync(comentario.ComentarioId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(comentario, result);
        }

        [Fact]
        public async Task UpdateComentario()
        {
            // Arrange
            mock.Setup(m => m.UpdateAsync(comentario)).ReturnsAsync(comentario);

            // Act
            var result = await mock.Object.UpdateAsync(comentario);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(comentario, result);
        }

        [Fact]
        public async Task DeleteComentario()
        {
            // Arrange
            mock.Setup(m => m.DeleteAsync(comentario.ComentarioId));

            // Act
            await mock.Object.DeleteAsync(comentario.ComentarioId);

            // Assert
            mock.Verify(m => m.DeleteAsync(comentario.ComentarioId), Times.Once());
        }
    }
}
