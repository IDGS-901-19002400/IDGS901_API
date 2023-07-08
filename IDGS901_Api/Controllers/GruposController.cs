using IDGS901_Api.Context;
using IDGS901_Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IDGS901_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GruposController : ControllerBase
    {

        private readonly AppDbContext _context;

        public GruposController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet] //api/<Grupos>

        public ActionResult Get()
        {
            try
            {
                return Ok(_context.Alumnos.ToList());
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}", Name = "Alumnos")]
        public ActionResult Get(int id)
        {
            try
            {
                var alum = _context.Alumnos.FirstOrDefault(a => a.Id == id);
                return Ok(alum);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        public ActionResult<Alumnos> Post([FromBody] Alumnos alum)
        {
            try
            {
                _context.Alumnos.Add(alum);
                _context.Alumnos.Add(alum);
                _context.SaveChanges();
                return CreatedAtRoute("Alumnos", new { id = alum.Id }, alum);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Alumnos alumn)
        {
            try
            {
                if(alumn.Id == id)
                {
                    _context.Entry(alumn).State = EntityState.Modified;
                    _context.SaveChanges();

                    return CreatedAtRoute("Alumnos", new { id = id }, alumn);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]

        public ActionResult Delete(int id)
        {
            try
            {
                var alum = _context.Alumnos.FirstOrDefault(a => a.Id == id);

                if(alum != null)
                {
                    _context.Remove(alum);
                    _context.SaveChanges();

                    return Ok(id);
                }
                else
                {
                    return BadRequest();
                }

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }


    }
}
