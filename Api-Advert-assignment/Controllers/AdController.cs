using System.Security.AccessControl;
using Api_Advert_assignment.Data;
using Api_Advert_assignment.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api_Advert_assignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public AdController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        

        [HttpGet]
        public async Task<ActionResult<List<Ad>>> GetAll()
        {
            return Ok(await _dbContext.AdDbSet.ToListAsync());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Ad>> GetOne(int id)
        {
            var Advert = _dbContext.AdDbSet.Find(id);

            if (Advert == null)
            {
                return BadRequest("Advert not found");
            }
            return Ok(Advert);
        }
       
        [HttpPost]
        public async Task<ActionResult<Ad>> PostAdvert(Ad Advert)
        {
            _dbContext.AdDbSet.Add(Advert);
            await _dbContext.SaveChangesAsync();
            return Ok(await _dbContext.AdDbSet.ToListAsync());

        }

        [HttpPut]
        public async Task<ActionResult<Ad>> UpdateAdvert(Ad Advert)
        {

            var AdToUpdate = await _dbContext.AdDbSet.FindAsync(Advert.AdId);

            if (AdToUpdate == null)
            {
                return BadRequest("Advert not found");
            }

            AdToUpdate.AdTitle = Advert.AdTitle;
            AdToUpdate.AdType = Advert.AdType;
            AdToUpdate.Description = Advert.Description;
            AdToUpdate.CreatedDate = Advert.CreatedDate;
            AdToUpdate.EndDate = Advert.EndDate;

            return Ok(Advert);
        }
        
        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<Ad>> Delete(int id)
        {
            var Advert = await _dbContext.AdDbSet.FindAsync(id);

            if (Advert == null)
            {
                return BadRequest("Advert not found");
            }

            _dbContext.AdDbSet.Remove(Advert);
            await _dbContext.SaveChangesAsync();
            return Ok(await _dbContext.AdDbSet.ToListAsync());

        }

    }
}
