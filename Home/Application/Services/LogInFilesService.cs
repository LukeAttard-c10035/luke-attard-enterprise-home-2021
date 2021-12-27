using Application.Interfaces;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Application.Services
{
    public class LogInFilesService : ILogService
    {
        private ILogInFilesRepository logRepo;
        private IWebHostEnvironment webHostEnvironment;
        public LogInFilesService(ILogInFilesRepository _logRepo, IWebHostEnvironment _webHostEnvironment)
        {
            logRepo = _logRepo;
            webHostEnvironment = _webHostEnvironment;
        }

        public void AddLog(Log model)
        {

            string path = webHostEnvironment.WebRootPath + "\\logs\\logs.txt";
            // This text is added only once to the file.
            if (!File.Exists(path))
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine($"User: {model.UserEmail} IP: {model.IP} FileTransfer at: {model.Created}");
                }
            }
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine($"User: {model.UserEmail} IP: {model.IP} FileTransfer at: {model.Created}");
            }
        }
    }
}
