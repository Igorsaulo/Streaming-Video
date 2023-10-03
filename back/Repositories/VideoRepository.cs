using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Video_Streaming.Models;
using Video_Streaming.Repositories.Interfaces;
using Video_Streaming.Data;
using Video_Streaming.Repositories.DTOs;

namespace Video_Streaming.Repositories
{
    public class VideoRepository : IVideoRepository
    {
        private readonly AppDbContext _context;

        public VideoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Video> CreateAsync(Video video)
        {
            _context.Videos.Add(video);
            await _context.SaveChangesAsync();
            return video;
        }

        public async Task<Video> FindByIdAsync(Guid VideoId)
        {
            return await _context.Videos.FirstOrDefaultAsync(video => video.VideoId == VideoId);
        }

        public async Task<Video> UpdateAsync(Video video)
        {
            _context.Entry(video).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return video;
        }

        public async Task DeleteAsync(Guid VideoId)
        {
            var video = await _context.Videos.FindAsync(VideoId);
            _context.Videos.Remove(video);
            await _context.SaveChangesAsync();
        }

        public async Task<VideoResultDTO> getVideoPaginated(int page, int perPage)
        {
            var videos = await _context.Videos
                .Skip((page - 1) * perPage)
                .Take(perPage)
                .ToListAsync();

            var totalVideos = await _context.Videos.CountAsync();
            var totalPages = (int)Math.Ceiling((double)totalVideos / perPage);

            return new VideoResultDTO { Videos = videos, TotalPages = totalPages };
        }
    }
}
