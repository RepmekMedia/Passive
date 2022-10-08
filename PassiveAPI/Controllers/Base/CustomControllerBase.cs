using JSLibrary.Logics.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace PassiveAPI.Controllers.Base
{
    public abstract class CustomControllerBase<ModelType> : ControllerBase where ModelType : IDBModel
    {
    }
}
