using AutoMapper;
using KartuliAPI2.Entities;
using KartuliAPI2.Models;
using KartuliAPI2.Repositories.Interfaces;
using KartuliAPI2.Services.Interfaces;

namespace KartuliAPI2.Services.Services
{
    public class WineService(IWineRepository wineRepository, IMapper mapper) : IWineService
    {
        private readonly IWineRepository _wineRepository = wineRepository;
        private readonly IMapper _mapper = mapper;
        public async Task<WineModel> Create(WineModel model)
        {

            var wine = new WineEntity
            {
                Name = model.Name,
                Description = model.Description,
                CreatedAt = DateTime.UtcNow,
            };
            await _wineRepository.AddAsync(wine);
            await _wineRepository.SaveAsync();

            return _mapper.Map<WineModel>(wine);
        }

        public async Task Delete(Guid id)
        {
            var wine = await _wineRepository.GetAsync(id);

            if (wine is not null)
            {
                _wineRepository.Delete(wine);
                await _wineRepository.SaveAsync();
            }

            else
            {

                throw new Exception($"Wine with id {id} does not exist");
            }
        }

        public async Task<WineModel> GetWineById(Guid id)
        {
            var wine = await _wineRepository.GetAsync(id);
            if (wine is not null)
            {
                return _mapper.Map<WineModel>(wine);
            }

            throw new Exception($"Wine with id {id} does not exist");
        }

        public async Task<List<WineModel>> GetWines()
        {
            var wines = await _wineRepository.GetAllAsync();
            return _mapper.Map<List<WineModel>>(wines);
        }

        public async Task<WineModel> Update(WineModel model)
        {
            var wine = await _wineRepository.GetAsync(model.Id);
            if (wine is not null)
            {
                wine.Name = model.Name;
                wine.Description = model.Description;
                
                _wineRepository.Update(wine);
                await _wineRepository.SaveAsync();

                return _mapper.Map<WineModel>(wine);
            }

            throw new Exception($"Wine with id {model.Id} does not exist");
        }
    }
}
