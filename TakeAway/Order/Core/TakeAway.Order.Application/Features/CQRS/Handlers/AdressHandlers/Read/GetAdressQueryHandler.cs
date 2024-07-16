using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakeAway.Order.Application.Features.CQRS.Results.AdressResults;
using TakeAway.Order.Application.Interfaces;
using TakeAway.Order.Domain.Entities;

namespace TakeAway.Order.Application.Features.CQRS.Handlers.AdressHandlers.Read
{
    public class GetAdressQueryHandler
    {
        private readonly IRepository<Adress, int> _repository;

        public GetAdressQueryHandler(IRepository<Adress, int> repository)
        {
            _repository = repository;
        }
        public async Task<List<GetAdressQueryResult>> Handle()
        {
            var values = await _repository.GetAllAsync();

            return values.Select(x => new GetAdressQueryResult
            {
                AdressId = x.AdressId,
                City = x.City,
                Detail = x.Detail,
                District = x.District,
                Email = x.Email,
                UserId = x.UserId,
                UserName = x.UserName,
                UserSurname = x.UserName,
            }).ToList();
        }
    }
}
