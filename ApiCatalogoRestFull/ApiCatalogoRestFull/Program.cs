using ApiCatalogoRestFull.Context;
using ApiCatalogoRestFull.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<CatalogoContext>(opt => opt.UseSqlServer("Data Source=DESKTOP-AKJOSMO;Initial Catalog=CatalogoDeRoupasDB;Integrated Security=true;"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/categorias", async (CatalogoContext context) =>
{
    var categoria = await context.Categorias.AsNoTracking().ToListAsync();

    return Results.Ok(categoria);
});

app.MapGet("/categorias/{id:int}", async (int id, CatalogoContext context) =>
{
    var categoria = await context.Categorias.FindAsync(id);

    if (categoria != null)
    {
        return Results.Ok(categoria);
    }

    return Results.NotFound();
});

app.MapPost("/categorias", async (Categoria categoria, CatalogoContext context) =>
{
    context.Add(categoria);
    await context.SaveChangesAsync();

    return Results.Created($"/categorias/{categoria.CategoriaId}", categoria);
});

app.MapPut("/categorias/{id:int}", async (int id, Categoria novaCategoria, CatalogoContext context) =>
{
    if (id != novaCategoria.CategoriaId)
    {
        Results.BadRequest();
    }

    var categoria = await context.Categorias.FindAsync(id);

    if (categoria != null)
    {
        categoria.Nome = novaCategoria.Nome;
        categoria.Descricao = novaCategoria.Descricao;

        await context.SaveChangesAsync();

        return Results.Ok(categoria);
    }

    return Results.NotFound();
});

app.MapDelete("/categorias/{id:int}", async (int id, CatalogoContext context) =>
{
    var categoria = await context.Categorias.FindAsync(id);

    if (categoria != null)
    {
        context.Remove(categoria);
        await context.SaveChangesAsync();

        return Results.NoContent();
    }

    return Results.NotFound();

});

app.MapGet("/produtos", async (CatalogoContext context) =>
{
    return await context.Produtos.AsNoTracking().ToListAsync();
});
app.MapGet("/produtos/{id:int}", async (int id, CatalogoContext context) =>
{
    var produto = await context.Produtos.FindAsync(id);
    if (produto != null)
    {
        return Results.Ok(produto);
    }

    return Results.NotFound();
});
app.MapPost("/produtos", async (Produto produto, CatalogoContext context) =>
{
    context.Produtos.Add(produto);
    await context.SaveChangesAsync();

    return Results.Created($"/produtos/{produto.ProdutoId}", produto);
});

app.MapPut("/produtos", async (int id, Produto novoProduto, CatalogoContext context) =>
{
    if (id != novoProduto.ProdutoId)
    {
        return Results.BadRequest();
    }

    var produto = await context.Produtos.FindAsync(id);

    if (produto != null)
    {
        produto.Nome = novoProduto.Nome;
        produto.Imagem = novoProduto.Imagem;
        produto.Descricao = novoProduto.Descricao;
        produto.Preco = novoProduto.Preco;
        produto.DataCompra = novoProduto.DataCompra;
        produto.Estoque = novoProduto.Estoque;
        produto.CategoriaId = novoProduto.CategoriaId;

        await context.SaveChangesAsync();
        return Results.Ok(produto);
    }

    return Results.NotFound();
});
app.MapDelete("/produtos/{id:int}", async (int id, CatalogoContext context) =>
{
    var produto = await context.Produtos.FindAsync(id);
    if (produto != null)
    {
        context.Remove(produto);
        await context.SaveChangesAsync();

      return  Results.NoContent();
    }

    return Results.NotFound();
});

app.Run();

