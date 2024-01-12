using AutoMapper;
using DotNet.API.Abstraction;
using DotNet.Core.DTOs;
using DotNet.Core.Models;
using DotNet.Core.Repositories;
using DotNet.Core.Services;
using DotNet.Core.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DotNet.Service.Services
{
    public class UserService : Service<User>, IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IJwtAuthenticationManager _jwtAuthenticationManager;

        public UserService(IGenericRepository<User> repository, IUnitOfWork unitOfWork, IUserRepository userRepository, IMapper mapper, IJwtAuthenticationManager jwtAuthenticationManager) : base(repository, unitOfWork)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _jwtAuthenticationManager = jwtAuthenticationManager;
        }
        public string GeneratePasswordHash(string userName, string password) {

            if (string.IsNullOrEmpty(userName)) {
                 throw new ArgumentNullException(nameof(userName));
            }
            if (string.IsNullOrEmpty(password))
            {
                throw new ArgumentNullException(nameof(password));
            }

            byte[] userBytes = Encoding.UTF8.GetBytes(userName);
            string userByteString = Convert.ToBase64String(userBytes);
            string smallByteString = $"{userByteString.Take(2)}.{userByteString.Reverse().Take(2)}";
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

        public UserDto FindUser(string userName, string password)
        {
            string passHashed = GeneratePasswordHash(userName, password);
            var user =  _userRepository.Where(x => x.UserName == userName && x.Password == passHashed).FirstOrDefault();
            var userDto = _mapper.Map<UserDto>(user);
            return userDto;
        }

        public AuthResponseDto Login(AuthRequestDto request)
        {
            AuthResponseDto responseDto = new AuthResponseDto();
            UserDto user = FindUser(request.UserName, request.Password);
            responseDto = _jwtAuthenticationManager.Authenticate(request.UserName, request.Password);
            responseDto.User = user;

            return responseDto;
        }
    }
}
