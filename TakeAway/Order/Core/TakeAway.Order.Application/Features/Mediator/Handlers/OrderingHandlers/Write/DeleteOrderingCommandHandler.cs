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
    public class DeleteOrderingCommandHandler : IRequestHandler<DeleteOrderingCommand>
    {
        private readonly IRepository<Ordering, int> _repository;

        public DeleteOrderingCommandHandler(IRepository<Ordering, int> repository)
        {
            _repository = repository;
        }

        public async Task Handle(DeleteOrderingCommand request, CancellationToken cancellationToken)
        {
            await _repository.DeleteAsync(request.Id);
        }
    }
}
