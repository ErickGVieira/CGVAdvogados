using Dominio.Advogado;
using Repositorio.Interface.Advogado;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Implementacao.Advogado
{
    public class AdvogadoRepositorio : IAdvogadoRepositorio
    {
        private SqlConnection cnn = new SqlConnection(ConfigurationManager.AppSettings["Advogado"]);

        private SqlDataReader reader = null;

        // Método GET 
        // Para listar os advogados cadastrados que não foram excluidos
        public List<AdvogadoDTO> ListarAdvogados()
        {
            List<AdvogadoDTO> advogados = new List<AdvogadoDTO>();

            try
            {
                cnn.Open();

                SqlCommand cmd = new SqlCommand(
                "select * from Advogado where ativo = 1", cnn);

                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    AdvogadoDTO advogado = new AdvogadoDTO();
                    advogado.id = int.Parse(reader["id"].ToString()) != 0 ? int.Parse(reader["id"].ToString()) : 0;
                    advogado.nome = reader["nome"].ToString() != null ? reader["nome"].ToString() : "";
                    advogado.senioridade = reader["senioridade"].ToString() != null ? reader["senioridade"].ToString() : "";
                    advogado.endereco = reader["endereco"].ToString() != null ? reader["endereco"].ToString() : "";

                    advogados.Add(advogado);
                }

                cnn.Close();
                return advogados;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }

                if (cnn != null)
                {
                    cnn.Close();
                }
            }
        }

        // Método POST
        // Para cadastrar um novo advogado no banco
        public bool IncluirAdvogado(AdvogadoDTO advogado)
        {
            try
            {
                cnn.Open();

                SqlCommand cmd = new SqlCommand(
                $"insert into Advogado values ('{advogado.nome}', '{ advogado.senioridade} ', '{ advogado.endereco} ', 1);", cnn);

                cmd.ExecuteNonQuery();

                cnn.Close();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }

                if (cnn != null)
                {
                    cnn.Close();
                }
            }
        }
    }
}
