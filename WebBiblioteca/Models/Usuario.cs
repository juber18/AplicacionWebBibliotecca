using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace WebBiblioteca.Models
{
    public class Usuario
    {
        public int UsuarioId { get; set; }

        [Display(Name = "Nombre Completo:")]
        [Required(ErrorMessage = "Campo obligatorio")]
        public string Nombre { get; set; }
        [Display(Name = "DNI:")]
        [Required(ErrorMessage = "Campo obligatorio")]
        public string DNI { get; set; }
        [Display(Name = "Teléfono:")]
        [Required(ErrorMessage = "Campo obligatorio")]
        public string Telefono { get; set; }
        [Display(Name = "Dirección:")]
        [Required(ErrorMessage = "Campo obligatorio")]
        public string Direccion { get; set; }
        [Display(Name = "Correo electrónico:")]
        [Required(ErrorMessage = "Campo obligatorio")]
        [EmailAddress]
        public string Correo { get; set; }
        //Propiedades de tipo diálogo: Prueba
        public ICollection<Reseña> Reseña { get; set; }
        public ICollection<Prestamo> Prestamo { get; set; }
    }
}
