using ApiCatalogoRestFull.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiCatalogoRestFull.Context
{
    public class CatalogoContext : DbContext
    {
        public CatalogoContext(DbContextOptions<CatalogoContext> options) : base(options)
        {
        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Categoria>().HasKey(c => c.CategoriaId);

            mb.Entity<Categoria>().Property(c => c.Nome).HasMaxLength(100).IsRequired();

            mb.Entity<Categoria>().Property(c => c.Descricao).HasMaxLength(200).IsRequired();

            //--------------------------------------------------------------------//

            mb.Entity<Produto>().HasKey(p => p.ProdutoId);

            mb.Entity<Produto>().Property(p => p.Nome).HasMaxLength(100).IsRequired();

            mb.Entity<Produto>().Property(p => p.Descricao).HasMaxLength(150).IsRequired();

            mb.Entity<Produto>().Property(p => p.Imagem).HasMaxLength(200);

            mb.Entity<Produto>().Property(p => p.Preco).HasPrecision(10, 2);

            //--------------------------------------------------------------------//

            mb.Entity<Produto>().HasOne<Categoria>(c => c.Categoria).WithMany(p => p.Produtos).HasForeignKey(c => c.CategoriaId);
        }
    }
}
