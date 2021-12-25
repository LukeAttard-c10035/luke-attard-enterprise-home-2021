using Application.Interfaces;
using Application.ViewModels;
using Domain.Interfaces;
using ICSharpCode.SharpZipLib.Zip;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Application.Services
{
    public class FilesService : IFilesService
    {
        private IFilesTransferRepository ftRepo;
        public FilesService(IFilesTransferRepository _ftRepo)
        {
            ftRepo = _ftRepo;
        }
        public void AddFileTransfer(AddFileTransferViewModel model)
        {
            ftRepo.AddFileTransfer(new Domain.Models.FileTransfer()
            {
                Title = model.Title,
                FilePath = model.FilePath,
                Message = model.Message,
                Password = model.Password,
                UserEmail = model.UserEmail,
                Email = model.Email
            });
        }

        public FileTransferViewModel GetFileTransfer(int id)
        {
            var ft = ftRepo.GetFileTransfer(id);
            FileTransferViewModel model = new FileTransferViewModel()
            {
                Id = ft.Id,
                Title = ft.Title,
                FilePath = ft.FilePath,
                Password = ft.Password,
                Email = ft.Email,
                UserEmail = ft.UserEmail,
                Message = ft.Message,
            };
            return model;
        }

        public IQueryable<FileTransferViewModel> GetFileTransfers()
        {
            var list = from ft in ftRepo.GetFileTransfers()
                       orderby ft.Id descending
                       select new FileTransferViewModel()
                       {
                           Id = ft.Id,
                           Title = ft.Title,
                           FilePath = ft.FilePath,
                           Password = ft.Password,
                           Email = ft.Email,
                           UserEmail = ft.UserEmail,
                           Message = ft.Message,
                       };
            return list;
        }

        public ZipFile Compress(string DirectoryPath, string OutputFilePath, string password)
        {
            ZipFile zFile = null;
            string[] fileNames = Directory.GetFiles(DirectoryPath);
            using (ZipOutputStream OutputStream = new ZipOutputStream(File.Create(OutputFilePath)))
            {
                OutputStream.SetLevel(9);
                if (String.IsNullOrEmpty(password))
                {
                    OutputStream.Password = password;
                }
                foreach(string file in fileNames)
                {
                    ZipEntry entry = new ZipEntry(Path.GetFileName(file));
                    entry.DateTime = DateTime.Now;
                    OutputStream.PutNextEntry(entry);
                }

                OutputStream.Finish();
                OutputStream.Close();
            }
            return zFile;


        }
    }
}
