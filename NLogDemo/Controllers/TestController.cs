using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace NLogDemo.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly ILogger<TestController> _logger;

        public TestController(ILogger<TestController> logger)
        {
            _logger = logger;
            _logger.LogDebug(1, "NLog injected into HomeController");
        }
        [HttpGet]
        public IActionResult Index()
        {
            try
            {
                _logger.LogDebug("Hello, this is the index! LogDebug");
                _logger.LogInformation("Hello, this is the index! LogInformation");
                _logger.LogError("Hello, this is the index! LogError");
                _logger.LogWarning("Hello, this is the index! LogWarning");
                _logger.LogTrace("Hello, this is the index! LogTrace");
                _logger.LogCritical("Hello, this is the index LogCritical!");
                throw new Exception("异常消息");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "这是一个异常消息内容");
            }

            return Ok("OK");
        }
    }
}