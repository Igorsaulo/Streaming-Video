using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;

namespace Video_Streaming.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VideoController : ControllerBase
    {
        private readonly IVideoRepository _videoRepository;
        private readonly IVideoService _videoService;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public VideoController(
            IVideoRepository videoRepository,
            IVideoService videoService,
            IWebHostEnvironment hostingEnvironment
        )
        {
            _videoRepository = videoRepository;
            _videoService = videoService;
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpPost("{userId}")]
        [Authorize]
        [ApiExplorerSettings(IgnoreApi = true)]
        [RequestFormLimits(MultipartBodyLengthLimit = 104857600)]
        [RequestSizeLimit(104857600)]
        public async Task<IActionResult> PostVideo(
            Guid userId,
            [FromForm] IFormFile file,
            [FromForm] VideoPostDTO videoPostDTO,
            [FromForm] IFormFile thumbnail
        )
        {
            var video = await _videoService.PostVideo(userId, file, videoPostDTO, thumbnail);
            return Ok(video);
        }

        [HttpGet("play/{videoId}")]
        public async Task<IActionResult> GetVideo(Guid videoId)
        {
            var video = await _videoRepository.FindByIdAsync(videoId);
            if (video == null)
            {
                return NotFound();
            }
            // Obtem o caminho raiz da pasta "wwwroot"
            var webRootPath = _hostingEnvironment.WebRootPath;

            // Construa o caminho completo para o vídeo usando o caminho raiz
            var filePath = Path.Combine(webRootPath, video.Url.TrimStart('/'));

            // Verifica se o arquivo de vídeo existe no sistema de arquivos
            if (System.IO.File.Exists(filePath))
            {
                // Determine o tipo de mídia com base na extensão do arquivo
                var contentType = GetContentType(filePath);

                // Retorna o arquivo como FileStreamResult
                var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                return File(stream, contentType);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateVideo(
            Guid id,
            [FromForm] Video video,
            IFormFile file
        )
        {
            var existingVideo = await _videoRepository.FindByIdAsync(id);
            if (existingVideo == null)
            {
                return NotFound();
            }

            if (file != null && file.Length > 0)
            {
                var filePath = Path.Combine(
                    Directory.GetCurrentDirectory(),
                    "wwwroot",
                    "videos",
                    $"{existingVideo.VideoId}.mp4"
                );
                System.IO.File.Delete(filePath);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                existingVideo.Url = $"/videos/{existingVideo.VideoId}.mp4";
            }

            existingVideo.Title = video.Title;
            existingVideo.Description = video.Description;

            await _videoRepository.UpdateAsync(existingVideo);

            return Ok(existingVideo);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteVideo(Guid id)
        {
            var existingVideo = await _videoRepository.FindByIdAsync(id);
            if (existingVideo == null)
            {
                return NotFound();
            }

            var filePath = Path.Combine(
                Directory.GetCurrentDirectory(),
                "wwwroot",
                "videos",
                $"{existingVideo.VideoId}.mp4"
            );
            System.IO.File.Delete(filePath);

            await _videoRepository.DeleteAsync(id);

            return NoContent();
        }

        [HttpGet("page/{page}")]
        public async Task<IActionResult> GetVideoPaginated(int page)
        {
            var videos = await _videoService.GetVideoPaginated(page, 10);
            return Ok(videos);
        }

        [HttpGet("thumbnail/{videoId}")]
        public async Task<IActionResult> GetVideoThumbnail(Guid videoId)
        {
            var video = await _videoRepository.FindByIdAsync(videoId);
            if (video == null)
            {
                return NotFound();
            }

            // Obtem o caminho raiz da pasta "wwwroot"
            var webRootPath = _hostingEnvironment.WebRootPath;

            // Construa o caminho completo para a miniatura usando o caminho raiz
            var thumbnailPath = Path.Combine(webRootPath, video.Thumbnail.TrimStart('/'));

            // Verifica se o arquivo de miniatura existe no sistema de arquivos
            if (System.IO.File.Exists(thumbnailPath))
            {
                // Determine o tipo de mídia com base na extensão do arquivo
                var contentType = GetContentType(thumbnailPath);

                // Retorna o arquivo como FileStreamResult
                var stream = new FileStream(thumbnailPath, FileMode.Open, FileAccess.Read);
                return File(stream, contentType);
            }
            else
            {
                return NotFound();
            }
        }

        // Método para obter o tipo de mídia com base na extensão do arquivo
        private string GetContentType(string filePath)
        {
            var ext = Path.GetExtension(filePath).ToLowerInvariant();
            return ext switch
            {
                ".jpg" => "image/jpeg",
                ".jpeg" => "image/jpeg",
                ".png" => "image/png",
                ".mp4" => "video/mp4",
                ".webm" => "video/webm",
                _ => "application/octet-stream" // Tipo padrão
            };
        }
    }
};
