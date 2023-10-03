using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
using System.Diagnostics;

namespace Video_Streaming.Services
{
    public class VideoService : IVideoService
    {
        private readonly IVideoRepository _videoRepository;
        private readonly IUserRepository _userRepository;

        public VideoService(IVideoRepository videoRepository, IUserRepository userRepository)
        {
            _videoRepository = videoRepository;
            _userRepository = userRepository;
        }

        public async Task<Video> PostVideo(
            Guid UserId,
            IFormFile file,
            VideoPostDTO videoPostDTO,
            IFormFile thumbnail
        )
        {
            var user = await _userRepository.FindById(UserId);
            if (user == null)
            {
                throw new Exception("User not found");
            }

            var videoFilePath = await UploadVideo(file);

            var video = new Video
            {
                UserId = UserId,
                Title = videoPostDTO.Title,
                Description = videoPostDTO.Description,
                Url = videoFilePath,
                Thumbnail = await UploadThumbnail(thumbnail),
            };

            video = await _videoRepository.CreateAsync(video);
            return video;
        }

        public async Task<string> UploadVideo(IFormFile file)
        {
            try
            {
                // Especifia o caminho do diretório onde os vídeos serão salvos
                string diretórioUpload = Path.Combine(
                    Directory.GetCurrentDirectory(),
                    "wwwroot",
                    "videos"
                );

                // Garante que o diretório exista
                if (!Directory.Exists(diretórioUpload))
                {
                    Directory.CreateDirectory(diretórioUpload);
                }

                // Gera um nome de arquivo exclusivo para o vídeo (usando .mp4)
                string nomeArquivoExclusivo =
                    Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                string caminhoArquivo = Path.Combine(diretórioUpload, nomeArquivoExclusivo);

                // Salva o arquivo de vídeo
                using (var stream = new FileStream(caminhoArquivo, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                // Retorna o caminho onde o vídeo foi salvo
                 return $"/videos/{nomeArquivoExclusivo}";
            }
            catch (Exception ex)
            {
                throw new Exception("Falha ao carregar o vídeo", ex);
            }
        }

        public async Task<string> UploadThumbnail(IFormFile file)
        {
            try
            {
                // thumbnails dir
                string diretórioThumbnail = Path.Combine(
                    Directory.GetCurrentDirectory(),
                    "wwwroot",
                    "thumbnails"
                );

                // Garante que o diretório exista
                if (!Directory.Exists(diretórioThumbnail))
                {
                    Directory.CreateDirectory(diretórioThumbnail);
                }

                // Gera um nome de arquivo exclusivo para a miniatura (usando .jpg)
                string nomeArquivoExclusivo = Guid.NewGuid().ToString() + ".jpg";
                string caminhoArquivo = Path.Combine(diretórioThumbnail, nomeArquivoExclusivo);

                // Salvs o arquivo de miniatura
                using (var stream = new FileStream(caminhoArquivo, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                // Retorna o caminho onde a miniatura foi salva
                return $"/thumbnails/{nomeArquivoExclusivo}";
            }
            catch (Exception ex)
            {
                throw new Exception("Falha ao carregar a miniatura", ex);
            }
        }


        public async Task<List<VideoGetDTO>> GetVideoPaginated(int page, int perPage)
        {
            var videoResult = await _videoRepository.getVideoPaginated(page, perPage);
            var videoGetDTOs = new List<VideoGetDTO>();
            foreach (var video in videoResult.Videos)
            {
                var user = await _userRepository.FindById(video.UserId);
                var videoGetDTO = new VideoGetDTO
                {
                    VideoId = video.VideoId,
                    Title = video.Title,
                    Description = video.Description,
                    VideoUrl = video.Url,
                    VideoThumbnailUrl = video.Thumbnail,
                    UserId = user.UserId,
                    CreatorName = user.Name,
                    logoUrl = user.LogoUrl,
                    pages = videoResult.TotalPages.ToString(),
                };

                videoGetDTOs.Add(videoGetDTO);
            }
            return videoGetDTOs;
        }
    }
}
