using E_ShopPlatform.API.Models;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Web;

namespace E_ShopPlatform.API.Helpers
{
    public static class ReceiptHelper
    {
        public static string Create(CreatePaymentModel payment)
        {
            PdfDocument document = new PdfDocument();
            PdfPage page = document.AddPage();
            XGraphics gfx = XGraphics.FromPdfPage(page);

            XFont fontBold = new XFont("Verdana", 18, XFontStyle.Bold);
            XFont font = new XFont("Verdana", 18, XFontStyle.Regular);
            gfx.DrawString("Receipt", fontBold, XBrushes.Black, 
                new XRect(0, -350, page.Width, page.Height), XStringFormats.Center);
            gfx.DrawString("Amount: " + payment.Amount.ToString(), font, XBrushes.Black, 
                new XRect(0, -300, page.Width, page.Height), XStringFormats.Center);
            gfx.DrawString("Payment date: " + payment.CreatedDate.ToString("dd-MM-yyy HH:mm:ss"), font, XBrushes.Black, 
                new XRect(0, -275, page.Width, page.Height), XStringFormats.Center);
            gfx.DrawString("Client: " + string.Format("{0} {1}", payment.CustomerFirstName, payment.CustomerLastName), font, XBrushes.Black, 
                new XRect(0, -250, page.Width, page.Height), XStringFormats.Center);

            MemoryStream stream = new MemoryStream();
            document.Save(stream, false);
            byte[] bytesPDF = stream.ToArray();

            return Convert.ToBase64String(bytesPDF);
        }
    }
}