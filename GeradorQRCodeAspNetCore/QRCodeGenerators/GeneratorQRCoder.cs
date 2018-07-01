using QRCoder;
using System.Drawing;
using System.IO;
using static QRCoder.PayloadGenerator;

namespace GeradorQRCodeAspNetCore.QRCodeGenerators
{
    public static class GeneratorQRCoder
    {
        /// <summary>
        /// Gerador de QR Code para uma string, url de um site
        /// </summary>
        /// <param name="url">Link de endereço de um site</param>
        /// <returns>Retorna um QR Code em imagem</returns>
        public static Bitmap GeneratedQRCode(string url)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(url, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(20);
            return qrCodeImage;
        }

        /// <summary>
        /// Converte a imagem do QR Code gerado em byte array
        /// </summary>
        /// <param name="img">A imagem do QR Code gerado</param>
        /// <returns>A imagem convertida em byte array</returns>
        public static byte[] ImageToByte2(Image img)
        {
            using (var stream = new MemoryStream())
            {
                img.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                return stream.ToArray();
            }
        }

        /// <summary>
        /// Gerador de QR Code para enviar um e-mail
        /// </summary>
        /// <param name="email">e-mail de destino</param>
        /// <param name="subject">Assunto do e-mail</param>
        /// <param name="message">Corpo da mensagem</param>
        /// <returns>Imagem do QR Code direcionado para o envio do e-mail</returns>
        public static Bitmap GeneratedQRCodeMail(string email, string subject, string message)
        {
            Mail generator = new Mail(email, subject, message);
            string payload = generator.ToString();

            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(payload, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeAsBitmap = qrCode.GetGraphic(20);
            return qrCodeAsBitmap;
        }

        /// <summary>
        /// QR Code gerado para ligação de celular
        /// </summary>
        /// <param name="number">Número de telefone</param>
        /// <returns>QR Code que direciona para uma ligação</returns>
        public static Bitmap GeneratedQRCodeLigacaoCelular(string number)
        {
            PhoneNumber generator = new PhoneNumber(number);
            string payload = generator.ToString();

            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(payload, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeAsBitmap = qrCode.GetGraphic(20);
            return qrCodeAsBitmap;
        }

        /// <summary>
        /// QR Code gerado para envio de mensagem no WhatsApp
        /// </summary>
        /// <param name="message">Mensagem a ser enviada</param>
        /// <returns>QR Code que direciona para o whatsapp</returns>
        public static Bitmap GeneratedQRCodeWhatsApp(string message)
        {
            WhatsAppMessage generator = new WhatsAppMessage(message);
            string payload = generator.ToString();

            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(payload, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeAsBitmap = qrCode.GetGraphic(20);
            return qrCodeAsBitmap;
        }
    }
}
