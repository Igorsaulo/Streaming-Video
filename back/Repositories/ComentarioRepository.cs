using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Video_Streaming.Models;
using Video_Streaming.Repositories.Interfaces;
using Video_Streaming.Data;

namespace Video_Streaming.Repositories
{
    public class ComentarioRepository : IComentarioRepository
    {
        private readonly AppDbContext _context;

        public ComentarioRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Comentario> CreateAsync(Comentario comentario)
        {
            _context.Comentarios.Add(comentario);
            await _context.SaveChangesAsync();
            return comentario;
        }

        public async Task<Comentario> FindByIdAsync(Guid ComentarioId)
        {
            return await _context.Comentarios.FirstOrDefaultAsync(
                comentario => comentario.ComentarioId == ComentarioId
            );
        }

        public async Task<Comentario> UpdateAsync(Comentario comentario)
        {
            _context.Entry(comentario).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return comentario;
        }

        public async Task DeleteAsync(Guid ComentarioId)
        {
            var comentario = await _context.Comentarios.FindAsync(ComentarioId);
            _context.Comentarios.Remove(comentario);
            await _context.SaveChangesAsync();
        }
    }
}