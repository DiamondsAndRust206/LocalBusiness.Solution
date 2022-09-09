using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using LocalBusinessApi.Models;
using System.Linq;

namespace LocalBusinessApi.Controllers
{
  
  [Route("api/[controller]")]
  [ApiController]
  public class LocalBusinessesController :ControllerBase
  {
    private readonly LocalBusinessContext _db;
    public LocalBusinessesController(LocalBusinessContext db)
    {
      _db = db;
    }

    [HttpGet]
    public async Task<List<LocalBusiness>> Get(string type, int rating)
    {

      IQueryable<LocalBusiness> query = _db.LocalBusinesses.AsQueryable();
      if(type != null)
      {
        query = query.Where(e => e.Type == type);
      }
      if(rating > 0)
      {
        query = query.Where(e => e.Rating >= rating);
      }
      return await query.ToListAsync();
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<LocalBusiness>> GetBusiness(int id)
    {
      var localbusiness = await _db.LocalBusinesses.FindAsync(id);
      if(localbusiness == null)
      {
        return NotFound();
      }
      return localbusiness;

    }

    [HttpPost]
    public async Task<ActionResult<LocalBusiness>> Post(LocalBusiness localbusiness)
    {
      _db.LocalBusinesses.Add(localbusiness);
      await _db.SaveChangesAsync();
      return CreatedAtAction(nameof(GetBusiness),new{id=localbusiness.LocalBusinessId},localbusiness);
    } 
    [HttpPut("{id}")]
    public async Task<ActionResult> Put(int id,LocalBusiness localBusiness)
    { 
      if(id!=localBusiness.LocalBusinessId)
      {
        return BadRequest();
      }
      _db.Entry(localBusiness).State =EntityState.Modified;
      try
      {
        await _db.SaveChangesAsync();
      }
      catch(DbUpdateConcurrencyException)
      {
        if(!LocalBusinessExists(id))
        {
          return  NotFound();
        }
        else
        {
          throw;
        }
      }
      return NoContent();

    }
    private bool LocalBusinessExists(int id )
    {
      return _db.LocalBusinesses.Any(entry=>entry.LocalBusinessId ==id);
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
      var localBusiness =await _db.LocalBusinesses.FindAsync(id);
      if(localBusiness == null)
      {
        return NotFound();
      }
      _db.LocalBusinesses.Remove(localBusiness);
      await _db.SaveChangesAsync();
      return NoContent();
    }
  }
}