using System.ComponentModel.DataAnnotations;

namespace GestionTecnicos.Models;

public class Sistemas
{
    [Key]
    public int SistemaId { get; set; }
    [Required(ErrorMessage = "Este campo es requerido")]
    [StringLength(250)]
    public string Descripcion { get; set; }
    [Required(ErrorMessage = "Este campo es requerido")]
    [Range(1,100)]
    public double Complejidad { get; set; }
    
}