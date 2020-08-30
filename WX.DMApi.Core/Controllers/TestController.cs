using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WX.DMApi.Core.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet("getstring")]
        public string GetString()
        {
            return ".Net Core 测试 API!";
        }

        [HttpGet("getname")]
        public string GetName()
        {
            return "万象津专专用汽车有限责任公司!";
        }
    }
}
