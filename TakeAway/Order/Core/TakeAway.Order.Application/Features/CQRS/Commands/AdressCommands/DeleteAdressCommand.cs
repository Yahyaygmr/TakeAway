using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TakeAway.Order.Application.Features.CQRS.Commands.AdressCommands
{
    public class DeleteAdressCommand
    {
        public int Id { get; set; }

        public DeleteAdressCommand(int id)
        {
            Id = id;
        }
    }
}
