﻿using Application.Interfaces;
using Application.ViewModels;
using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Services
{
    public class LogInDbService : ILogService
    {
        private ILogInDbRepository logRepo; 
        public LogInDbService(ILogInDbRepository _logRepo)
        {
            logRepo = _logRepo;
        }

        public void AddLog(Log model)
        {
            logRepo.AddLog(new Log()
            {
                Created = DateTime.Now,
                IP = model.IP,
                UserEmail = model.UserEmail,
            });
        }
    }
}
