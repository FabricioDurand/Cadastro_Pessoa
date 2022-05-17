using CadastroPessoa.Interface;
using System.Collections.Generic;
using CadastroPessoa.Entity;
using CadastroPessoa.IRepository;
using System.Threading.Tasks;

namespace CadastroPessoa.Service
{
    public class PessoaService : IPessoaService
    {
        private readonly IPessoaRepository _pessoaRepository;

        public PessoaService(IPessoaRepository pessoaRepository)
        {
            _pessoaRepository = pessoaRepository;
        }

        public async Task<List<Pessoa>> GetPessoas()
        {
            var pessoas = await _pessoaRepository.GetPessoas();
            return pessoas;
        }

        public Pessoa GetPessoaById(int id)
        {
            return _pessoaRepository.GetPessoaById(id);
        }

        public Pessoa AddPessoa(Pessoa pessoa)
        {
            return _pessoaRepository.AddPessoa(pessoa);
        }

        public Pessoa UpdatePessoa(Pessoa pessoa)
        {
            return _pessoaRepository.UpdatePessoa(pessoa);
        }

        public bool DeletePessoa(int id)
        {
            return _pessoaRepository.DeletePessoa(id);
        }
    }
}
