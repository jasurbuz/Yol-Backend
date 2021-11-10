using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yol.Data.Models;
using Yol.Data.Models.Indentity;

namespace Yol.Services.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        Task Save();

        Task<string> SaveFileAsync(IFormFile file, string folder = "Images");

        void DeleteFile(string fileName, string folder = "Images");
        IGenericRepository<Company> Companies { get; }
        IGenericRepository<Road> Roads { get; }
        IGenericRepository<Coordinate> Coordinates { get; }
        IGenericRepository<CoordinateValue> Values { get; }
        IGenericRepository<Application> Applications { get; }
        IGenericRepository<News> News { get; }
        IGenericRepository<Admin> Admins { get; }
        IGenericRepository<Image> Images { get; }

    }
}
