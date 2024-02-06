using Cadastro.Models;
using Cadastro.Repositorios;
using Cadastro.Repositorios.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Cadastro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContatoController : ControllerBase
    {
        private readonly IContatoRepositorio _contatoRepositorio;

        public ContatoController(IContatoRepositorio contatoRepositorio)
        {
            _contatoRepositorio = contatoRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<ContatoModel>>> BuscaLista()
        {
            List<ContatoModel> contatos = await _contatoRepositorio.BuscarTodosContatos();
            return Ok(contatos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ContatoModel>> BuscaId(int id)
        {
            ContatoModel contato = await _contatoRepositorio.BuscarId(id);
            return Ok(contato);
        }

        [HttpPost]
        public async Task<ActionResult<ContatoModel>> Cadastrar([FromBody] ContatoModel contatoModel)
        {
            ContatoModel contato = await _contatoRepositorio.Adicionar(contatoModel);
            return Ok(contato);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ContatoModel>> Atualizer([FromBody] ContatoModel contatoModel, int id)
        {
            contatoModel.Id = id;
            ContatoModel contato = await _contatoRepositorio.Atualizar(contatoModel, id);
            return Ok(contato);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ContatoModel>> Deletar(int id)
        {
            bool deletado = await _contatoRepositorio.Deletar(id);
            return Ok(deletado);
        }
    }
}
