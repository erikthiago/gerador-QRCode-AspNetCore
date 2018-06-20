using QRCoder;
using System.Drawing;

namespace GeradorQRCodeAspNetCore.QRCodeGenerators
{
    public class GeneratorQRCoder
    {
        public Bitmap GeneratedQRCodde(string url)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(url, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(20);
            return qrCodeImage;
        }
    }
}
