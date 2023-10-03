using System;
using System.ComponentModel.DataAnnotations;

namespace Video_Streaming.Models
{
    public class Video
    {
        public int VideoDatabaseId { get; set; }
        public Guid VideoId { get; set; }

        [Required(ErrorMessage = "O campo Name é obrigatório.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "O campo Description é obrigatório.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "O campo Url é obrigatório.")]
        public string Url { get; set; }

        [Required(ErrorMessage = "O campo Thumbnail é obrigatório.")]
        public string Thumbnail { get; set; }

        //Foreign key

        [Required(ErrorMessage = "O campo UserId é obrigatório.")]
        public Guid UserId { get; set; }

        // Relational fields
        public Comentario[]? Comentarios { get; set; }
    }
}
