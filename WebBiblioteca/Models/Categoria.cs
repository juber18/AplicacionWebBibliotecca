using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace WebBiblioteca.Models
{
    public class Categoria
    {
        public int CategoriaId { get; set; }

        [Display(Name = "Nombre de la cotegoría:")]
        [Required(ErrorMessage = "Campo obligatorio")]
        public string NombreCategoria { get; set; }
        [Display(Name = "Descripción:")]
        [Required(ErrorMessage = "Campo obligatorio")]
        public string Descripcion { get; set; }
        //Propiedades de tipo dialogo: Prueba
        public ICollection<Libro> Libro { get; set; }
    }
}
