using System.ComponentModel.DataAnnotations;

namespace GestionTecnicos.Models;

public class Sistemas
{
    [Key] public int SistemaId { get; set; }

    [Required(ErrorMessage = "Este campo es requerido")]
    [StringLength(250, ErrorMessage = "La descripción no puede exceder los 250 caracteres")]
    public string Descripcion { get; set; }

    [Required(ErrorMessage = "Este campo es requerido")]
    [Range(1, 100, ErrorMessage = "La complejidad tiene que estar entre 1 y 100")]
    public double Complejidad { get; set; }
}