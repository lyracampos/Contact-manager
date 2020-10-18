using System.Threading.Tasks;
using Contact.Manager.Users.Application.Commands.Authentication;
using Contact.Manager.Users.Application.Commands.Edit;
using Contact.Manager.Users.Application.Commands.Register;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Contact.Manager.Users.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class AccountController : ControllerBase
    {
        private readonly IMediator mediator;

        public AccountController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        /// <summary>
        /// registra novos usuários na plataforma
        /// </summary>
        /// <param name="request">payload com informações para registro</param>
        /// <returns></returns>
        /// <response code="201">usuário registrado com sucesso.</response>
        /// <response code="500">usuário não foi registrado por algum erro interno.</response>
        [SwaggerOperation(Tags = new[] { "Usuários" })]
        [HttpPost]
        [Route("register")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post([FromBody] RegisterCommand request)
        {
            var result = await mediator.Send(request);
            return Created("", result);
        }

        /// <summary>
        /// edita dados do usuário na plataforma
        /// </summary>
        /// <param name="request">payload com dados para edição</param>
        /// <returns></returns>
        /// <response code="201">usuário editado com sucesso.</response>
        /// <response code="500">usuário não foi editado por algum erro interno.</response>
        [SwaggerOperation(Tags = new[] { "Usuários" })]
        [HttpPut]
        [Route("{id}/edit")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put([FromBody] EditCommad request)
        {
            var result = await mediator.Send(request);
            return Ok(result);
        }

        /// <summary>
        /// autentica usuário na plataforma
        /// </summary>
        /// <param name="request">payload com dados para autenticação</param>
        /// <returns></returns>
        /// <response code="201">usuário autenticado com sucesso.</response>
        /// <response code="500">usuário não foi autenticado por algum erro interno.</response>
        [SwaggerOperation(Tags = new[] { "Usuários" })]
        [HttpPost]
        [Route("authenticate")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Authenticate([FromBody] AuthenticateCommand request)
        {
            var result = await mediator.Send(request);
            return NotFound();
        }
    }
}