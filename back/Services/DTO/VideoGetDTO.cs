using Microsoft.AspNetCore.Mvc.Filters;

namespace Video_Streaming.Services.DTO
{
    public class VideoGetDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string CreatorName { get; set; }
        public string logoUrl { get; set; }
        public string VideoUrl { get; set; }
        public string VideoThumbnailUrl { get; set; }
        public string pages { get; set; }
        public Guid VideoId { get; set; }
        public Guid UserId { get; set; }
    }
}
