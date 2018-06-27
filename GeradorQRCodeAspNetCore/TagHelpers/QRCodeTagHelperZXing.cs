using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.IO;
using ZXing.QrCode;

namespace GeradorQRCodeAspNetCore.TagHelpers
{
    // Nome da tag helper a ser chamada na razor page
    [HtmlTargetElement("qrcodezxing")]
    public class QRCodeTagHelperZXing : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            // Pega a url informada
            var QrcodeContent = context.AllAttributes["content"].Value.ToString();
            // Pega o texto da imagem
            var alt = context.AllAttributes["alt"].Value.ToString();
            // Tamanho da imagem
            var width = 250; // width of the Qr Code
            var height = 250; // height of the Qr Code
            var margin = 0;
            
            // Configurando o QR Code 
            var qrCodeWriter = new ZXing.BarcodeWriterPixelData
            {
                Format = ZXing.BarcodeFormat.QR_CODE,
                Options = new QrCodeEncodingOptions { Height = height, Width = width, Margin = margin }
            };
            // Gerando o QR Code
            var pixelData = qrCodeWriter.Write(QrcodeContent);

            // criando um bitmap a partir dos dados de pixel brutos; se apenas as cores preto e branco forem usadas, não faz diferença
            // que os dados de pixel são orientados para BGRA e o bitmap é inicializado com RGB
            using (var bitmap = new System.Drawing.Bitmap(pixelData.Width, pixelData.Height, System.Drawing.Imaging.PixelFormat.Format32bppRgb))
            using (var ms = new MemoryStream())
            {
                var bitmapData = bitmap.LockBits(new System.Drawing.Rectangle(0, 0, pixelData.Width, pixelData.Height),
                System.Drawing.Imaging.ImageLockMode.WriteOnly, System.Drawing.Imaging.PixelFormat.Format32bppRgb);
                try
                {
                    // assumimos que o passo da linha do bitmap está alinhado com 4 bytes multiplicado pela largura da imagem
                    System.Runtime.InteropServices.Marshal.Copy(pixelData.Pixels, 0, bitmapData.Scan0,
                    pixelData.Pixels.Length);
                }
                finally
                {
                    bitmap.UnlockBits(bitmapData);
                }
                // salvar para transmitir como PNG
                bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                output.TagName = "img";
                output.Attributes.Clear();
                output.Attributes.Add("width", width);
                output.Attributes.Add("height", height);
                output.Attributes.Add("alt", alt);
                output.Attributes.Add("src",
                String.Format("data:image/png;base64,{0}", Convert.ToBase64String(ms.ToArray())));
            }
        }
    }
}

