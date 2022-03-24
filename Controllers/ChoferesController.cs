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
    public class ChoferesController : ControllerBase
    {
        DataChofer cnn = new DataChofer();

        // GET: api/<ChoferesController>
        [HttpGet]
        public IEnumerable<Chofer> Get()
        {
            List<Chofer> choferes = new List<Chofer>();
            cnn.Get(out choferes);
            return choferes;

        }

        // GET api/<ChoferesController>/5
        [HttpGet("{id}")]
        public Chofer Get(int id)
        {
            Chofer chofer = new Chofer();
            cnn.Get(out chofer, id);
            return chofer;
        }

        // POST api/<ChoferesController>
        [HttpPost]
        public ActionResult Post(Chofer chofer)
        {
            try
            {
                cnn.Post(out chofer,chofer);
                return Ok(chofer);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
                
            }
        }

        // PUT api/<ChoferesController>/5
        [HttpPut("{id}")]
        public ActionResult Put(Chofer chofer , int id)
        {
            try
            {
                cnn.Put(out chofer, id, chofer);
                return Ok(chofer);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        // DELETE api/<ChoferesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            cnn.Delete(id);
        }
    }
}
