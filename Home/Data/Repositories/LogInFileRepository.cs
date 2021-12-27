using Data.Context;
using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Repositories
{
    public class LogInFileRepository : ILogInFilesRepository
    {
        private FileTransferContext context;
        public LogInFileRepository(FileTransferContext _fileTransferContext)
        {
            context = _fileTransferContext;
        }

        public void AddLog(Log log)
        {
            throw new NotImplementedException();
        }

        public Log GetLog(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Log> GetLogs()
        {
            throw new NotImplementedException();
        }
    }
}
