using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webapi.Services
{
    public class HelloWorldServices : IHelloWorldService
    {
        public string GetHelloWorld(){
            return "Hola Mundo!";
        }
    }

    public interface IHelloWorldService{
        string GetHelloWorld();
    }
}