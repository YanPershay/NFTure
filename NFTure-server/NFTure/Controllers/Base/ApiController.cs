﻿using Microsoft.AspNetCore.Mvc;

namespace NFTure.Web.Controllers.Base
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class ApiController : ControllerBase { }
}
