using Domain.Entities;
using Infra.Data.Mapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Data.Context
{
    public class MySqlContext : DbContext
    {
        public MySqlContext(DbContextOptions<MySqlContext> options) : base(options)
        {}

        public DbSet<Person> Person { get; set; }

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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Person> (new PersonMap().Configure);
        }
    }
}
