using System.ComponentModel.DataAnnotations;

namespace GestionTecnicos.Models;

public class Tecnicos{

    [Key]
    
    [Required(ErrorMessage = "Este campo es requerido")]
     public int TecnicoId { get; set; } 
    
    [Required(ErrorMessage = "Este campo es requerido")]
     public string Nombres { get; set;}
   
    [Required(ErrorMessage = "Este campo es requerido")]
     public float SueldoHora { get; set; }

}