using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WX.DMApi.Core.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DownloadController : ControllerBase
    {
        /// <summary>
        /// 根据vin获取文件名
        /// </summary>
        /// <param name="vin"></param>
        /// <returns></returns>
        [HttpGet("getfilenames")]
        public string Get(string vin)
        {
            List<DownloadFileInfo> fileList = new List<DownloadFileInfo>();
            //方案一  方法返回值：IActionResult,FileResult,FileStreamResult
            var basePath = Path.Combine(Directory.GetCurrentDirectory(), "Upload\\" + vin);
            if (!Directory.Exists(basePath))
            {
                return null;
            }

            var files = Directory.GetFiles(basePath);
            foreach (var file in files)
            {
                fileList.Add(new DownloadFileInfo() { FileName = Path.GetFileName(file) });
            }

            return JsonConvert.SerializeObject(fileList);
        }
        /// <summary>
        /// 根据VIN获取工艺图
        /// </summary>
        /// <param name="vin"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        [HttpGet("getfile")]
        public FileStreamResult Get(string vin, string fileName)
        {
            //方案一  方法返回值：IActionResult,FileResult,FileStreamResult
            var basePath = Path.Combine(Directory.GetCurrentDirectory(), "Upload\\" + vin);
            if (!Directory.Exists(basePath))
            {
                return null;
            }
            FileStream fileStream = new FileStream(basePath + "\\" + fileName, FileMode.Open, FileAccess.Read);
            return File(fileStream, "application/octet-stream", fileName);
        }
    }

    public class DownloadFileInfo
    {
        /// <summary>
        /// 文件名
        /// </summary>
        public string FileName { get; set; }
    }
}