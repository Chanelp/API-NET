using WebApiNet.Models;
namespace WebApiNet.Services;

public class TareasService : ITareasService
{
    TareasContext context;
    public TareasService(TareasContext dbcontext)
    {
        context = dbcontext;
    }

    public IEnumerable<Tarea> Get()
    {
        return context.Tareas;
    }

    public async Task Save(Tarea tarea)
    {
        context.Add(tarea);
        await context.SaveChangesAsync();
    }

    public async Task Update(Guid id, Tarea tarea)
    {
        var tareaActual = context.Tareas.Find(id);

        if(tareaActual != null)
        {
            tareaActual.Autor = tarea.Autor;
            tareaActual.Categoria = tarea.Categoria;
            tareaActual.Descripcion = tarea.Descripcion;
            tareaActual.PrioridadTarea = tarea.PrioridadTarea;
            tareaActual.Titulo = tarea.Titulo;
        }

        await context.SaveChangesAsync();
    }

    public async Task Delete(Guid id)
    {
        var tareaDelete = context.Tareas.Find(id);

        if(tareaDelete != null)
        {
            context.Remove(id);
            await context.SaveChangesAsync();
        }
    }
}

public interface ITareasService
{
    IEnumerable<Tarea> Get();
    Task Save(Tarea tarea);
    Task Update(Guid id, Tarea tarea);
    Task Delete(Guid id);
}