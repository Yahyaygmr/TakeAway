using AutoMapper;
using MongoDB.Driver;
using TakeAway.Catalog.Dtos.SliderDtos;
using TakeAway.Catalog.Entities;
using TakeAway.Catalog.Settings;

namespace TakeAway.Catalog.Services.SliderServices
{
    public class SliderService : ISliderService
    {
        private readonly IMongoCollection<Slider> _sliderCollection;
        private readonly IMapper _mapper;

        public SliderService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            _mapper = mapper;
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _sliderCollection = database.GetCollection<Slider>(databaseSettings.SliderCollectionName);

        }

        public async Task CreateSliderAsync(CreateSliderDto dto)
        {
            var value = _mapper.Map<Slider>(dto);
            await _sliderCollection.InsertOneAsync(value);
        }

        public async Task DeleteSliderAsync(string id)
        {
            await _sliderCollection.DeleteOneAsync(x => x.SliderId == id);
        }

        public async Task<List<ResultSliderDto>> GetAllSliderAsync()
        {
            var values = await _sliderCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultSliderDto>>(values);

        }

        public async Task<GetByIdSliderDto> GetByIdSliderAsync(string id)
        {
            var values = await _sliderCollection.Find<Slider>(x => x.SliderId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdSliderDto>(values);
        }

        public async Task UpdateSliderAsync(UpdateSliderDto dto)
        {
            var values = _mapper.Map<Slider>(dto);
            await _sliderCollection.FindOneAndReplaceAsync(x => x.SliderId == dto.SliderId, values);
        }
    }
}

