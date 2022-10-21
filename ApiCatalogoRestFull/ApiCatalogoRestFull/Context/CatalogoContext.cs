using ApiCatalogoRestFull.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiCatalogoRestFull.Context
{
    public class CatalogoContext : DbContext
    {
        public CatalogoContext(DbContextOptions<CatalogoContext> options) : base(options)
        {
        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }

    }
}
