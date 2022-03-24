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
    public class EstadosController : ControllerBase
    {
        DataEstados cnn = new DataEstados();
        
        // PUT api/<EstadosController>/5
        [HttpPut("{id}")]
        public ActionResult Put(Estado estado, int id)
        {
            try
            {
                cnn.Put(out estado, id, estado);
                return Ok(estado);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

    }
}
