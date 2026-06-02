using System;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using TWQRP.Models;

namespace TWQRP.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AppController : ControllerBase
    {
        /// <summary>
        /// 取得 API 基本資訊，包含名稱、建置日期及版本號
        /// </summary>
        [HttpPost("AppInfo")]
        public ActionResult<AppInfoResponse> AppInfo()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var version = assembly.GetName().Version?.ToString() ?? "1.0.0";
            var buildDate = System.IO.File.GetLastWriteTime(assembly.Location).ToString("yyyy/MM/dd HH:mm:ss");

            var response = new AppInfoResponse
            {
                ApiName  = "TWQRP",
                BuildDate = buildDate,
                Version  = version
            };

            return Ok(response);
        }
    }
}
