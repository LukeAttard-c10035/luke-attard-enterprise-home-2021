using Application.Interfaces;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services
{
    public class FilesService : IFilesService
    {
        private IFilesTransferRepository _filesTransferRepository;
        public FilesService(IFilesTransferRepository _ftRepo)
        {
            _filesTransferRepository = _ftRepo;
        }

    }
}
