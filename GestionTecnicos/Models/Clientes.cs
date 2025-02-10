using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionTecnicos.Models;

public class Clientes
{
    [Key] public int ClienteId { get; set; }

    public int TecnicoId { get; set; }

    public int CiudadId { get; set; }

    public DateTime FechaIngreso { get; set; } = DateTime.Now;

    [Required(ErrorMessage = "Este campo es requerido")]
    [StringLength(maximumLength: 50, ErrorMessage = "El nombre no debe exceder los 50 caracteres")]
    public string Nombres { get; set; } = null!;

    [RegularExpression(@"^[a-zA-ZñÑáéíóúÁÉÍÓÚüÜ\s]+$", ErrorMessage = "El nombre solo debe contener letras y espacios")]
    [Required(ErrorMessage = "Este campo es requerido")]
    [StringLength(maximumLength: 100, ErrorMessage = "La dirección no debe exceder los 100 caracteres")]
    public string Direccion { get; set; } = null!;

    [Required(ErrorMessage = "Este campo es requerido")]
    [StringLength(9, ErrorMessage = "El RNC debe tener 9 caracteres")]
    [RegularExpression(@"^\d{9}$", ErrorMessage = "El RNC debe ser un número de 9 dígitos")]
    public string Rnc { get; set; } = null!;

    [Range(1, double.MaxValue, ErrorMessage = "El limite tiene que ser mayor que cero")]
    public float LimiteCredito { get; set; }

    [ForeignKey("TecnicoId")] public Tecnicos Tecnico { get; set; } = null!;

    [ForeignKey("CiudadId")] public Ciudades Ciudad { get; set; } = null!;
}