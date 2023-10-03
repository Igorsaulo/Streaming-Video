using System;
using System.ComponentModel.DataAnnotations;

namespace Video_Streaming.Models
{
    public class Comentario
    {
        public int ComentarioDatabaseId { get; set; }
        public Guid ComentarioId { get; set; }

        [Required(ErrorMessage = "O campo Text é obrigatório.")]
        public string Text { get; set; }

        // Foreign key

        [Required(ErrorMessage = "O campo UserId é obrigatório.")]
        public Guid UserId { get; set; }

        [Required(ErrorMessage = "O campo VideoId é obrigatório.")]
        public Guid VideoId { get; set; }
    }
}
