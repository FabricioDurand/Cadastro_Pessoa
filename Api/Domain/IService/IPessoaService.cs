using CadastroPessoa.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroPessoa.Interface
{
    public interface IPessoaService
    {
        Task<List<Pessoa>> GetPessoas();
        Pessoa GetPessoaById(int id);
        Pessoa AddPessoa(Pessoa pessoa);
        Pessoa UpdatePessoa(Pessoa pessoa);
        bool DeletePessoa(int id);
    }
}
