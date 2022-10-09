﻿using JSLibrary.Logics.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace PassiveAPI.Controllers.Base
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class CustomControllerBase<ModelType> : ControllerBase where ModelType : IDBModel
    {
    }
}
