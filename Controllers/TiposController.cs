using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Final_ApiAmano.Data;
using Final_ApiAmano.Models;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Final_ApiAmano.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TiposController : ControllerBase
    {
        DataTipo cnn = new DataTipo();

        // GET: api/<TiposController>
        [HttpGet]
        public IEnumerable<Tipo> Get()
        {
            List<Tipo> tipos = new List<Tipo>();
            cnn.Get(out tipos);
            return tipos;
        }

        // GET api/<TiposController>/5
        [HttpGet("{id}")]
        public Tipo Get(int id)
        {
            Tipo tipo = new Tipo();
            cnn.Get(out tipo, id);
            return tipo;
        }

        // POST api/<TiposController>
        [HttpPost]
        public ActionResult Post(Tipo tipo)
        {
            try
            {
                cnn.Post(out tipo, tipo);
                return Ok(tipo);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
                
            }
        }

        // PUT api/<TiposController>/5
        [HttpPut("{id}")]
        public ActionResult Put(Tipo tipo , int id)
        {
            try
            {
                cnn.Put(out tipo, id, tipo);
                return Ok(tipo);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        // DELETE api/<TiposController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            cnn.Delete(id);
        }
    }
}
