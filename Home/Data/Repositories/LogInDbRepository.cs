using Data.Context;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repositories
{
    public class LogInDbRepository : ILogInRepository
    {
        private FileTransferContext context;
        public LogInDbRepository(FileTransferContext _fileTransferContext)
        {
            context = _fileTransferContext;
        }
    }
}
