using ApbdTest2.DTO;
using ApbdTest2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApbdTest2.Services
{
    public class DbService :IDbService
    {
        private readonly s23037Context _dbContext;

        public DbService(s23037Context dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<ICollection<ActionDTO>> GetTruckActionsAsync(int id)
        {
            
            
            
            return await _dbContext.FireTruckActions
                .OrderByDescending(x => x.IdActionNavigation.EndTime)
                .Where(x => x.IdFireTruck == id)
                .Include(x => x.IdActionNavigation)
                .Select(x => new ActionDTO
                {
                    StartTime = x.IdActionNavigation.StartTime,
                    EndTime = (DateTime)x.IdActionNavigation.EndTime,
                    NumOfFirefighter = x.IdActionNavigation.FirefighterActions.Where(y => y.IdAction == x.IdAction).Count(),
                    AssignmentDate = x.AssignmentDate,
                }
                ).ToListAsync();
        }
       
        public async Task<bool> DoesFireTruckExist(int id)
        {
            return await _dbContext.FireTrucks.AnyAsync(x => x.IdFireTruck == id);
        }
        public async Task<FireTruckDTO> GetTruckAsync(int id)
        {
            var truck = await _dbContext.FireTrucks.FirstOrDefaultAsync(x => x.IdFireTruck == id);
            var list = new List<ActionDTO>();
            return new FireTruckDTO
            {
                IdFireTruck = truck.IdFireTruck,
                OperationalNumber = truck.OperationalNumber,
                SpecialEquipment = truck.SpecialEquipment,
                actions = (List<ActionDTO>)list
            };
                
                
        }
        public async Task UpdateEndAsync(int id, DateTime time)
        {
            //await _dbContext.Actions.Where(x => x.IdAction == id).Select(b => { b.EndTime = time; });
        }
        public async Task<bool> HaveActionEndenAsync(int id)
        {
            return await _dbContext.Actions.AnyAsync(x => x.IdAction == id && x.EndTime == null);
        }
    }
}
