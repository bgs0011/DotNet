using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using WebApi.Core.DTOs;
using WebApi.Core.Models;
using WebApi.Core.Repositories;
using WebApi.Core.Services;
using WebApi.Core.UnitOfWorks;
using WebApi.Services.Authorization.Abstraction;
using WebApi.Services.Helpers;

namespace WebApi.Services.Services
{
    public class PublisherService : Service<Publisher>, IPublisherService
    {
        private readonly IPublisherRepository _publisherRepository;
        private readonly IMapper _mapper;
        private readonly IJwtAuthenticationManager _jwtAuthenticationManager;


        public PublisherService(IGenericRepository<Publisher> repository, IUnitOfWork unitOfWork, IPublisherRepository publisherRepository, IMapper mapper, IJwtAuthenticationManager jwtAuthenticationManager) : base(repository, unitOfWork)
        {
            _publisherRepository = publisherRepository;
            _mapper = mapper;
            _jwtAuthenticationManager = jwtAuthenticationManager;
        }
        
        
        public string GeneratePasswordHash(string publisherName, string password)
        {

            if (string.IsNullOrEmpty(publisherName))
            {
                throw new ArgumentNullException(nameof(publisherName));
            }
            if (string.IsNullOrEmpty(password))
            {
                throw new ArgumentNullException(nameof(password));
            }

            byte[] publisherBytes = Encoding.UTF8.GetBytes(publisherName);
            string publisherByteString = Convert.ToBase64String(publisherBytes);
            string smallByteString = $"{publisherByteString.Take(2)}.{publisherByteString.Reverse().Take(2)}";
            byte[] smallBytes = Encoding.UTF8.GetBytes(smallByteString);
            byte[] passBytes = Encoding.UTF8.GetBytes(password);

            byte[] hashed = this.GenerateSaltedHash(passBytes, smallBytes);

            return Convert.ToBase64String(hashed);

        }

        private byte[] GenerateSaltedHash(byte[] plainText, byte[] salt)
        {
            HashAlgorithm algorithm = new SHA256Managed();

            byte[] plainTextWithSaltBytes =
              new byte[plainText.Length + salt.Length];

            for (int i = 0; i < plainText.Length; i++)
            {
                plainTextWithSaltBytes[i] = plainText[i];
            }
            for (int i = 0; i < salt.Length; i++)
            {
                plainTextWithSaltBytes[plainText.Length + i] = salt[i];
            }

            return algorithm.ComputeHash(plainTextWithSaltBytes);
        }

        public PublisherDto FindPublisher(string publisherName, string password)
        {
            string passHashed = GeneratePasswordHash(publisherName, password);
            var publisher = _publisherRepository.Where(x => x.PublisherName == publisherName && x.Password == passHashed).FirstOrDefault();
            var publisherDto = _mapper.Map<PublisherDto>(publisher);
            return publisherDto;
        }

        public Publisher UpdatePublisher(Publisher publisher , AuthRequestDto authRequestDto)
        {
            publisher.PublisherName=authRequestDto.PublisherName;
            publisher.Email = authRequestDto.Email;
            publisher.Password=GeneratePasswordHash(authRequestDto.PublisherName, authRequestDto.Password);

            return publisher;
        }

        public AuthResponseDto Login(AuthRequestDto request)
        {
            AuthResponseDto responseDto = new AuthResponseDto();
            PublisherDto publisherDto = FindPublisher(request.PublisherName, request.Password);
            responseDto = _jwtAuthenticationManager.Authenticate(request.PublisherName, request.Password);
            responseDto.Publisher = publisherDto;
            return responseDto;
        }
        
        public void SetArticleToUser(Publisher entity)
        {
            _publisherRepository.Update(entity);
        }
    }
}
