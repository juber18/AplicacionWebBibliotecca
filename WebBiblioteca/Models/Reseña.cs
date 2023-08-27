using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace WebBiblioteca.Models
{
    public class Reseña
    {
        public int LibroID { get; set; }
        public int UsuarioID { get; set; }

        [Display(Name = "Calificación:")]
        [Required(ErrorMessage = "Campo obligatorio")]
        public string Calificacion { get; set; }
        [Display(Name = "Texto de reseña:")]
        [Required(ErrorMessage = "Campo obligatorio")]
        public string TextReseña { get; set;}
        //Propiedades de tipo diálogo: Prueba
        public Usuario Usuario { get; set; }
        public Libro Libro { get; set; }

    }
}
