///*
//*
//* (c) 2021-2021 Copyright Andromede
//* Unauthorized use and disclosure strictly forbidden
//*
//*/

//using Microsoft.AspNetCore.Hosting;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.RazorPages;
//using System.IO;
//using QuickResponseCodeManager;
//using PdfSharp.Pdf;
//using PdfSharp.Drawing;
//using DatabaseConnection;
//using Blazored.SessionStorage;
//using Microsoft.AspNetCore.Authorization;
//using System.Drawing;
//using System.Drawing.Drawing2D;
//using System.Drawing.Imaging;
//using Microsoft.AspNetCore.Components;

//public class DownloadModel : PageModel
//{
//    [Parameter]
//    public int RestorerId { get; set; }

//    private readonly IWebHostEnvironment _env;
//    private readonly IRestorerRepository _restorerRepository;

//    public DownloadModel(IWebHostEnvironment env, IRestorerRepository restorerRepository)
//    { 
//        _env = env;
//        _restorerRepository = restorerRepository;
//    }

//    public IActionResult OnGet()
//    {
//        byte[] aCardPdf = GenerateNormalQRCodePdf();
//        return File(aCardPdf, "application/force-download", "test.pdf");
//    }

    
//}
