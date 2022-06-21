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
                    NumOfFirefighter = 0,
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
            var truck = await _dbContext.FireTrucks.FirstAsync(x => x.IdFireTruck == id);
            var list = await GetTruckActionsAsync(id);
            return new FireTruckDTO
            {
                IdFireTruck = truck.IdFireTruck,
                OperationalNumber = truck.OperationalNumber,
                SpecialEquipment = truck.SpecialEquipment,
                actions = (List<ActionDTO>)list
            };
                
                
        }
    }
}
