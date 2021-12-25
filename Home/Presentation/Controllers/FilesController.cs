using Application.Interfaces;
using Application.Services;
using Application.ViewModels;
using Ionic.Zip;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;

namespace Presentation.Controllers
{
    [Authorize]
    public class FilesController : Controller
    {
        private IFilesService filesService;
        private IWebHostEnvironment webHostEnvironment;
        public FilesController(IFilesService _filesService, IWebHostEnvironment _webHostEnvironment)
        {
            filesService = _filesService;
            webHostEnvironment = _webHostEnvironment;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(AddFileTransferViewModel model, IFormFile file)
        {
            if (string.IsNullOrEmpty(model.Title))
            {
                // add the others later
                ViewBag.Error = "Title should not be left empty";
                return View();
            }
            else
            {
                //start uploading the file
                if (file != null)
                {
                    //1. to give the file a unique name
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    //2. to read the absolute path where we are going to save the file
                    string absolutePath = webHostEnvironment.WebRootPath + "\\files\\" + fileName;

                    //3. we save the physical file on the web server
                    using (ZipFile zip = new ZipFile())
                    {
                        if (!String.IsNullOrEmpty(model.Password))
                        {
                            zip.Password = model.Password;
                        }
                        zip.AddFile(absolutePath);
                        zip.Save(fileName);
                    }
                    model.FilePath = @"\files\" + fileName;
                }
                filesService.AddFileTransfer(model);
                ViewBag.Message = "FileTransfer saved successfully";
            }
            return RedirectToAction("Create");
        }
    }
}
/*
using (FileStream fs = new FileStream(absolutePath, FileMode.CreateNew, FileAccess.Write))
{
    file.CopyTo(fs);
    fs.Close(); //flushes the data into the recipient file
}*/