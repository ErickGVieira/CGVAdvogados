using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Advogado
{
    [Serializable]
    public class AdvogadoDTO
    {
        public int id { get; set; }

        public string nome { get; set; }
        public string senioridade { get; set; }
        public string endereco { get; set; }
    }
}
