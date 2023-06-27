using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapi.Models;

namespace webapi.Services
{
    public class TareasService : ITareasService
    {
        TareasContext context;

        //Constructor
        public TareasService(TareasContext dbContext){
            this.context = dbContext;
        }

        public IEnumerable<Tarea> GetTareas()
        {
            return context.Tareas;
        }
    }

    public interface ITareasService{
        IEnumerable<Tarea> GetTareas();
    }
}