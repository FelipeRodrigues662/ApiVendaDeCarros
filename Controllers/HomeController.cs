﻿using Microsoft.AspNetCore.Mvc;

namespace ApiSqlAsp.Controllers
{
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet("")]
        public IActionResult Get()
        {
            return Ok();
        }

        [HttpGet("v1")]
        public IActionResult GetV1()
        {
            return Ok();
        }
    }
}
