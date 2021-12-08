/*
*
* (c) 2021 Copyright Andromede
* Unauthorized use and disclosure strictly forbidden
*
*/

using QRCoder;
using System.Drawing;
using System.IO;

namespace QuickResponseCodeManager
{
    public class QRCodeManager
    {
        private static byte[] BitmapToBytes(Bitmap bitmap)
        {
            using (var stream = new MemoryStream())
            {
                bitmap.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                return stream.ToArray();
            }
        }
        
        public static byte[] GenerateQRCode(string link, int size)
        {
            QRCodeGenerator qrCodeGen = new QRCodeGenerator();
            QRCodeData qrData = qrCodeGen.CreateQrCode(link, QRCodeGenerator.ECCLevel.H);
            QRCode qrCode = new QRCode(qrData);
            return BitmapToBytes(qrCode.GetGraphic(size));
        }
    }
}
