using System.ComponentModel.DataAnnotations;

namespace WebBiblioteca.Models
{
    public class Ejemplar
    {
        public int EjemplarId { get; set; }
        public int LibroId { get; set; }
        [Display(Name ="Localización:")]
        [Required(ErrorMessage ="Campo obligatorio")]
        public string Localizacion { get; set; }
        //Propiedades de diálogo: Preuba
        public Libro Libro { get; set; }

        public ICollection<Prestamo> Prestamo { get; set; }
    }
}
