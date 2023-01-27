using Microsoft.EntityFrameworkCore;
using WebMilkApp.Data;
using WebMilkApp.Models;
using WebMilkApp.ViewModels;

namespace WebMilkApp.Services
{
    public class MilkService : IMilkService
    {
        private readonly MilkDbContext _dbContext; 
        public MilkService(MilkDbContext dbContext)
        {
            this._dbContext = dbContext;   
        }
        public async Task<List<Milk>> AllMilkInfo()
        {
            return await _dbContext.MilkInfo.ToListAsync();
        }
        public async Task<Milk> OneMilkInfo(Guid id)
        {
           var milkInfo =  await _dbContext.MilkInfo.FindAsync(id); 
           if(milkInfo == null)
              throw new Exception("No Record Found");
            return milkInfo; 
        
        }
        public async Task AddMilkInfo(List<AddMilkInfoRequestDto> addMilkInfoDto)
        {
            var milkList = new List<Milk>();
            foreach(var item in addMilkInfoDto)
            { 
            var milkInfo = new Milk()
            {
                Id = item.Id,
                Name = item.Name,
                Type = item.Type,
                Storage = item.Storage,
            };
               milkList.Add(milkInfo);
            }
            await _dbContext.AddRangeAsync(milkList);
            await _dbContext.SaveChangesAsync();
            
        }
        public async Task<List<Milk>> SearchMilkInfo(string searchCriteria)
        {
            var trimmedQuery = "%" + searchCriteria + "%";
            var query = _dbContext.MilkInfo
                                  .Where(x =>
                                   EF.Functions.Like(x.Name, trimmedQuery));
            
            var milkInfo = await query.ToListAsync();
            if (milkInfo==null || milkInfo.Count ==0)
            {
                throw new Exception("No Record Found");
            }
            return milkInfo;
        }

    }
} 
