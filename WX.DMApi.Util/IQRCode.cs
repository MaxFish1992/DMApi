using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace WX.DMApi.Util
{
    public interface IQRCode
    {
        Bitmap GetQRCode(string url, int pixel);
    }
}
