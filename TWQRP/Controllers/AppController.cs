using System;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using TWQRP.Models;

namespace TWQRP.Controllers
{
    /// <summary>
    /// 應用程式基本資訊查詢
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class AppController : ControllerBase
    {
        private static readonly string _version =
            Assembly.GetExecutingAssembly().GetName().Version?.ToString() ?? "1.0.0";

        private static readonly string _buildDate = GetBuildDate();

        private static string GetBuildDate()
        {
            var assemblyPath = Assembly.GetExecutingAssembly().Location;
            if (!string.IsNullOrEmpty(assemblyPath) && System.IO.File.Exists(assemblyPath))
                return System.IO.File.GetLastWriteTime(assemblyPath).ToString("yyyy/MM/dd HH:mm:ss");

            var fallbackPath = System.IO.Path.Combine(AppContext.BaseDirectory, "TWQRP.dll");
            return System.IO.File.Exists(fallbackPath)
                ? System.IO.File.GetLastWriteTime(fallbackPath).ToString("yyyy/MM/dd HH:mm:ss")
                : DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
        }

        /// <summary>
        /// 取得 API 基本資訊，包含名稱、建置日期及版本號
        /// </summary>
        [HttpPost("AppInfo")]
        public ActionResult<AppInfoResponse> AppInfo()
        {
            var response = new AppInfoResponse
            {
                ApiName   = "TWQRP",
                BuildDate = _buildDate,
                Version   = _version
            };

            return Ok(response);
        }
    }
}
