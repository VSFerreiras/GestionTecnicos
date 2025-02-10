using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionTecnicos.Models;

public class Ciudades
{
    [Key] public int CiudadId { get; set; }
   
    [RegularExpression(@"^[a-zA-ZñÑáéíóúÁÉÍÓÚüÜ\s]+$", ErrorMessage = "El nombre solo debe contener letras y espacios")]
    [StringLength(maximumLength: 40, ErrorMessage = "El nombre no debe exceder los 40 caracteres")]
    [Required(ErrorMessage = "Este campo es requerido")]
    public string CiudadNombre { get; set; } = null!;

    [ForeignKey("ClienteId")] public int ClienteId { get; set; }
    public Clientes Cliente { get; set; } = null!;
}