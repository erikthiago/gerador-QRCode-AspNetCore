using GeradorQRCodeAspNetCore.QRCodeGenerators;
using Microsoft.AspNetCore.Razor.TagHelpers;
using QRCoder;
using System;
using System.Drawing;

namespace GeradorQRCodeAspNetCore.TagHelpers
{
    // Nome da tag helper a ser chamada na razor page
    [HtmlTargetElement("qrcoder")]
    public class QRCodeTagHelperQRCoder : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            // Pega a url informada
            var QrcodeContent = context.AllAttributes["content"].Value.ToString();
            // Pega o texto da imagem
            var alt = context.AllAttributes["alt"].Value.ToString();
            // Tamanho da imagem
            var width = 250; 
            var height = 250; 

            // Configurando o QR Code 
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(QrcodeContent, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            // Geração do QR Code
            Image image = qrCode.GetGraphic(20);
            // Tranformando em byte[] para que seja convertido em png
            byte[] byteArray = GeneratorQRCoder.ImageToByte2(image);
            // Criação da tag e configuraçoes gerais
            output.TagName = "img";
            output.Attributes.Clear();
            output.Attributes.Add("width", width);
            output.Attributes.Add("height", height);
            output.Attributes.Add("alt", alt);
            output.Attributes.Add("src",
            String.Format("data:image/png;base64,{0}", Convert.ToBase64String(byteArray)));
        }
    }
}

