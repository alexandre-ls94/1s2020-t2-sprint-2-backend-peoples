using senai.Peoples.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.Peoples.WebApi.Interfaces
{
    interface ITipoUsuarioRepository
    {
        List<TipoUsuarioDomain> Listar();

        TipoUsuarioDomain BuscarPorId(int id);

        void Atualizar(TipoUsuarioDomain tipoUsuario);

        void Deletar(int id);
    }
}
