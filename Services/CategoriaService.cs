using webapi.Models;

namespace webapi.Services
{
    public class CategoriaService : ICategoriaService
    {
        TareasContext context;

        //Constructor
        public CategoriaService(TareasContext dbContext)
        {
            this.context = dbContext;
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

            var categoriaEncontrada = context.Categorias.Find(id);

            if (categoriaEncontrada != null)
            {
                categoriaEncontrada.Nombre = categoria.Nombre;
                categoriaEncontrada.Descripcion = categoria.Descripcion;
                categoriaEncontrada.Peso = categoria.Peso;

                await context.SaveChangesAsync();
            }
        }

        public async Task Delete(Guid id)
        {

            var categoriaEncontrada = context.Categorias.Find(id);

            if (categoriaEncontrada != null)
            {

                context.Remove(categoriaEncontrada);

                await context.SaveChangesAsync();
            }
        }
    }

    public interface ICategoriaService
    {
        IEnumerable<Categoria> Get();
        Task Save(Categoria categoria);
        Task Update(Guid id, Categoria categoria);
        Task Delete(Guid id);
    }
}