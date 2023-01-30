using WebApiNet.Models;
namespace WebApiNet.Services;

public class CategoriaService : ICategoriaService
{
    TareasContext context;

    public CategoriaService(TareasContext dbcontext)
    {
        context = dbcontext;
    }

    public IEnumerable<Categoria> Get()
    {
        return context.Categorias;
    }

    public async Task Save(Categoria categoria)
    {
        context.Add(categoria);
        await context.SaveChangesAsync();
    }

    public async Task Update(Guid id, Categoria categoria)
    {
        var categoriaActual = context.Categorias.Find(id);

        if (categoriaActual == null)
        {
            throw new Exception("NOT FOUND");
        }

        categoriaActual.Nombre = categoria.Nombre;
        categoriaActual.Descripcion = categoria.Descripcion;
        categoriaActual.Peso = categoria.Peso;

        await context.SaveChangesAsync();
    }

    public async Task Delete(Guid id)
    {
        var categoriaDelete = context.Categorias.Find(id);

        if (categoriaDelete == null)
        {
            throw new Exception("NOT FOUND");
        }

        context.Remove(categoriaDelete);
        await context.SaveChangesAsync();
    }
}

public interface ICategoriaService
{
    IEnumerable<Categoria> Get();
    Task Save(Categoria categoria);
    Task Update(Guid id, Categoria categoria);
    Task Delete(Guid id);
}

