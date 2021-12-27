using Domain.Models;

namespace Application.Interfaces
{
    public interface ILogInDbService
    {
        public void AddLog(Log model);
    }
}
