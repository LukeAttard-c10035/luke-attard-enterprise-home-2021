using Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Interfaces
{
    public interface IFilesService
    {
        public IQueryable<FileTransferViewModel> GetFileTransfers();
        public FileTransferViewModel GetFileTransfer(int id);
        public void AddFileTransfer(AddFileTransferViewModel model);
    }
}
