using Azure.Storage;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Andromede.Pages.Tools
{
    public class PdfFileManager : IPdfFileManager
    {
        private BlobServiceClient _client;
        private BlobContainerClient _containerClient;

        public PdfFileManager()
        {
            _client = new BlobServiceClient(Environment.GetEnvironmentVariable("ANDROMEDE_FILE_SYSTEM"));
            _containerClient = _client.GetBlobContainerClient("pdfcards");
        }

        public async Task UploadCard(string iFileName, Stream iFileStream)
        {
            var aBlobClient = _containerClient.GetBlobClient(iFileName);
            await aBlobClient.UploadAsync(iFileStream, new BlobUploadOptions
            {
                HttpHeaders = new BlobHttpHeaders
                {
                    ContentType = "application/pdf"
                }
            });
        }

        public async Task DeleteCard(string iFileName)
        {
            var aBlobClient = _containerClient.GetBlobClient(iFileName);
            await aBlobClient.DeleteIfExistsAsync();
        }
    }
}
