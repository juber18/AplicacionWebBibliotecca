using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using System.Runtime.CompilerServices;


namespace WebBiblioteca.Models
{
    public class Libro
    {
        public int LibroId { get; set; }
        public int AutorId { get; set; }
        public int CategoriaId { get; set; }

        [Display(Name = "Nombre del libro:")]
        [Required(ErrorMessage = "Campo obligatorio")]
        public string Titulo { get; set;}
        [Display(Name = "Año de publicación:")]
        [Required(ErrorMessage = "Campo obligatorio")]
        public DateTime AñoPublicacion { get; set; }
        [Display(Name = "Editorial:")]
        [Required(ErrorMessage = "Campo obligatorio")]
        public string Editorial { get; set; }
        [Display(Name = "ISBN:")]
        [Required(ErrorMessage = "Campo obligatorio")]
        public string ISBN { get; set; }
        //Propiedades de tipo diálogo:Prueba
        public Autor Autor { get; set; }
        public Categoria Categoria { get; set; }
       
        public ICollection<Reseña> Reseña { get; set; }
        public ICollection<Ejemplar> Ejemplar { get; set; }
        
    }
}
