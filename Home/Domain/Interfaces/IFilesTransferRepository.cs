using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Interfaces
{
    public interface IFilesTransferRepository
    {
        public void AddFileTransfer(FileTransfer file);
        public FileTransfer GetFileTransfer(int id);
        public void EncryptFileTransfer(FileTransfer f);
        public IQueryable<FileTransfer> GetFileTransfers();
    }
}
