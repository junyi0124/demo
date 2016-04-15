using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdeToFood.Services
{
    public class Greeter : IGreeter
    {
        private string greeting;

        public Greeter(IConfiguration config)
        {
            greeting = config["greeting"];
                //"A configurable greeting to you";
        }
        public string Greeting(string template)
        {
            return string.Format(template, greeting);
        }
    }
}
