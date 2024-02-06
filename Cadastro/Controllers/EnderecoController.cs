using Cadastro.Models;
using Cadastro.Repositorios;
using Cadastro.Repositorios.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Cadastro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnderecoController : ControllerBase
    {
        private readonly IEnderecoRepositorio _enderecoRepositorio;

        public EnderecoController(IEnderecoRepositorio enderecoRepositorio)
        {
            _enderecoRepositorio = enderecoRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<EnderecoModel>>> BuscaLista()
        {
            List<EnderecoModel> enderecos = await _enderecoRepositorio.BuscarTodosEnderecos();
            return Ok(enderecos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EnderecoModel>> BuscaId(int id)
        {
            EnderecoModel endereco = await _enderecoRepositorio.BuscarId(id);
            return Ok(endereco);
        }

        [HttpPost]
        public async Task<ActionResult<EnderecoModel>> Cadastrar([FromBody] EnderecoModel enderecoModel)
        {
            EnderecoModel endereco = await _enderecoRepositorio.Adicionar(enderecoModel);
            return Ok(endereco);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<EnderecoModel>> Atualizer([FromBody] EnderecoModel enderecoModel, int id)
        {
            enderecoModel.Id = id;
            EnderecoModel endereco = await _enderecoRepositorio.Atualizar(enderecoModel, id);
            return Ok(endereco);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<EnderecoModel>> Deletar(int id)
        {
            bool deletado = await _enderecoRepositorio.Deletar(id);
            return Ok(deletado);
        }
    }
}
