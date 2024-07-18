using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakeAway.Order.Application.Features.CQRS.Results.OrderDetailResults;
using TakeAway.Order.Application.Interfaces;
using TakeAway.Order.Domain.Entities;

namespace TakeAway.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers.Read
{
    public class GetOrderDetailQueryHandler
    {
        private readonly IRepository<OrderDetail, int> _repository;

        public GetOrderDetailQueryHandler(IRepository<OrderDetail, int> repository)
        {
            _repository = repository;
        }
        public async Task<List<GetOrderDetailQueryResult>> Handle()
        {
            var values = await _repository.GetAllAsync();

            return values.Select(x => new GetOrderDetailQueryResult
            {
                Amount = x.Amount,
                OrderDetailId = x.OrderDetailId,
                OrderingId = x.OrderingId,
                Price = x.Price,
                ProductId = x.ProductId,
                ProductName = x.ProductName,
                TotalPrice = x.TotalPrice,
            }).ToList();
        }
    }
}
