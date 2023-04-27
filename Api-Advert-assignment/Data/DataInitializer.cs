using Api_Advert_assignment.Models;
using Microsoft.EntityFrameworkCore;

namespace Api_Advert_assignment.Data
{
    public class DataInitializer
    {
        private readonly ApplicationDbContext _dbContext;

        public DataInitializer(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void MigrateData()
        {
            _dbContext.Database.Migrate();
            SeedData();
            _dbContext.SaveChanges();
        }

        private void SeedData()
        {
            if (!_dbContext.AdDbSet
                    .Any(e => e.AdTitle == "Audi advert"))
            {
                _dbContext.Add(new Ad
                {
                    AdTitle = "Audi advert",
                    Description = "Car advert",
                    AdType = "Video",
                    CreatedDate = DateTime.ParseExact("2023-01-01", "yyyy-MM-dd", null),
                    EndDate = DateTime.ParseExact("2023-02-01", "yyyy-MM-dd", null)
                });
            }
            if (!_dbContext.AdDbSet
                    .Any(e => e.AdTitle == "Zalando advert"))
            {
                _dbContext.Add(new Ad
                {
                    AdTitle = "Zalando advert",
                    Description = "Clothing-brand advert",
                    AdType = "Banner",
                    CreatedDate = DateTime.ParseExact("2023-02-20", "yyyy-MM-dd", null),
                    EndDate = DateTime.ParseExact("2023-04-20", "yyyy-MM-dd", null)
                });
            }
        }
    }

}
