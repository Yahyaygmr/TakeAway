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
    public class UpdateAdressCommandHandler
    {
        private readonly IRepository<Adress, int> _repository;

        public UpdateAdressCommandHandler(IRepository<Adress, int> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateAdressCommand command)
        {
            var values = await _repository.GetByIdAsync(command.AdressId);

            values.UserSurname = command.UserSurname;
            values.UserId = command.UserId;
            values.UserName = command.UserName;
            values.City = command.City;
            values.District = command.District;
            values.Detail = command.Detail;
            values.Email = command.Email;

            await _repository.UpdateAsync(values);
        }
    }
}
