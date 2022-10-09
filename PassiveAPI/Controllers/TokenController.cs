using JSLibrary.AuthenticationHandlers.Credentials;
using JSLibrary.AuthenticationHandlers.Responses;
using JSLibrary.AuthenticationHandlers.Responses.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PassiveAPI.Managements.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace PassiveAPI.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/[controller]")]
    public class TokenController : ControllerBase
    {
        private readonly ILogger<TokenController> logger;
        private readonly ITokenManagement tokenManagement;

        public TokenController(ITokenManagement tokenManagement, ILogger<TokenController> logger)
        {
            this.tokenManagement = tokenManagement;
            this.logger = logger;
        }

        [HttpPost]
        [ProducesResponseType(typeof(TokenResponse), 200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Post([FromBody, Required] ClientCredentials clientCredentials, CancellationToken cancellationToken)
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
