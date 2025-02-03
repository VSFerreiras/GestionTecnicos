using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionTecnicos.Models;

public class Clientes{

    [Key]
    public int ClienteId { get; set; }
    
    public int TecnicoId { get; set; }
    
    public int CiudadId { get; set; }
    
    public DateTime FechaIngreso { get; set; } = DateTime.Now;

    [Required(ErrorMessage = "Este campo es requerido")]
    public string Nombres { get; set; } = null!;

    [Required(ErrorMessage = "Este campo es requerido")]
    public string Direccion { get; set; } = null!;
    
    [Required(ErrorMessage = "Este campo es requerido")]
    [StringLength(11,MinimumLength = 9)]
    public string Rnc { get; set; } = null!;
    
    [Range(1, double.MaxValue, ErrorMessage = "El limite tiene que ser mayor o igual a 1")]
    public float LimiteCredito { get; set; }

    [ForeignKey("TecnicoId")] 
    public Tecnicos Tecnico { get; set; } = null!;
    
    [ForeignKey("CiudadId")]
    public Ciudades Ciudad { get; set; } = null!;

}