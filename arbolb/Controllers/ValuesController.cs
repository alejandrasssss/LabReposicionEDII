using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ETD2LAB1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        static ArbolB<Gaseosa> NuevoArbol = new ArbolB<Gaseosa>(3);


        // GET api/values
        [HttpGet]
        public ArbolB<Gaseosa> Get()//public ActionResult<IEnumerable<string>> Get()
        {
            return NuevoArbol;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Gaseosa> Get(Gaseosa buscar)
        {
            return NuevoArbol.BuscarEnArbol(buscar);
        }

        // POST api/values
        [HttpPost]
        public void Post(Gaseosa nueva)
        {
            NuevoArbol.InsertarEnHoja(nueva);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}