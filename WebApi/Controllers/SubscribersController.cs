using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscribersController : ControllerBase
    {
        SubscriberContext db;
        public SubscribersController(SubscriberContext context)
        {
            db = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Adress>>> Get()
        {
            return await db.Adresses.ToListAsync();
        }

        // GET api/Subscribers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Adress>> Get(int id)
        {
            Adress adress = await db.Adresses.FirstOrDefaultAsync(x => x.Id == id);
            if (adress == null)
                return NotFound();
            return new ObjectResult(adress);
        }

        // POST api/Subscribers
        [HttpPost]
        public async Task<ActionResult<Adress>> Post(Adress adress)
        {
            if (adress == null)
            {
                return BadRequest();
            }

            db.Adresses.Add(adress);
            await db.SaveChangesAsync();
            return Ok(adress);
        }

        // PUT api/Subscribers/
        [HttpPut]
        public async Task<ActionResult<Adress>> Put(Adress adress)
        {
            if (adress == null)
            {
                return BadRequest();
            }
            if (!db.Adresses.Any(x => x.Id == adress.Id))
            {
                return NotFound();
            }

            db.Update(adress);
            await db.SaveChangesAsync();
            return Ok(adress);
        }

        // DELETE api/Subscribers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Adress>> Delete(int id)
        {
            Adress adress = db.Adresses.FirstOrDefault(x => x.Id == id);
            if (adress == null)
            {
                return NotFound();
            }
            db.Adresses.Remove(adress);
            await db.SaveChangesAsync();
            return Ok(adress);
        }
    }
}
