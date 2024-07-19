using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TakeAway.Order.Application.Features.CQRS.Commands.AdressCommands;
using TakeAway.Order.Application.Features.CQRS.Handlers.AdressHandlers.Read;
using TakeAway.Order.Application.Features.CQRS.Handlers.AdressHandlers.Write;
using TakeAway.Order.Application.Features.CQRS.Queries.AdressQueries;

namespace TakeAway.Order.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdressesController : ControllerBase
    {
        private readonly GetAdressByIdQueryHandler _getAdressByIdQueryHandler;
        private readonly GetAdressQueryHandler _getAdressQueryHandler;
        private readonly CreateAdressCommandHandler _createAdressCommandHandler;
        private readonly UpdateAdressCommandHandler _updateAdressCommandHandler;
        private readonly DeleteAdressCommandHandler _deleteAdressCommandHandler;

        public AdressesController(GetAdressByIdQueryHandler getAdressByIdQueryHandler, GetAdressQueryHandler getAdressQueryHandler, CreateAdressCommandHandler createAdressCommandHandler, UpdateAdressCommandHandler updateAdressCommandHandler, DeleteAdressCommandHandler deleteAdressCommandHandler)
        {
            _getAdressByIdQueryHandler = getAdressByIdQueryHandler;
            _getAdressQueryHandler = getAdressQueryHandler;
            _createAdressCommandHandler = createAdressCommandHandler;
            _updateAdressCommandHandler = updateAdressCommandHandler;
            _deleteAdressCommandHandler = deleteAdressCommandHandler;
        }
        [HttpGet]
        public async Task<IActionResult> AdressList()
        {
            var values = await _getAdressQueryHandler.Handle();
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateAdress(CreateAdressCommand command)
        {
            await _createAdressCommandHandler.Handle(command);
            return Ok("Adres Eklendi");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteAdress(int id)
        {
            await _deleteAdressCommandHandler.Handle(new DeleteAdressCommand(id));
            return Ok("Adres Silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAdress(UpdateAdressCommand command)
        {
            await _updateAdressCommandHandler.Handle(command);
            return Ok("Adres Güncellendi");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAdress(int id)
        {
            var values = await _getAdressByIdQueryHandler.Handle(new GetAdressByIdQuery(id));
            return Ok(values);
        }

    }
}
