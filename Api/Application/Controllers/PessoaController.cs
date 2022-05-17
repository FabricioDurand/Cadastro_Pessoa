using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CadastroPessoa.Entity;
using CadastroPessoa.Interface;
using CadastroPessoa.Service;

namespace CadastroPessoa.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        private readonly IPessoaService _pessoaService;

        public PessoaController(IPessoaService pessoaService)
        {
            _pessoaService = pessoaService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Pessoa>>> GetPessoas()
        {
            return await _pessoaService.GetPessoas();
        }

        [HttpGet("{id}")]
        public ActionResult<Pessoa> GetPessoa(int id)
        {
            return _pessoaService.GetPessoaById(id);
        }

        [HttpPost]
        public ActionResult<Pessoa> AddPessoa(Pessoa pessoa)
        {
            return _pessoaService.AddPessoa(pessoa);
        }

        [HttpPut]
        public ActionResult<Pessoa> UpdatePessoa([FromBody] Pessoa pessoa)
        {
            return _pessoaService.UpdatePessoa(pessoa);
        }

        [HttpDelete]
        public ActionResult<string> DeletePessoa(int id)
        {
            var deletou = _pessoaService.DeletePessoa(id);
            if (deletou)
            {
                return "Pessoa deletada!";
            }

            return "Falha ao deletar esta pessoa.";
        }
    }
}
