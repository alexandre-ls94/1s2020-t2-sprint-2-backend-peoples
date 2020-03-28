using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.Peoples.WebApi.Domains;
using senai.Peoples.WebApi.Interfaces;
using senai.Peoples.WebApi.Repositories;

namespace senai.Peoples.WebApi.Controllers
{
    [Produces("application/json")]

    [Route("api/[controller]")]

    [ApiController]
    public class FuncionariosController : ControllerBase
    {
        private IFuncionarioRepository _funcionarioRepository { get; set; }

        public FuncionariosController()
        {
            _funcionarioRepository = new FuncionarioRepository();
        }

        [HttpGet]
        public IEnumerable<FuncionarioDomain> Get()
        {
            return _funcionarioRepository.Listar();
        }

        [HttpGet("nomescompletos")]
        public IEnumerable<FuncionarioDomain> GetFullName()
        {
            return _funcionarioRepository.ListarNomeCompleto();
        }
        
        [HttpGet("ordenacao/{ordem}")]
        public IActionResult GetOrder(string ordem)
        {
            if (ordem != "ASC" && ordem != "DESC")
            {
                return BadRequest("Ordenação inválida");
            }

            return Ok(_funcionarioRepository.ListarEmOrdem(ordem));
        }

        [HttpGet("buscarId/{id}")]
        public IActionResult BuscarPorId(int id)
        {
            FuncionarioDomain funcionarioBuscado = _funcionarioRepository.BuscarPorId(id);

            if (funcionarioBuscado == null)
            {
                return NotFound("Nenhum funcionário encontrado");
            }

            return Ok(funcionarioBuscado);
        }

        [HttpGet("buscarNome/{nome}")]
        public IActionResult BuscarPorNome(string nome)
        {
            FuncionarioDomain funcionarioBuscado = _funcionarioRepository.BuscarPorNome(nome);

            if(funcionarioBuscado == null)
            {
                return NotFound("Funcionário não encontrado");
            }

            return Ok(funcionarioBuscado);
        }

        [HttpPost]
        public IActionResult Post(FuncionarioDomain funcionario)
        {
            _funcionarioRepository.Inserir(funcionario);

            return StatusCode(201);            
        }

        [HttpPut]
        public IActionResult Put(FuncionarioDomain funcionarioAtualizado)
        {
            FuncionarioDomain funcionarioBuscado = _funcionarioRepository.BuscarPorId(funcionarioAtualizado.IdFuncionario);

            if (funcionarioBuscado != null)
            {
                try
                {
                    _funcionarioRepository.Atualizar(funcionarioAtualizado);

                    return NoContent();
                }
                catch (Exception erro)
                {
                    return BadRequest(erro);
                }
            }

            return NotFound("Funcionário não encontrado");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            FuncionarioDomain funcionarioBuscado = _funcionarioRepository.BuscarPorId(id);

            if (funcionarioBuscado != null)
            {
                try
                {
                    _funcionarioRepository.Deletar(id);

                    return Ok("Funcionário deletado");
                }
                catch (Exception erro)
                {
                    return BadRequest(erro);
                }
            }

            return NotFound("Filme não encontrado");
        }
    }
}