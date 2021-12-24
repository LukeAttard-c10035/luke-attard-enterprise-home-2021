using Data.Context;
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
        private FileTransferContext context;

        public FilesTransferRepository(FileTransferContext _fileTransferContext)
        {
            context = _fileTransferContext;
        }
        public void AddFileTransfer(FileTransfer ft)
        {
            context.FileTransfer.Add(ft);
            context.SaveChanges();
        }

        public FileTransfer GetFileTransfer(int id)
        {
            return context.FileTransfer.SingleOrDefault(ft => ft.Id == id);
        }

        public void EncryptFileTransfer(FileTransfer f)
        {
            throw new NotImplementedException();
        }

        public IQueryable<FileTransfer> GetFileTransfers()
        {
            return context.FileTransfer;
        }

    }
}
