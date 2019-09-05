using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PartnerGroupAPI.Models
{
    public class Patrimonios
    {
        public Guid PatrimonioID { get; set; }

        [Required(ErrorMessage = "O preenchimento do nome é obrigatório.")]
        public string Nome { get; set; }
        public Guid MarcaID { get; set; }
        public string Descricao { get; set; }
        public int NTombo { get; set; }
    }
}
