using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QRCoder;
using WX.DMApi.Util;

namespace WX.DMApi.Core.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class QRCodeController : ControllerBase
    {
        private IQRCode _iQRCode;

        public QRCodeController(IQRCode iQRCode)
        {
            _iQRCode = iQRCode;
        }

        /// <summary>
        /// 获取二维码
        /// </summary>
        /// <param name="url">存储内容</param>
        /// <param name="pixel">像素大小</param>
        /// <returns></returns>
        [HttpGet("qrcode")]
        public void GetQRCode(string url, int pixel)
        {

            Response.ContentType = "image/jpeg";

            var bitmap = _iQRCode.GetQRCode(url, pixel);
            MemoryStream ms = new MemoryStream();
            bitmap.Save(ms, ImageFormat.Jpeg);

            Response.Body.WriteAsync(ms.GetBuffer(), 0, Convert.ToInt32(ms.Length));
            Response.Body.Close();
        }

        /// <summary>
        /// 获取二维码
        /// </summary>
        /// <returns></returns>
        [HttpGet("qrcodeimage")]
        public ActionResult QRCodeImage(string url, int pixel)
        {
            var bitmap = _iQRCode.GetQRCode(url, pixel);
            MemoryStream ms = new MemoryStream();
            bitmap.Save(ms, ImageFormat.Jpeg);

            var bitmapBytes = BitmapToBytes(bitmap);

            return File(bitmapBytes, "image/jpeg");
        }

        /// <summary>
        /// 接收二维码
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ApiExplorerSettings(GroupName = "core")]
        public string getqrcord()
        {
            //获取字符流
            Stream stream = HttpContext.Request.Body;
            byte[] buffer = new byte[HttpContext.Request.ContentLength.Value];
            stream.Read(buffer, 0, buffer.Length);
            string content = Encoding.UTF8.GetString(buffer);
            //Logs.WriteLog("qrcode", content, hostingEnvironment);
            //返回字符流
            return "code=0000";
        }

        private static byte[] BitmapToBytes(Bitmap img)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                img.Save(stream, ImageFormat.Jpeg);
                return stream.GetBuffer();
            }
        }
    }
}
