using System.ComponentModel.DataAnnotations;

namespace WebBiblioteca.Models
{
    public class Autor
    {
        public int AutorId { get; set; }

        [Display(Name ="Nombre Completo:")]
        [Required(ErrorMessage ="Campo obligatorio")]
        public string Nombre { get; set; }
        [Display(Name = "Nacionalidad:")]
        [Required(ErrorMessage = "Campo obligatorio")]
        public string Nacionalidad { get; set; }
        //Propiedades de tipo diálogo
        //aaaaasssssggggg
        //eeeee
        public ICollection<Libro> Libro { get; set; }
    }
}
