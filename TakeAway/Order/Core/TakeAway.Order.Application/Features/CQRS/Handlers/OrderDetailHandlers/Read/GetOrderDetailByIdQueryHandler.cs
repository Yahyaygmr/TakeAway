using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakeAway.Order.Application.Features.CQRS.Queries.OrderDetailQueries;
using TakeAway.Order.Application.Features.CQRS.Results.OrderDetailResults;
using TakeAway.Order.Application.Interfaces;
using TakeAway.Order.Domain.Entities;

namespace TakeAway.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers.Read
{
    public class GetOrderDetailByIdQueryHandler
    {
        private readonly IRepository<OrderDetail, int> _repository;

        public GetOrderDetailByIdQueryHandler(IRepository<OrderDetail, int> repository)
        {
            _repository = repository;
        }
        public async Task<GetOrderDetailByIdQueryResult> Handle(GetOrderDetailByIdQuery query)
        {
            var value = await _repository.GetByIdAsync(query.Id);

            return new GetOrderDetailByIdQueryResult
            {
                Amount = value.Amount,
                OrderDetailId = value.OrderDetailId,
                OrderingId = value.OrderingId,
                Price = value.Price,
                ProductId = value.ProductId,
                ProductName = value.ProductName,
                TotalPrice = value.TotalPrice,
            };
        }
    }
}
