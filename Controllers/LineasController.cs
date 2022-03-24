using Final_ApiAmano.Data;
using Final_ApiAmano.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Final_ApiAmano.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LineasController : ControllerBase
    {
        DataLinea cnn = new DataLinea();

        // GET: api/<LineasController>
        [HttpGet]
        public IEnumerable<Linea> Get()
        {
            List<Linea> lineas = new List<Linea>();
            cnn.Get(out lineas);
            return lineas;
        }

        // GET api/<LineasController>/5
        [HttpGet("{id}")]
        public Linea Get(int id)
        {
            Linea linea = new Linea();
            cnn.Get(out linea, id);
            return linea;
        }

        // POST api/<LineasController>
        [HttpPost]
        public ActionResult Post(Linea linea)
        {
            try
            {
                cnn.Post(out linea, linea);
                return Ok(linea);

            }
            catch (Exception e )
            {

                return BadRequest(e.Message);
            }
        }

        // PUT api/<LineasController>/5
        [HttpPut("{id}")]
        public ActionResult Put(Linea linea,int id)
        {
            try
            {
                cnn.Put(out linea, id, linea);
                return Ok(linea);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        // DELETE api/<LineasController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            cnn.Delete(id);
        }
    }
}
