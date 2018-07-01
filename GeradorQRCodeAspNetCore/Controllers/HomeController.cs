using GeradorQRCodeAspNetCore.QRCodeGenerators;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;

namespace GeradorQRCodeAspNetCore.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GeradorQRCoder()
        {
            string url = "https://medium.com/@rikthiago";
            ViewBag.Message = url;
            return View();
        }

        public IActionResult GeradorZXing()
        {
            string url = "https://medium.com/@rikthiago";
            ViewBag.Message = url;
            return View();
        }

        public IActionResult GeradorQRCoderSimples()
        {
            string url = "https://medium.com/@rikthiago";
            Image image = GeneratorQRCoder.GeneratedQRCode(url);
            byte[] byteArray = GeneratorQRCoder.ImageToByte2(image);
            ViewBag.Message = byteArray;
            return View();
        }

        public IActionResult GeradorQRCodeEmail()
        {
            Image image = GeneratorQRCoder.GeneratedQRCodeMail("teste@email.com", "Teste QR Code", "Uma mensagem qualquer");
            byte[] byteArray = GeneratorQRCoder.ImageToByte2(image);
            ViewBag.Message = byteArray;
            return View();
        }

        public IActionResult GeradorQRCodeLigacaoCelular()
        {
            Image image = GeneratorQRCoder.GeneratedQRCodeLigacaoCelular("+55DDDNºTELEFONE");
            byte[] byteArray = GeneratorQRCoder.ImageToByte2(image);
            ViewBag.Message = byteArray;
            return View();
        }

        public IActionResult GeradorQRCOdeWhatsApp()
        {
            Image image = GeneratorQRCoder.GeneratedQRCodeWhatsApp("Mensagem a ser enviada no WhatsApp");
            byte[] byteArray = GeneratorQRCoder.ImageToByte2(image);
            ViewBag.Message = byteArray;
            return View();
        }
    }
}