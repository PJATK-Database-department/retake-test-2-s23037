using ApbdTest2.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApbdTest2.Services
{
    public interface IDbService
    {
        Task<ICollection<ActionDTO>> GetTruckActionsAsync(int id);
        Task<bool> DoesFireTruckExist(int id);
        Task<FireTruckDTO> GetTruckAsync(int id);
        Task UpdateEndAsync(int id, DateTime time);
        Task<bool> HaveActionEndenAsync(int id);
    }
}
