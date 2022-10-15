using JSLibrary.Logics.Business.Interfaces;
using JSLibrary.Logics.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Passive.API.Controllers.Base
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class CustomControllerBase<ModelType> : ControllerBase where ModelType : IIdentifierModel<Guid>
    {
    }
}
