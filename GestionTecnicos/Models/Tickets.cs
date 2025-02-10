using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionTecnicos.Models;

public class Tickets
{
    [Key] public int TicketId { get; set; }

     public int ClienteId { get; set; }

     public DateTime Fecha { get; set; } = DateTime.Now;

    [Required(ErrorMessage = "Este campo es requerido")] 
    public string Prioridad { get; set; }

    [Required(ErrorMessage = "Este campo es requerido")] 
    [StringLength(50, ErrorMessage = "El asusnto no puede exceder los 50 caracteres")] 
    public string Asunto { get; set; }

    [Required(ErrorMessage = "Este campo es requerido")] 
    [StringLength(250, ErrorMessage = "La descripción no puede exceder los 250 caracteres")] 
    public string Descripcion { get; set; }

    [Range(1, double.MaxValue, ErrorMessage = "El tiempo invertido debe ser mayor que cero")]
    [Required(ErrorMessage = "Este campo es requerido")] 
    public double TiempoInvertido { get; set; }

    [ForeignKey("ClienteId")] 
    public Clientes Cliente { get; set; } = null!;
}