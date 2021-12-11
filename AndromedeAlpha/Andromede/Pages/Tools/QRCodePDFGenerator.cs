/*
*
* (c) 2021 Copyright Andromede
* Unauthorized use and disclosure strictly forbidden
*
*/

using System.IO;
using QuickResponseCodeManager;
using PdfSharp.Pdf;
using PdfSharp.Drawing;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace Andromede.Pages.Tools
{
    public static class QRCodePDFGenerator
    {
        public static byte[] GenerateNormalQRCodePdf(string iLink)
        {
            int anInitialHeight = 120;
            int aMaximalHeight = 780;
            int aShiftHeight = 140;
            int anInitialWidth = 40;
            int aMaximalWidth = 430;
            int aShiftWidth = 130;

            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            MemoryStream aQRCodeStream = new MemoryStream(QRCodeManager.GenerateQRCode(iLink, 10));

            Image aQRCodeToResize = Image.FromStream(aQRCodeStream);
            XImage aQRCodeAsXImage = XImage.FromStream(ResizeImage(aQRCodeToResize, 175, 175));
            XImage aLogoAsXImage = XImage.FromFile("wwwroot/img/andromede_white_bg.png");
            PdfDocument aDocument = new PdfDocument();

            PdfPage aPage = aDocument.AddPage();

            XGraphics aGfx = XGraphics.FromPdfPage(aPage);

            aGfx.DrawImage(aLogoAsXImage, new XPoint(115, 0));

            for (int aHeight = anInitialHeight; aHeight < aMaximalHeight; aHeight += aShiftHeight)
            {
                for (int aWidth = anInitialWidth; aWidth <= aMaximalWidth; aWidth += aShiftWidth)
                {
                    aGfx.DrawImage(aQRCodeAsXImage, new XPoint(aWidth, aHeight));
                }
            }

            MemoryStream aPdfStream = new MemoryStream();
            aDocument.Save(aPdfStream);
            aDocument.Close();


            return aPdfStream.ToArray();
        }

        public static Stream ResizeImage(Image iImage, int iWidth, int iHeight)
        {
            var aDestinationRectangle = new Rectangle(0, 0, iWidth, iHeight);
            var aDestinationImage = new Bitmap(iWidth, iHeight);

            aDestinationImage.SetResolution(iImage.HorizontalResolution, iImage.VerticalResolution);

            using (var aGraphics = Graphics.FromImage(aDestinationImage))
            {
                aGraphics.CompositingMode = CompositingMode.SourceCopy;
                aGraphics.CompositingQuality = CompositingQuality.HighQuality;
                aGraphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                aGraphics.SmoothingMode = SmoothingMode.HighQuality;
                aGraphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var aWrapMode = new ImageAttributes())
                {
                    aWrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    aGraphics.DrawImage(iImage, aDestinationRectangle, 0, 0, iImage.Width, iImage.Height, GraphicsUnit.Pixel, aWrapMode);
                }
            }
            Stream aOutStream = new MemoryStream();
            aDestinationImage.Save(aOutStream, ImageFormat.Png);
            return aOutStream;
        }
    }
}
