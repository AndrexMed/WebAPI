using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using webapi.Services;
using webapi.Models;

namespace webapi.Controllers
{
    public class TareaController : ControllerBase
    {
        ITareasService tareasService;

        public TareaController(ITareasService tareasService){
            this.tareasService = tareasService;
        }

        [HttpGet]
        public IActionResult Get(){
            return Ok(tareasService.Get());
        }

        [HttpPost]
        public IActionResult Post([FromBody] Tarea tarea){
            tareasService.Save(tarea);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] Tarea tarea)
        {
            tareasService.Update(id, tarea);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Delete(Guid id)
        {
            tareasService.Delete(id);
            return Ok();
        }
    }
}