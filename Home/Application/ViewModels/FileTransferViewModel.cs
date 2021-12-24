﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Application.ViewModels
{
    public class FileTransferViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Message { get; set; } 
        public string Password { get; set; } 
        public string UserEmail { get; set; }
        public string Email { get; set; }
        public string FilePath { get; set; }
        public string Link { get; set; }
    }
}
