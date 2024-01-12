using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Core.DTOs;
using WebApi.Core.Models;

namespace WebApi.Core.Services
{
    public interface IPublisherService : IService<Publisher>
    {
        string GeneratePasswordHash(string publisherName, string password);
        PublisherDto FindPublisher(string publisherName, string password);
        AuthResponseDto Login(AuthRequestDto request);
    }
}
