using JSLibrary.AuthenticationHandlers.Credentials;
using JSLibrary.AuthenticationHandlers.Responses;
using JSLibrary.AuthenticationHandlers.Responses.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Passive.API.Managements.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Passive.API.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly ILogger<LoginController> logger;
        private readonly ITokenManagement tokenManagement;

        public LoginController(ITokenManagement tokenManagement, ILogger<LoginController> logger)
        {
            this.tokenManagement = tokenManagement;
            this.logger = logger;
        }

        [HttpPost]
        [ProducesResponseType(typeof(TokenResponse), 200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Login([FromBody, Required] ClientCredentials clientCredentials, CancellationToken cancellationToken)
        {
            logger.LogInformation(message: clientCredentials.ClientId);
            if (await tokenManagement.ValidateAsync(clientCredentials, cancellationToken))
            {
                ITokenResponse result = await tokenManagement.GenerateAsync(clientCredentials, cancellationToken);
                if (result != null)
                {
                    return Ok(result);
                }
            }
            return NotFound(clientCredentials);
        }
    }
}
