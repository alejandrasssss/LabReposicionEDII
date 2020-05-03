using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace RSA.Controllers
{

    public class ValuesController : ControllerBase
    {
        RSA rsa = new RSA();

        // POST api/values
        [HttpPost]
        [Route("RSA")]
               
       public ActionResult Insertar(string n, string p, char caracter)
        {
            rsa.encriptar(caracter);
            rsa.clavePublica(Convert.ToInt32 (n), Convert.ToInt32 (p));
            rsa.clavePrivada(Convert.ToInt32(n), Convert.ToInt32(p));
            return Ok();
        }

        public ActionResult cambiar(string n, string p, char caracter)
        {
            rsa.desencriptar(caracter);
            rsa.clavePublica(Convert.ToInt32(n), Convert.ToInt32(p));
            rsa.clavePrivada(Convert.ToInt32(n), Convert.ToInt32(p));
            return Ok();
        }
    }
}
