using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakeAway.Order.Application.Features.CQRS.Commands.AdressCommands;
using TakeAway.Order.Application.Interfaces;
using TakeAway.Order.Domain.Entities;

namespace TakeAway.Order.Application.Features.CQRS.Handlers.AdressHandlers.Write
{
    public class DeleteAdressCommandHandler
    {
        private readonly IRepository<Adress, int> _repository;

        public DeleteAdressCommandHandler(IRepository<Adress, int> repository)
        {
            _repository = repository;
        }

        public async Task Handle(DeleteAdressCommand command)
        {
            await _repository.DeleteAsync(command.Id);
        }
    }
}
