using Dominio.Advogado;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CgvAdvogados.ViewModels
{
    [Serializable]
    public class AdvogadoViewModel
    {
        
        public List<AdvogadoDTO> advogados { get; set; }


        //Variaveis utilizadas para o novo Advogado.
        [Required(ErrorMessage = "O nome deve ser informada.")]
        public string nome { get; set; }

        [Required(ErrorMessage = "A senioridade deve ser informada.")]
        public string senioridade { get; set; }

        [Required(ErrorMessage = "O endereço deve ser informada.")]
        public string endereco { get; set; }
    }
}