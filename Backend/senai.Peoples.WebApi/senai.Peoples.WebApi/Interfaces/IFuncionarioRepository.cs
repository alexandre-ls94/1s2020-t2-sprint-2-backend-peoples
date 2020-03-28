using senai.Peoples.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.Peoples.WebApi.Interfaces
{
    interface IFuncionarioRepository
    {
        List<FuncionarioDomain> Listar();

        FuncionarioDomain BuscarPorId(int id);

        void Inserir(FuncionarioDomain funcionario);

        void Atualizar(FuncionarioDomain funcionario);

        void Deletar(int id);

        FuncionarioDomain BuscarPorNome(string nome);

        List<FuncionarioDomain> ListarNomeCompleto();

        List<FuncionarioDomain> ListarEmOrdem(string ordem);
    }
}
