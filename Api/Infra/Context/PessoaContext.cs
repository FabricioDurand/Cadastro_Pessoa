using CadastroPessoa.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace CadastroPessoa.Repository
{
    public partial class PessoaContext : DbContext
    {
        public PessoaContext(DbContextOptions<PessoaContext> options) : base(options)
        {}

        public DbSet<Pessoa> Pessoas { get; set; }

        public IDbContextTransaction Transaction { get; private set; }

        public IDbContextTransaction BeginTransaction()
        {
            if (Transaction == null)
                Transaction = this.Database.BeginTransaction();

            return Transaction;
        }

        public void SendChanges()
        {
            Save();
            Commit();
        }

        internal void RollBack()
        {
            if (Transaction != null)
            {
                Transaction.Rollback();
            }
        }

        private void Save()
        {
            try
            {
                ChangeTracker.DetectChanges();
                SaveChanges();
            }
            catch
            {
                RollBack();
                throw;
            }
        }

        private void Commit()
        {
            if (Transaction != null)
            {
                Transaction.Commit();
                Transaction.Dispose();
                Transaction = null;
            }
        }

        protected override void OnModelCreating(Microsoft.EntityFrameworkCore.ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Pessoa>().HasKey(x => x.PessoaId);
        }
    }
}
