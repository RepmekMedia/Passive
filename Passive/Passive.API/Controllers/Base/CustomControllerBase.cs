using EFCoreSecondLevelCacheInterceptor;
using JSLibrary.Logics.Business.Interfaces;
using JSLibrary.Logics.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Passive.API.Controllers.Base
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class CustomControllerBase : ControllerBase
    {
        protected CustomControllerBase(ILogger logger, IMediator mediator)
        {
        }

        protected ILogger Logger { get; init; }

        protected IMediator Mediator { get; init; }
    }
}
