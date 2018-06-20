using System.Drawing;

namespace GeradorQRCodeAspNetCore.QRCodeGenerators
{
    public class ZXingGeneratorQRCode
    {
        public Bitmap QRCodeGenerator(int width, int height, string url)
        {
            var barCode = new ZXing.BarcodeWriter<ZXing.IBarcodeWriter>
            {
                Format = ZXing.BarcodeFormat.QR_CODE,
                Options = new ZXing.Common.EncodingOptions() { Width = width, Height = height, Margin = 0 }
            };
            return new Bitmap((Image)barCode.Write(url));
        }
    }
}
