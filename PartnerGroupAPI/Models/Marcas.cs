using System;
using System.ComponentModel.DataAnnotations;


namespace PartnerGroupAPI.Models
{
    public class Marcas
    {
        public Guid MarcaID { get; set; }
        
        [Required(ErrorMessage = "O nome da marca é obrigatório.")]        
        public string Nome { get; set; }
    }
}
