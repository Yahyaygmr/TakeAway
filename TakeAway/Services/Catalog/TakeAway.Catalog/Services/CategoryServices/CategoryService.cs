﻿using TakeAway.Catalog.Dtos.CategoryDtos;

namespace TakeAway.Catalog.Services.CategoryServices
{
    public class CategoryService : ICategoryService
    {
        public Task CreateCategoryAsync(CreateCategoryDto dto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteCategoryAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ResultCategoryDto>> GetAllCategoryAsync()
        {
            throw new NotImplementedException();
        }

        public Task<GetByIdCategoryDto> GetByIdCategoryAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateCategoryAsync(UpdateCategoryDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
