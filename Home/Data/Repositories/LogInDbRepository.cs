using Data.Context;
using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Repositories
{
    public class LogInDbRepository : ILogInDbRepository
    {
        private FileTransferContext context;
        public LogInDbRepository(FileTransferContext _fileTransferContext)
        {
            context = _fileTransferContext;
        }

        public void AddLog(Log log)
        {
            context.Log.Add(log);
            context.SaveChanges();
        }

        public Log GetLog(int id)
        {
            return context.Log.SingleOrDefault(log => log.Id == id);
        }

        public IQueryable<Log> GetLogs()
        {
            return context.Log;
        }
    }
}
