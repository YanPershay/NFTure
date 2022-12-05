using Microsoft.AspNetCore.Mvc;

namespace NFTure.Web.Controllers.Base
{
    // TODO: configure versioning with swagger
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class ApiController : ControllerBase { }
}
