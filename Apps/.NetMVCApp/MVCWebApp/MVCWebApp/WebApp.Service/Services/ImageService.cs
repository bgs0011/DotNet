using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Core.Models;
using WebApp.Core.Repositories;
using WebApp.Core.Services;
using WebApp.Core.UnitOfWorks;

namespace WebApp.Service.Services
{
    public class ImageService : Service<Image>, IImageService
    {
        public ImageService(IGenericRepository<Image> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
        }
    }
}
