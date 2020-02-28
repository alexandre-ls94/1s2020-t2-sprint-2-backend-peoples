using senai.Peoples.WebApi.Domains;
using senai.Peoples.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai.Peoples.WebApi.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        private string stringConexao = "Data Source=DEV22\\SQLEXPRESS; initial catalog=M_Peoples; user Id=sa; pwd=sa@132";

        public void Atualizar(TipoUsuarioDomain tipoUsuario)
        {
            throw new NotImplementedException();
        }

        public TipoUsuarioDomain BuscarPorId(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryBuscarId = "SELECT IdTipo, Titulo FROM TipoUsuario WHERE IdTipo = @ID";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryBuscarId, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);

                    SqlDataReader rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        TipoUsuarioDomain usuario = new TipoUsuarioDomain
                        {
                            IdTipo = Convert.ToInt32(rdr["IdTipo"]),
                            Titulo = rdr["Titulo"].ToString()
                        };

                        return usuario;
                    }

                    return null;

                }
            }
        }

        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDelete = "DELETE FROM TipoUsuario WHERE IdTipo = @ID";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<TipoUsuarioDomain> Listar()
        {
            List<TipoUsuarioDomain> tipos = new List<TipoUsuarioDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT IdTipo, Titulo FROM TipoUsuario";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.HasRows)
                    {
                        TipoUsuarioDomain usuario = new TipoUsuarioDomain
                        {
                            IdTipo = Convert.ToInt32(rdr["IdTipo"]),
                            Titulo = rdr["Titulo"].ToString()
                        };

                        tipos.Add(usuario);
                    }
                }
            }

            return tipos;
        }
    }
}
