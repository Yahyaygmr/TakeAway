using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakeAway.Order.Application.Features.CQRS.Commands.AdressCommands;
using TakeAway.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using TakeAway.Order.Application.Interfaces;
using TakeAway.Order.Domain.Entities;

namespace TakeAway.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers.Write
{
    public class UpdateOrderDetailCommandHandler
    {
        private readonly IRepository<OrderDetail, int> _repository;

        public UpdateOrderDetailCommandHandler(IRepository<OrderDetail, int> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateOrderDetailCommand command)
        {
            var values = await _repository.GetByIdAsync(command.OrderDetailId);

            values.OrderingId = command.OrderingId;
            values.ProductName = command.ProductName;
            values.Amount = command.Amount;
            values.Price = command.Price;
            values.TotalPrice = command.TotalPrice;
            values.ProductId = command.ProductId;

            await _repository.UpdateAsync(values);
        }
    }
}
