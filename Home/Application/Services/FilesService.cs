﻿using Application.Interfaces;
using Application.ViewModels;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
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

        public IQueryable<FileTransferViewModel> GetBlogs()
        {
            //all this code will be merged into 1 line
            //when we introduce AutoMapper
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

    }
}
