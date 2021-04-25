using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace OatMilk.Backend.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PingController : ControllerBase
    {
        public PingController()
        {

        }

        /// <summary>
        /// Basic test endpoint.
        /// </summary>
        /// <returns></returns>
        [HttpGet("")]
        public ActionResult<bool> Ping()
        {
            return true;
        }

        /// <summary>
        /// Basic test endpoint. Requires user to be authenticated.
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet("auth")]
        public ActionResult<bool> PingAuth()
        {
            return true;
        }
    }
}
