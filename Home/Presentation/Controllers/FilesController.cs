using Application.Interfaces;
using Application.ViewModels;
using Ionic.Zip;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using RestSharp.Authenticators;
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

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(AddFileTransferViewModel model, IFormFile file)
        {
            try
            {
                if (string.IsNullOrEmpty(model.Title))
                {
                    // add the others later
                    ViewBag.Error = "Title should not be left empty";
                    return View();
                }
                else
                {
                    if (file != null)
                    {
                        string fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
                        string absolutePath = webHostEnvironment.WebRootPath + "\\files\\" + fileName;
                        using (FileStream fs = new FileStream(absolutePath, FileMode.CreateNew, FileAccess.Write))
                        {
                            file.CopyTo(fs);
                            fs.Close();
                        }
                        using (ZipFile zip = new ZipFile())
                        {
                            if (!String.IsNullOrEmpty(model.Password))
                            {
                                zip.Password = model.Password;  
                            }
                            zip.AddFile(absolutePath);
                            zip.Save(absolutePath + ".zip");
                        }
                        model.FilePath = @"\files\" + fileName+".zip";
                    }
                    filesService.AddFileTransfer(model);
                    ViewBag.Message = "FileTransfer saved successfully";

                    RestClient client = new RestClient();
                    client.BaseUrl = new Uri("https://api.mailgun.net/v3");
                    client.Authenticator =
                    new HttpBasicAuthenticator("api",
                                               "fd0eaf4bfcca4d975526149edb77dfac-1831c31e-170630e6");
                    RestRequest request = new RestRequest();
                    request.AddParameter("domain", "sandboxee4e22a940884c75a75afbd6573cd775.mailgun.org", ParameterType.UrlSegment);
                    request.Resource = "{domain}/messages";
                    request.AddParameter("from", "mailgun@sandboxee4e22a940884c75a75afbd6573cd775.mailgun.org");
                    request.AddParameter("to", model.Email);
                    request.AddParameter("subject", model.Title);
                    request.AddParameter("text", model.Message);
                    request.AddParameter("text", "https://" + HttpContext.Request.Host + "/" + model.FilePath);
                    request.AddParameter("text", $"Password: {model.Password}");
                    request.Method = Method.POST;
                    client.Execute(request);
                }
            } catch (Exception ex)
            {
                ViewBag.Error = "FileTransfer was not saved - " + ex.Message;
            }
            return RedirectToAction("Create");
        }
    }
}