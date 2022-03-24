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
    public class ColectivosController : ControllerBase
    {
        DataColectivo cnn = new DataColectivo();

        // GET: api/<ColectivosController>
        [HttpGet]
        public IEnumerable<Colectivo> Get()
        {
            List<Colectivo> colectivos = new List<Colectivo>();
            cnn.Get(out colectivos);
            return colectivos;
        }

        // GET api/<ColectivosController>/5
        [HttpGet("{id}")]
        public Colectivo Get(int id)
        {
            Colectivo colectivo = new Colectivo();
            cnn.Get(out colectivo,id);
            return colectivo;
        }

        // POST api/<ColectivosController>
        [HttpPost]
        public ActionResult Post(Colectivo colectivo)
        {
            try
            {
                cnn.Post(out colectivo, colectivo);
                return Ok(colectivo);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }

        }

        // PUT api/<ColectivosController>/5
        [HttpPut("{id}")]
        public ActionResult Put(Colectivo colectivo,int id)
        {
            try
            {
                cnn.Put(out colectivo, id, colectivo);
                return Ok(colectivo);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        // DELETE api/<ColectivosController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            cnn.Delete(id);
        }
    }
}
