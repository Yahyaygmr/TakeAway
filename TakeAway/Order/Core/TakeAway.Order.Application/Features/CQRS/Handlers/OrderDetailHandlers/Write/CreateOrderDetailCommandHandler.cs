using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakeAway.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using TakeAway.Order.Application.Interfaces;
using TakeAway.Order.Domain.Entities;

namespace TakeAway.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers.Write
{
    public class CreateOrderDetailCommandHandler
    {
        private readonly IRepository<OrderDetail, int> _repository;

        public CreateOrderDetailCommandHandler(IRepository<OrderDetail, int> repository)
        {
            _repository = repository;
        }
        public async Task Handle(CreateOrderDetailCommand command)
        {
            await _repository.CreateAsync(new OrderDetail
            {
                Amount = command.Amount,
                OrderingId = command.OrderingId,
                Price = command.Price,
                ProductId = command.ProductId,
                ProductName = command.ProductName,
                TotalPrice = command.TotalPrice,
            });
        }
    }
}
