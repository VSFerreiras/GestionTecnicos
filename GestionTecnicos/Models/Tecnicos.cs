using System.ComponentModel.DataAnnotations;

namespace GestionTecnicos.Models;

public class Tecnicos
{
    [Key]
    public int TecnicoId { get; set; }
    
    [RegularExpression(@"^[a-zA-ZñÑáéíóúÁÉÍÓÚüÜ\s]+$", ErrorMessage = "El nombre solo debe contener letras y espacios")]
    [StringLength(maximumLength: 50, ErrorMessage = "El nombre no debe exceder los 50 caracteres")]
    [Required(ErrorMessage = "Este campo es requerido")]
    public string Nombres { get; set; }

    [Range(0.00, 1000.00, ErrorMessage = "El sueldo debe ser positivo y no puede exceder 1,000")]
    [Required(ErrorMessage = "Este campo es requerido")]
    public float SueldoHora { get; set; }
}