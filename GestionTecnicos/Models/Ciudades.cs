using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionTecnicos.Models;

public class Ciudades
{
    [Key]
    public int CiudadId { get; set; }
    
    [Required(ErrorMessage = "Este campo es requerido")]
    public string CiudadNombre { get; set; } = null!;
    
    [ForeignKey("ClienteId")] 
    public int ClienteId { get; set; }
    public Clientes Cliente { get; set; } = null!;

}