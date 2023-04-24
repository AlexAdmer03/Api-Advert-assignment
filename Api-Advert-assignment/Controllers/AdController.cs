using System.Security.AccessControl;
using Api_Advert_assignment.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api_Advert_assignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdController : ControllerBase
    {
        private static List<Ad> Ads = new List<Ad>
        {
            new Ad
            {
                AdId = 1,
                AdTitle = "Audi advert",
                Description = "Car advert",
                AdType = "Video",
                CreatedDate = DateTime.ParseExact("2023-01-01", "yyyy-MM-dd", null),
                EndDate = DateTime.ParseExact("2023-02-01", "yyyy-MM-dd", null)
            },
            new Ad
            {
                AdId = 2,
                AdTitle = "Zalando advert",
                Description = "Clothing-brand advert",
                AdType = "Banner",
                CreatedDate = DateTime.ParseExact("2023-02-20", "yyyy-MM-dd", null),
                EndDate = DateTime.ParseExact("2023-04-20", "yyyy-MM-dd", null)
            },

        };

        [HttpGet]
        public async Task<ActionResult<List<Ad>>> GetAll()
        {
            return Ok(Ads);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Ad>> GetOne(int id)
        {
            var Advert = Ads.Find(s => s.AdId == id);

            if (Advert == null)
            {
                return BadRequest("Advert not found");
            }
            return Ok(Advert);
        }
       
        [HttpPost]
        public async Task<ActionResult<Ad>> PostAdvert(Ad Advert)
        {
            Ads.Add(Advert);
            return Ok(Advert);
        }

        [HttpPut]
        public async Task<ActionResult<Ad>> UpdateAdvert(Ad Advert)
        {
            
            var AdToUpdate = Ads.Find(s => s.AdId == Advert.AdId);

            if (AdToUpdate == null)
            {
                return BadRequest("Advert not found");
            }

            AdToUpdate.AdTitle = Advert.AdTitle;
            AdToUpdate.AdType = Advert.AdType;
            AdToUpdate.Description = Advert.Description;
            AdToUpdate.CreatedDate = Advert.CreatedDate;
            AdToUpdate.EndDate = Advert.EndDate;

            return Ok(Ads);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<Ad>> Delete(int id)
        {
            var Advert = Ads.Find(s => s.AdId == id);

            if (Advert == null)
            {
                return BadRequest("Advert not found");
            }

            Ads.Remove(Advert);
            return Ok(Ads);
        }

    }
}
