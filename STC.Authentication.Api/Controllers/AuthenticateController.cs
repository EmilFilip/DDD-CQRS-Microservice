using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using STC.Authentication.Application.Queries.Parameters;
using STC.Authentication.Application.Queries.Results;
using STC.Authentication.Domain.Models;
using STC.Shared.Cqrs.Query;

namespace STC.Authentication.Api.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly IQueryExecutor _queryExecutor;

        public AuthenticateController(
            IQueryExecutor queryExecutor)
        {
            _queryExecutor = queryExecutor;
        }
        [AllowAnonymous]
        [HttpGet("Test")]
        public IActionResult Test()
        {
            return Ok();
        }

        [AllowAnonymous]
        [HttpPost("login")]
        [ProducesResponseType(typeof(GetLoginQueryResult), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Login([FromBody] UserCredentials userCredentials)
        {
            var results = await _queryExecutor.ExecuteAsync<GetLoginQueryParameters, GetLoginQueryResult>(
                new GetLoginQueryParameters(
                    userName: userCredentials.UserName,
                    password: userCredentials.Password));


            if (string.IsNullOrWhiteSpace(results.UserAccessToken?.Token))
            {
                return Unauthorized();
            }

            return Ok(results.UserAccessToken);
        }
    }
}
