/*
*
* (c) 2021-2021 Copyright Andromede
* Unauthorized use and disclosure strictly forbidden
*
*/

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.IO;
using QuickResponseCodeManager;
using PdfSharp.Pdf;
using PdfSharp.Drawing;
using DatabaseConnection;
using Blazored.SessionStorage;
using Microsoft.AspNetCore.Authorization;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

public class DownloadModel : PageModel
{
    private readonly IWebHostEnvironment _env;
    private readonly IRestorerRepository _restorerRepository;

    public DownloadModel(IWebHostEnvironment env, IRestorerRepository restorerRepository)
    { 
        _env = env;
        _restorerRepository = restorerRepository;
    }

    public IActionResult OnGet()
    {
        byte[] aCardPdf = GenerateNormalQRCodePdf();
        return File(aCardPdf, "application/force-download", "test.pdf");
    }

    public byte[] GenerateNormalQRCodePdf()
    {
        //string aUserCardLink = getUserCardLink(User.Identity.Name);
        //string aUserCardLink = $"localhost:5001/Cards/{@RouteData.Values["RestorerId"]}.pdf";
        string aUserCardLink = $"localhost:5001/Cards/11111111111111.pdf";
        //Include the siret number of the authenticated restorer
        int anInitialHeight = 75;
        int aMaximalHeight = 750;
        int aShiftHeight = 125;
        int anInitialWidth = 40;
        int aMaximalWidth = 430;
        int aShiftWidth = 130;

        System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

        MemoryStream aQRCodeStream = new MemoryStream(QRCodeManager.GenerateQRCode(aUserCardLink, 5));

        Image aQRCodeToResize = Image.FromStream(aQRCodeStream);
        XImage aQRCodeAsXImage = XImage.FromStream(ResizeImage(aQRCodeToResize,175,175));
        XImage aLogoAsXImage = XImage.FromFile("wwwroot/img/andromede_white_bg.png");
        PdfDocument aDocument = new PdfDocument();

        PdfPage aPage = aDocument.AddPage();

        XGraphics aGfx = XGraphics.FromPdfPage(aPage);

        aGfx.DrawImage(aLogoAsXImage,   new XPoint(100, 0));

        for(int aHeight = anInitialHeight; aHeight < aMaximalHeight; aHeight += aShiftHeight)
        {
            for(int aWidth = anInitialWidth; aWidth <= aMaximalWidth; aWidth += aShiftWidth)
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

    private string getUserCardLink(string iId)
    {
        Restorer aCurrentRestorer = _restorerRepository.GetRestorerWithId(int.Parse(iId));
        return $"localhost:5001/Cards/{aCurrentRestorer.RestaurantSiretNumber}.pdf";
    }
}
