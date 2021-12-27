using Application.Interfaces;
using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services
{
    public class LogInFilesService : ILogInFilesService
    {
        private ILogInFilesRepository logRepo;
        public LogInFilesService(ILogInFilesRepository _logRepo)
        {
            logRepo = _logRepo;
        }

        public void AddLog(Log model)
        {
        }
    }
}
