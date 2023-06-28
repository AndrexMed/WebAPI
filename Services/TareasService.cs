using webapi.Models;

namespace webapi.Services
{
    public class TareasService : ITareasService
    {
        TareasContext context;

        //Constructor
        public TareasService(TareasContext dbContext)
        {
            this.context = dbContext;
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

            var tareaEncontrada = context.Tareas.Find(id);

            if (tareaEncontrada != null)
            {
                tareaEncontrada.Titulo = tarea.Titulo;
                tareaEncontrada.Descripcion = tarea.Descripcion;
                tareaEncontrada.PrioridadTarea = tarea.PrioridadTarea;
                tareaEncontrada.Resumen = tarea.Resumen;

                await context.SaveChangesAsync();
            }
        }

        public async Task Delete(Guid id)
        {

            var tareaEncontrada = context.Tareas.Find(id);

            if (tareaEncontrada != null)
            {

                context.Remove(tareaEncontrada);

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

}