using KartuliAPI2.Models;
using System.Security.Claims;

namespace KartuliAPI2.Services.Interfaces
{
    public interface IWineService
    {
        Task<WineModel> GetWineById(Guid id);
        Task<List<WineModel>> GetWines();
        Task<WineModel> Create(WineModel model);
        Task<WineModel> Update(WineModel model);
        Task Delete(Guid id);
    }
}
