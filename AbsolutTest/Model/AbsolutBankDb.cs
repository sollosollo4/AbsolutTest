namespace AbsolutTest.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class AbsolutBankDb : DbContext
    {
        public AbsolutBankDb() : base("name=AbsolutBankDb")
        {
        }

        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Document> Document { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .HasMany(e => e.Table)
                .WithRequired(e => e.Customer)
                .WillCascadeOnDelete(false);
        }
    }
}
