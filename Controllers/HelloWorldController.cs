using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using webapi.Services;

namespace webapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HelloWorldController : ControllerBase
    {
        IHelloWorldService helloWorldService;
        TareasContext tareasContext;

        //Constructor
        public HelloWorldController(IHelloWorldService helloWorld, TareasContext tareasContext)
        {
            helloWorldService = helloWorld;
            this.tareasContext = tareasContext;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(helloWorldService.GetHelloWorld());
        }

        [HttpGet]
        [Route("createdb")]
        public IActionResult CreateDatabase()
        {
            tareasContext.Database.EnsureCreated();
            return Ok();
        }
    }
}