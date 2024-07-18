﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TakeAway.Order.Application.Features.Mediator.Commands.OrderingCommands
{
    public class DeleteOrderingCommand : IRequest
    {
        public int Id { get; set; }

        public DeleteOrderingCommand(int id)
        {
            Id = id;
        }
    }
}
