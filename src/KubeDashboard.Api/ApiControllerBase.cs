﻿using Microsoft.AspNetCore.Mvc;

namespace KubeDashboard.Api;

[Route("api/[controller]/[action]")]
[ApiController]
public abstract class ApiControllerBase : ControllerBase
{

}
