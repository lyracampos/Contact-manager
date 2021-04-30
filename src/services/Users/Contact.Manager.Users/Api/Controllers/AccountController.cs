using System.Threading.Tasks;
using Contact.Manager.Users.Application.Commands.Authenticate;
using Contact.Manager.Users.Application.Commands.Edit;
using Contact.Manager.Users.Application.Commands.Register;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using Contact.Manager.Users.Application.Queries;

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
        [AllowAnonymous]
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
        [Route("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put([FromRoute] Guid id, [FromBody] EditCommand request)
        {
            var result = await mediator.Send(request);
            return Ok(result);
        }

        /// <summary>
        /// busca dados do usuário
        /// </summary>
        /// <param name="request">payload com dados</param>
        /// <returns></returns>
        /// <response code="200">usuário obtido com sucesso.</response>
        /// <response code="500">usuário não foi obtido por algum erro interno.</response>
        [SwaggerOperation(Tags = new[] { "Usuários" })]
        [HttpGet]
        [Route("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var query = new GetQuery(id);
            var result = await mediator.Send(query);
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
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Authenticate([FromBody] AuthenticateCommand request)
        {
            var result = await mediator.Send(request);
            return Ok(result);
        }
    }
}