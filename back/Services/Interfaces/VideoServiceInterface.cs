using System;
using System.Threading.Tasks;

namespace Video_Streaming.Services.Interfaces
{
    public interface IVideoService
    {
        Task<Video> PostVideo(
            Guid UserId,
            IFormFile file,
            VideoPostDTO videoPostDTO,
            IFormFile thumbnail
        );
        Task<List<VideoGetDTO>> GetVideoPaginated(int page, int perPage);
    }
}
