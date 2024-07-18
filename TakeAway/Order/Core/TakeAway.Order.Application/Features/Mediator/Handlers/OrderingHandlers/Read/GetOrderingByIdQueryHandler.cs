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
    public class GetOrderingByIdQueryHandler : IRequestHandler<GetOrderingByIdQuery, GetOrderingByIdQueryResult>
    {
        private readonly IRepository<Ordering, int> _repository;

        public GetOrderingByIdQueryHandler(IRepository<Ordering, int> repository)
        {
            _repository = repository;
        }

        public async Task<GetOrderingByIdQueryResult> Handle(GetOrderingByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);

            return new GetOrderingByIdQueryResult
            {
                OrderDate = value.OrderDate,
                OrderingId = value.OrderingId,
                TotalPrice = value.TotalPrice,
                UserId = value.UserId,

            };
        }
    }
}
