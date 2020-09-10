using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WX.DMApi.Core.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UploadController : ControllerBase
    {
        private static string _vin = string.Empty;
        [HttpGet("setvin")]
        public string SetVin(string vin)
        {
            _vin = vin;
            return _vin;
        }
        /// <summary>
        /// 上传图片到服务器
        /// </summary>
        /// <param name="environment"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<bool> InsertPicture([FromServices] IHostingEnvironment environment)
        {
            var data = new PicData();
            string path = string.Empty;
            var files = Request.Form.Files;
            if (files == null || files.Count() <= 0) { data.Msg = "请选择上传的文件。"; return false; }

            var basePath = Path.Combine(environment.ContentRootPath, "Upload\\" + _vin);
            if (!Directory.Exists(basePath))
            {
                Directory.CreateDirectory(basePath);
            }
            //格式限制
            var allowType = new string[] { "image/jpg", "image/png", "image/jpeg" };
            if (files.Any(c => allowType.Contains(c.ContentType)))
            {
                if (files.Sum(c => c.Length) <= 1024 * 1024 * 4)
                {
                    foreach (var file in files)
                    {
                        string strpath = Path.Combine("Upload", _vin + "\\" + file.FileName);
                        path = Path.Combine(environment.ContentRootPath, strpath);

                        using (var stream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                        {
                            await file.CopyToAsync(stream);
                        }
                    }
                    data.Msg = "上传成功";
                    return true;
                }
                else
                {
                    data.Msg = "图片过大";
                    return false;
                }
            }
            else

            {
                data.Msg = "图片格式错误";
                return false;
            }
        }
    }

    public class PicData
    {
        public string Msg { get; set; }
    }
}
