using System;
using System.Threading.Tasks;
using Video_Streaming.Models;
using Video_Streaming.Repositories.DTOs;

namespace Video_Streaming.Repositories.Interfaces
{
    public interface IVideoRepository
    {
        Task<Video> CreateAsync(Video video);
        Task<Video> FindByIdAsync(Guid VideoId);
        Task<Video> UpdateAsync(Video video);
        Task DeleteAsync(Guid VideoId);
        Task<VideoResultDTO> getVideoPaginated(int page, int perPage);
    }
}