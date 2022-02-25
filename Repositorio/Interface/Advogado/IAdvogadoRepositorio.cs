using Dominio.Advogado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Interface.Advogado
{
    public interface IAdvogadoRepositorio
    {
        List<AdvogadoDTO> ListarAdvogados();
        bool IncluirAdvogado(AdvogadoDTO advogado);
    }
}
