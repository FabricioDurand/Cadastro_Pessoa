using CadastroPessoa.Entity;
using CadastroPessoa.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroPessoa.Repository
{
    public class PessoaRepository : IPessoaRepository
    {
        private readonly PessoaContext _context;

        public PessoaRepository(PessoaContext context) : base()
        {
            _context = context;
        }

        public async Task<List<Pessoa>> GetPessoas()
        {
            return await _context.Set<Pessoa>().ToListAsync();
        }

        public Pessoa GetPessoaById(int id)
        {
            return _context.Find<Pessoa>(id);
        }

        public Pessoa AddPessoa(Pessoa pessoa)
        {
            _context.BeginTransaction();
            _context.Set<Pessoa>().Add(pessoa);
            _context.SendChanges();
            return pessoa;
        }

        public Pessoa UpdatePessoa(Pessoa pessoa)
        {
            _context.BeginTransaction();
            _context.Set<Pessoa>().Update(pessoa);
            _context.Entry(pessoa).State = EntityState.Modified;
            _context.SendChanges();

            return pessoa;
        }

        public bool DeletePessoa(int id)
        {
            var entity = GetPessoaById(id);
            if (entity != null)
            {
                _context.BeginTransaction();
                _context.Set<Pessoa>().Remove(entity);
                _context.SendChanges();

                return true;
            }

            return false;
        }

        public PessoaContext CreateDbContext()
        {
            throw new NotImplementedException();
        }
    }
}
