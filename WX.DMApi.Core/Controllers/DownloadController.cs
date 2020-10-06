using System;
using System.Collections.Generic;
using System.Drawing;
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

            //List<byte> btlst = new List<byte>();
            //int b = fileStream.ReadByte();
            //while (b > -1)
            //{
            //    btlst.Add((byte)b);
            //    b = fileStream.ReadByte();
            //}
            //byte[] bts = btlst.ToArray();
            //return bts;

            return File(fileStream, "application/octet-stream", fileName);
        }

        /// <summary>
        /// 访问图片
        /// </summary>
        /// <param name="width">所访问图片的宽度,高度自动缩放,大于原图尺寸或者小于等于0返回原图</param>
        /// <param name="name">所要访问图片的名称或者相对地址</param>
        /// <returns>图片</returns>
        [HttpGet("getimage")]
        public IActionResult GetImage(string vin, string fileName)
        {
            var basePath = Path.Combine(Directory.GetCurrentDirectory(), "Upload\\" + vin);
            if (!Directory.Exists(basePath))
            {
                return null;
            }

            var width = 700;
            var errorImage = basePath + "404.png";//没有找到图片
            var imgPath = string.IsNullOrEmpty(fileName) ? errorImage : basePath + "\\" + fileName;
            //获取图片的返回类型
            var contentTypDict = new Dictionary<string, string> {
                {"jpg","image/jpeg"},
                {"jpeg","image/jpeg"},
                {"jpe","image/jpeg"},
                {"png","image/png"},
                {"gif","image/gif"},
                {"ico","image/x-ico"},
                {"tif","image/tiff"},
                {"tiff","image/tiff"},
                {"fax","image/fax"},
                {"wbmp","image//vnd.wap.wbmp"},
                {"rp","image/vnd.rn-realpix"}
            };
            var contentTypeStr = "image/jpeg";
            var imgTypeSplit = fileName.Split('.');
            var imgType = imgTypeSplit[imgTypeSplit.Length - 1].ToLower();
            //未知的图片类型
            if (!contentTypDict.ContainsKey(imgType))
            {
                imgPath = errorImage;
            }
            else
            {
                contentTypeStr = contentTypDict[imgType];
            }
            //图片不存在
            if (!new FileInfo(imgPath).Exists)
            {
                imgPath = errorImage;
            }
            //原图
            if (width <= 0)
            {
                using (var sw = new FileStream(imgPath, FileMode.Open))
                {
                    var bytes = new byte[sw.Length];
                    sw.Read(bytes, 0, bytes.Length);
                    sw.Close();
                    return new FileContentResult(bytes, contentTypeStr);
                }
            }
            //缩小图片
            using (var imgBmp = new Bitmap(imgPath))
            {
                //找到新尺寸
                var oWidth = imgBmp.Width;
                var oHeight = imgBmp.Height;
                var height = oHeight;
                if (width > oWidth)
                {
                    width = oWidth;
                }
                else
                {
                    height = width * oHeight / oWidth;
                }
                var newImg = new Bitmap(imgBmp, width, height);
                newImg.SetResolution(72, 72);
                var ms = new MemoryStream();
                newImg.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                var bytes = ms.GetBuffer();
                ms.Close();
                return new FileContentResult(bytes, contentTypeStr);
            }
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