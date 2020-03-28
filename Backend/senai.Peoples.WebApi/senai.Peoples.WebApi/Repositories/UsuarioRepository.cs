using senai.Peoples.WebApi.Domains;
using senai.Peoples.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai.Peoples.WebApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private string stringConexao = "Data Source=LAPTOP-PMKAL0V7\\SQLEXPRESS; initial catalog=M_Peoples; integrated security = true";

        /*public UsuarioDomain BuscarPorEmailSenha(string email, string senha)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelect = "SELECT IdUsuario, Nome, Email, Senha, IdTipo FROM Usuarios WHERE Email = @Email AND Senha = @Senha";

                using (SqlCommand cmd = new SqlCommand(querySelect, con))
                {
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Senha", senha);

                    con.Open();

                    SqlDataReader rdr = cmd.ExecuteReader();

                    if (rdr.HasRows)
                    {
                        UsuarioDomain usuario = new UsuarioDomain();

                        while (rdr.Read())
                        {
                            usuario.IdUsuario = Convert.ToInt32(rdr["IdUsuario"]);
                            usuario.Nome = rdr["Nome"].ToString();
                            usuario.Email = rdr["Email"].ToString();
                            usuario.Senha = rdr["Senha"].ToString();
                            usuario.TipoUsuario = new TipoUsuarioDomain
                            {
                                IdTipo = Convert.ToInt32(rdr["IdTipo"]),
                                Titulo = rdr["Titulo"].ToString()
                            };
                        }

                        return usuario;
                    }
                }

                return null;
            }
        }*/
    }
}
