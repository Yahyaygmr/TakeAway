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
    public class DeleteOrderedDetailCommandHandler
    {
        private readonly IRepository<OrderDetail, int> _repository;

        public DeleteOrderedDetailCommandHandler(IRepository<OrderDetail, int> repository)
        {
            _repository = repository;
        }

        public async Task Handle(DeleteOrderDetailCommand command)
        {
            await _repository.DeleteAsync(command.Id);
        }
    }
}
