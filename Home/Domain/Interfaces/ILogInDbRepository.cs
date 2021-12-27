using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Interfaces
{
    public interface ILogInDbRepository
    {
        public void AddLog(Log log);
        public Log GetLog(int id);
        public IQueryable<Log> GetLogs();
    }
}
