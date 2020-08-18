using Microsoft.AspNetCore.Mvc;

namespace Contact.Manager.Users.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class ValuesController : ControllerBase
    {
        public string[] Get()
        {
            return new string[] { "value 1", "value 2" };
        }
    }
}