using Cadastro.Models;
using Cadastro.Repositorios.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Cadastro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaFisicaController : ControllerBase
    {
        private readonly IPessoaFisicaRepositorio _pessoaFisicaRepositorio;

        public PessoaFisicaController(IPessoaFisicaRepositorio pessoaFisicaRepositorio)
        {
            _pessoaFisicaRepositorio = pessoaFisicaRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<PessoaFisicaModel>>> BuscaLista()
        {
            List<PessoaFisicaModel> pessoasfisicas = await _pessoaFisicaRepositorio.BuscarTodasPessoas();
            return Ok(pessoasfisicas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PessoaFisicaModel>> BuscaId(int id)
        {
            PessoaFisicaModel pessoafisica = await _pessoaFisicaRepositorio.BuscarId(id);
            return Ok(pessoafisica);
        }

        [HttpPost]
        public async Task<ActionResult<PessoaFisicaModel>> Cadastrar([FromBody] PessoaFisicaModel pessoaFisicaModel)
        {
            PessoaFisicaModel pessoa = await _pessoaFisicaRepositorio.Adicionar(pessoaFisicaModel);
            return Ok(pessoa);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<PessoaFisicaModel>> Atualizer([FromBody] PessoaFisicaModel pessoaFisicaModel, int id)
        {
            pessoaFisicaModel.Id = id;
            PessoaFisicaModel pessoa = await _pessoaFisicaRepositorio.Atualizar(pessoaFisicaModel, id);
            return Ok(pessoa);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<PessoaFisicaModel>> Deletar(int id)
        {
            bool deletado = await _pessoaFisicaRepositorio.Deletar(id);
            return Ok(deletado);
        }

    }
}
