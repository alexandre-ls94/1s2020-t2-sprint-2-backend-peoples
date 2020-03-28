using senai.Peoples.WebApi.Domains;
using senai.Peoples.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai.Peoples.WebApi.Repositories
{
    public class FuncionarioRepository : IFuncionarioRepository
    {
        private string stringConexao = "Data Source=LAPTOP-PMKAL0V7\\SQLEXPRESS; initial catalog=M_Peoples; integrated security = true";

        public void Atualizar(FuncionarioDomain funcionario)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryUpdate = "UPDATE Funcionarios SET Nome = @Nome, Sobrenome = @Sobrenome, DataNascimento=@Data WHERE IdFuncionario = @ID";

                using (SqlCommand cmd = new SqlCommand(queryUpdate, con))
                {
                    cmd.Parameters.AddWithValue("@ID", funcionario.IdFuncionario);
                    cmd.Parameters.AddWithValue("@Nome", funcionario.Nome);
                    cmd.Parameters.AddWithValue("@Sobrenome", funcionario.Sobrenome);
                    cmd.Parameters.AddWithValue("@Data", funcionario.DataNascimento);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public FuncionarioDomain BuscarPorId(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryBuscarPorId = "SELECT IdFuncionario, Nome, Sobrenome, DataNascimento FROM Funcionarios WHERE IdFuncionario = @ID";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(queryBuscarPorId,con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);

                    rdr = cmd.ExecuteReader();

                    if(rdr.Read())
                    {
                        FuncionarioDomain funcionario = new FuncionarioDomain
                        {
                            IdFuncionario = Convert.ToInt32(rdr["IdFuncionario"]),
                            Nome = rdr["Nome"].ToString(),
                            Sobrenome = rdr["Sobrenome"].ToString(),
                            DataNascimento = Convert.ToDateTime(rdr["DataNascimento"])
                        };

                        return funcionario;
                    }

                    return null;
                }
            }
        }

        public FuncionarioDomain BuscarPorNome(string nome)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryBuscarPorNome = "SELECT IdFuncionario, Nome, Sobrenome, DataNascimento FROM Funcionarios WHERE Nome = @Nome";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(queryBuscarPorNome, con))
                {
                    cmd.Parameters.AddWithValue("@Nome", nome);

                    rdr = cmd.ExecuteReader();

                    if(rdr.Read())
                    {
                        FuncionarioDomain funcionario = new FuncionarioDomain
                        {
                            IdFuncionario = Convert.ToInt32(rdr["IdFuncionario"]),
                            Nome = rdr["Nome"].ToString(),
                            Sobrenome = rdr["Sobrenome"].ToString(),
                            DataNascimento = Convert.ToDateTime(rdr["DataNascimento"])
                        };

                        return funcionario;
                    }

                    return null;
                }
            }
        }

        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDelete = "DELETE Funcionarios WHERE IdFuncionario = @ID";

                SqlCommand cmd = new SqlCommand(queryDelete, con);

                cmd.Parameters.AddWithValue("@ID", id);

                con.Open();

                cmd.ExecuteNonQuery();
            }
        }

        public void Inserir(FuncionarioDomain funcionario)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO Funcionarios (Nome, Sobrenome, DataNascimento) VALUES (@Nome, @Sobrenome, @Data)";

                SqlCommand cmd = new SqlCommand(queryInsert, con);

                cmd.Parameters.AddWithValue("@Nome", funcionario.Nome);
                cmd.Parameters.AddWithValue("@Sobrenome", funcionario.Sobrenome);
                cmd.Parameters.AddWithValue("@Data", funcionario.DataNascimento);
                
                con.Open();
                
                cmd.ExecuteNonQuery();
                                
            }
        }

        public List<FuncionarioDomain> Listar()
        {
            List<FuncionarioDomain> funcionarios = new List<FuncionarioDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT IdFuncionario, Nome, Sobrenome, DataNascimento FROM Funcionarios";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        FuncionarioDomain funcionario = new FuncionarioDomain
                        {
                            IdFuncionario = Convert.ToInt32(rdr["IdFuncionario"]),
                            Nome = rdr["Nome"].ToString(),
                            Sobrenome = rdr["Sobrenome"].ToString(),
                            DataNascimento = Convert.ToDateTime(rdr["DataNascimento"])
                        };

                        funcionarios.Add(funcionario);
                    }
                }
            }

            return funcionarios;
        }

        public List<FuncionarioDomain> ListarEmOrdem(string ordem)
        {
            List<FuncionarioDomain> funcionarios = new List<FuncionarioDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = $"SELECT IdFuncionario, Nome, Sobrenome, DataNascimento FROM Funcionarios ORDER BY Nome {ordem};";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        FuncionarioDomain funcionario = new FuncionarioDomain
                        {
                            IdFuncionario = Convert.ToInt32(rdr["IdFuncionario"]),
                            Nome = rdr["Nome"].ToString(),
                            Sobrenome = rdr["Sobrenome"].ToString(),
                            DataNascimento = Convert.ToDateTime(rdr["DataNascimento"])
                        };

                        funcionarios.Add(funcionario);
                    }
                }
            }

            return funcionarios;
        }

        public List<FuncionarioDomain> ListarNomeCompleto()
        {
            List<FuncionarioDomain> funcionarios = new List<FuncionarioDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT IdFuncionario, CONCAT (Nome ,' ', Sobrenome) AS NomeCompleto, DataNascimento FROM Funcionarios";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        FuncionarioDomain funcionario = new FuncionarioDomain
                        {
                            IdFuncionario = Convert.ToInt32(rdr["IdFuncionario"]),
                            Nome = rdr[1].ToString(),
                            //Outra forma
                            //Nome = rdr["Nome"].ToString() + ' ' + rdr["Sobrenome"].ToString()
                            DataNascimento = Convert.ToDateTime(rdr["DataNascimento"])
                        };

                        funcionarios.Add(funcionario);
                    }
                }
            }

            return funcionarios;
        }
    }
}
