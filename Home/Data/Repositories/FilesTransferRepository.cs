using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Repositories
{
    public class FilesTransferRepository : IFilesTransferRepository
    {
        public void AddFileTransfer(FileTransfer file)
        {
            throw new NotImplementedException();
        }

        public FileTransfer GetFileTransfer(int id)
        {
            throw new NotImplementedException();
        }

        public void EncryptFileTransfer(FileTransfer f)
        {
            throw new NotImplementedException();
        }

        public IQueryable<FileTransfer> GetFileTransfers()
        {
            throw new NotImplementedException();
        }

    }
}
