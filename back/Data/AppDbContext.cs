using Microsoft.EntityFrameworkCore;
using Video_Streaming.Models;

namespace Video_Streaming.Data
{
    public class AppDbContext : DbContext
    {

        public DbSet<User> Users { get; set; }
        public DbSet<Video> Videos { get; set; }
        public DbSet<Comentario> Comentarios { get; set; }

        // Configurar a conexão com o banco de dados SQLite
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("DataSource=app.db;Cache=Shared");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Video>().ToTable("Videos");
            modelBuilder.Entity<Comentario>().ToTable("Comentarios");
        }
    }
}
