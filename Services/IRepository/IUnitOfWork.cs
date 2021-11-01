using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yol.Services.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        Task Save();

        Task<string> SaveFileAsync(IFormFile file, string folder = "Images");

        void DeleteFile(string fileName, string folder = "Images");
    }
}
