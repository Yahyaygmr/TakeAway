using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakeAway.Order.Application.Features.Mediator.Commands.OrderingCommands;
using TakeAway.Order.Application.Interfaces;
using TakeAway.Order.Domain.Entities;

namespace TakeAway.Order.Application.Features.Mediator.Handlers.OrderingHandlers.Write
{
    public class UpdateOrderingCommandHandler : IRequestHandler<UpdateOrderingCommand>
    {
        private readonly IRepository<Ordering, int> _repository;

        public UpdateOrderingCommandHandler(IRepository<Ordering, int> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateOrderingCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.OrderingId);

            value.OrderDate = request.OrderDate;
            value.UserId = request.UserId;
            value.TotalPrice = request.TotalPrice;
            await _repository.UpdateAsync(value);
        }
    }
}
