using KartuliAPI2.Entities;
using KartuliAPI2.Repositories.Interfaces;

namespace KartuliAPI2.Repositories.Repositories
{
    public class WineRepository(KartuliAPI2DbContext context) : GenericRepository<WineEntity>(context), IWineRepository
    {
    }
}
