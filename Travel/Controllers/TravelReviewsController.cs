using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
 //Using for XML comments with swagger
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Travel.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

namespace Travel.Controllers
{
  [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
  [Route("api/[controller]")]
  [ApiController]
  public class TravelReviewsController : ControllerBase
  {
    private readonly TravelContext _db;

    public TravelReviewsController(TravelContext db)
    {
      _db = db;
    }

    //GET api/travelreviews
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TravelReview>>> Get(string location, int rating)
    {
      var query = _db.TravelReviews.AsQueryable();

      if (location != null)
      {
        query = query.Where(entry => entry.Location == location);
      }
      if (rating >= 0)
      {
        query = query.Where(entry => entry.Rating == rating);
      }
      return await query.ToListAsync();
    }

    //POST api/travelreviews
    [HttpPost]
    public async Task<ActionResult<TravelReview>> Post(TravelReview travelreview)
    {
      _db.TravelReviews.Add(travelreview);
      await _db.SaveChangesAsync();

      return CreatedAtAction(nameof(GetTravelReview), new { id = travelreview.TravelReviewId }, travelreview);
    }

    //GET: api/travelreviews/5
    [HttpGet("{id}")]
    public async Task<ActionResult<TravelReview>> GetTravelReview(int id)
    {
      var travelreview = await _db.TravelReviews.FindAsync(id);

      if (travelreview == null)
      {
        return NotFound();
      }
      return travelreview;
    }

    // PUT: api/travelreviews/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, TravelReview travelreview)
    {
      if (id != travelreview.TravelReviewId)
      {
        return BadRequest();
      }
    
      _db.Entry(travelreview).State = EntityState.Modified;

      try 
      {
        await _db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!TravelReviewExists(id))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }

      return NoContent();
    }

    // DELETE: api/TravelReviews/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTravelReview(int id)
    {
      var travelreview = await _db.TravelReviews.FindAsync(id);
      if (travelreview == null)
      {
        return NotFound();
      }

      _db.TravelReviews.Remove(travelreview);
      await _db.SaveChangesAsync();

      return NoContent();
    }

    private bool TravelReviewExists(int id)
    {
      return _db.TravelReviews.Any(e => e.TravelReviewId == id);
    }
  
  }
}