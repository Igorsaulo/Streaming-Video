using System;
using System.Threading.Tasks;
using Video_Streaming.Models;

namespace Video_Streaming.Repositories.Interfaces
{
    public interface IComentarioRepository
    {
        Task<Comentario> CreateAsync(Comentario comentario);
        Task<Comentario> FindByIdAsync(Guid ComentarioId);
        Task<Comentario> UpdateAsync(Comentario comentario);
        Task DeleteAsync(Guid ComentarioId);
    }
}