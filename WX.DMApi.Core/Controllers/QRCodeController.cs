using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    }
}
