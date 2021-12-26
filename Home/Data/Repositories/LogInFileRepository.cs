using Data.Context;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repositories
{
    public class LogInFileRepository : ILogInRepository
    {
        private FileTransferContext context;
        public LogInFileRepository(FileTransferContext _fileTransferContext)
        {
            context = _fileTransferContext;
        }
    }
}
