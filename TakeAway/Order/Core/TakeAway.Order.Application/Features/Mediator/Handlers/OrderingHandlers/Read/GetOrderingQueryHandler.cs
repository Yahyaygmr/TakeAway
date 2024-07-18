using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakeAway.Order.Application.Features.Mediator.Queries.OrderingQueries;
using TakeAway.Order.Application.Features.Mediator.Results.OrderingResults;
using TakeAway.Order.Application.Interfaces;
using TakeAway.Order.Domain.Entities;

namespace TakeAway.Order.Application.Features.Mediator.Handlers.OrderingHandlers.Read
{
    public class GetOrderingQueryHandler : IRequestHandler<GetOrderingQuery, List<GetOrderingQueryResult>>
    {
        private readonly IRepository<Ordering, int> _repository;

        public GetOrderingQueryHandler(IRepository<Ordering, int> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetOrderingQueryResult>> Handle(GetOrderingQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();

            return values.Select(x => new GetOrderingQueryResult
            {
                OrderDate = x.OrderDate,
                OrderingId = x.OrderingId,
                TotalPrice = x.TotalPrice,
                UserId = x.UserId,
            }).ToList();
        }
    }
}
