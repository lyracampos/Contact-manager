using System.Threading.Tasks;
using Contact.Manager.Users.Application.Commands.Authentication;
using Contact.Manager.Users.Application.Commands.Edit;
using Contact.Manager.Users.Application.Commands.Register;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Contact.Manager.Users.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class AccountController
    {

        [HttpPost]
        [Route("register")]
        [ProducesResponseType(typeof(RegisterCommandResult), StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public  Task<IActionResult> Post([FromBody] RegisterCommand request)
        {

            return null;
        }

        [HttpPut]
        [Route("{id}/edit")]
        [ProducesResponseType(typeof(EditCommandResult), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public  Task<IActionResult> Put([FromBody] EditCommad request)
        {

            return null;
        }

        [HttpPost]
        [Route("authenticate")]
        [ProducesResponseType(typeof(AuthenticateCommandResult), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public  Task<IActionResult> Authenticate([FromBody] AuthenticateCommand request)
        {

            return null;
        }
    }
}