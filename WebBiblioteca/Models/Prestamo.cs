using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace WebBiblioteca.Models
{
    public class Prestamo
    {
        public int EjemplarID { get; set; }
        public int UsuarioID { get; set; }

        [Display(Name = "Fecha de préstamo:")]
        [Required(ErrorMessage = "Campo obligatorio")]
        [DisplayFormat(DataFormatString = "{0: dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime FechaPrestamo { get; set; }
        [Display(Name = "Fecha de devolución:")]
        [Required(ErrorMessage = "Campo obligatorio")]
        [DisplayFormat(DataFormatString = "{0: dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime FechaDevolucion { get; set; }
        [Display(Name = "Estado:")]
        [Required(ErrorMessage = "Campo obligatorio")]
        public string Estado { get; set; }
        //Propiedades de diálogo: Prueba
        public Ejemplar Ejemplar { get; set; }
        public Usuario Usuario { get; set; }
    }
}
