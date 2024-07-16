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
    public class CreateAdressCommandHandler
    {
        private readonly IRepository<Adress, int> _repository;

        public CreateAdressCommandHandler(IRepository<Adress, int> repository)
        {
            _repository = repository;
        }
        public async Task Handle(CreateAdressCommand command)
        {
            await _repository.CreateAsync(new()
            {
                City = command.City,
                Detail = command.Detail,
                District = command.District,
                Email = command.Email,
                UserId = command.UserId,
                UserName = command.UserName,
                UserSurname = command.UserName,
            });
        }
    }
}