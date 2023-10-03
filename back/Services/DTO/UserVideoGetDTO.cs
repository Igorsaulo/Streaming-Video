using Microsoft.EntityFrameworkCore.Diagnostics.Internal;

namespace Video_Streaming.Services.DTO
{
    public class UserVideoGetDTO
    {
        public string CreatorName { get; set; }
        public string Title { get; set; }
    }
}