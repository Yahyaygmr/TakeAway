using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakeAway.Order.Application.Features.CQRS.Queries.AdressQueries;
using TakeAway.Order.Application.Features.CQRS.Results.AdressResults;
using TakeAway.Order.Application.Interfaces;
using TakeAway.Order.Domain.Entities;

namespace TakeAway.Order.Application.Features.CQRS.Handlers.AdressHandlers.Read
{
    public class GetAdressByIdQueryHandler
    {
        private readonly IRepository<Adress, int> _repository;

        public GetAdressByIdQueryHandler(IRepository<Adress, int> repository)
        {
            _repository = repository;
        }
        public async Task<GetAdressByIdQueryResult> Handle(GetAdressByIdQuery query)
        {
            var values = await _repository.GetByIdAsync(query.Id);

            return new GetAdressByIdQueryResult
            {
                AdressId = values.AdressId,
                City = values.City,
                Detail = values.Detail,
                District = values.District,
                Email = values.Email,
                UserId = values.UserId,
                UserName = values.UserName,
                UserSurname = values.UserName,
            };
        }
    }
}
