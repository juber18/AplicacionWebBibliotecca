using Microsoft.EntityFrameworkCore;
using WebBiblioteca.Models;

namespace WebBiblioteca.Data
{
    public class BibliotecaContext: DbContext
    {
        public BibliotecaContext(DbContextOptions opciones):base(opciones)
        { 
        }
        public DbSet<Autor> Autors { get; set; }
        public DbSet<Libro> Libros { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Ejemplar> Ejemplars { get; set; }
        public DbSet<Reseña> Reseñas { get; set; }
        public DbSet<Prestamo> Prestamos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Autor>().ToTable("Autor");
            modelBuilder.Entity<Libro>().ToTable("Libro");
            modelBuilder.Entity<Categoria>().ToTable("Categoria");
            modelBuilder.Entity<Usuario>().ToTable("Usuario");
            modelBuilder.Entity<Ejemplar>().ToTable("Ejemplar");
            modelBuilder.Entity<Reseña>().ToTable("Reseña").HasKey(t => new {t.LibroID, t.UsuarioID});
            modelBuilder.Entity<Prestamo>().ToTable("Prestamo").HasKey(a => new { a.EjemplarID, a.UsuarioID });
        }
    }
}
