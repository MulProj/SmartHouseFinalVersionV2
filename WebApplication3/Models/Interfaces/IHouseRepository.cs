using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApplication3.Models.Interfaces
{
    public interface IHouseRepository
    {
        Task<int> AddHouse(House house);
        List<House> GetAllHouses();
        House GetHouse(int houseId);
        void DeleteHouse(House house);
        Task<int> UpdateHouse(House house);
    }
}
