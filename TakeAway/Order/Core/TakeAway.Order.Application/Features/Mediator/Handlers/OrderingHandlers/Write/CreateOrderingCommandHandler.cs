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
    public class CreateOrderingCommandHandler : IRequestHandler<CreateOrderingCommand>
    {
        private readonly IRepository<Ordering,int> _repository;

        public CreateOrderingCommandHandler(IRepository<Ordering, int> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateOrderingCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Ordering
            {
                OrderDate = request.OrderDate,
                TotalPrice = request.TotalPrice,
                UserId = request.UserId,
            });
        }
    }
}
