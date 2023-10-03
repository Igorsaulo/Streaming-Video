using System;
using System.ComponentModel.DataAnnotations;

namespace Video_Streaming.Models
{
    public class User
    {
        public int UserDatabaseId { get; set; }
        public Guid UserId { get; set; }

        [Required(ErrorMessage = "O campo Name é obrigatório.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O campo Email é obrigatório.")]
        [EmailAddress(ErrorMessage = "O campo Email deve ser um endereço de e-mail válido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo Password é obrigatório.")]
        [MinLength(8, ErrorMessage = "O campo Password deve ter no mínimo 8 caracteres.")]
        public string Password { get; set; }
        public string? LogoUrl { get; set; }
        public ICollection<Video>? Videos { get; set; }
    }
}
