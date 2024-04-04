using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Business.DTOs;
using Business.Interfaces;
using Core.Entities;
using Core.Interfaces;

namespace Business.Services
{
    public class UserService : IUserService
    {
        private IUserRepo _userRepo;
        private IMapper _mapper;
        private readonly IPasswordHasher _passwordHasher;
        public UserService(IUserRepo userRepo, IMapper mapper, IPasswordHasher passwordHasher)
        {
            _userRepo = userRepo;
            _mapper = mapper;
            _passwordHasher = passwordHasher;
        }

        public bool CheckMail(string mail)
        {
            throw new NotImplementedException();
        }

        public UserReadDTO CreateNewUser(UserCreateDTO userCreateDTO)
        {
            // Get the highest tag for the given username
            int highestTag = _userRepo.GetHighestTagForUsername(userCreateDTO.UserName);
            int newUserTag = highestTag + 1; // Determine the new user's tag

            // Hash the user's password
            var passwordHash = _passwordHasher.HashPassword(userCreateDTO.Password);

            // Create a new User entity (or similar) from the UserCreateDTO
            var user = new User
            {
                UserName = userCreateDTO.UserName,
                Email = userCreateDTO.Email,
                Password = passwordHash, // Use the hashed password
                Tag = $"#{newUserTag:D4}", // Format the tag as a string, e.g., "#0001"
                Avatar = userCreateDTO.Avatar,
            };

            // Persist the new user entity to the database
            var createdUser = _userRepo.CreateNewUser(user);

            var userReadDTO = _mapper.Map<UserReadDTO>(createdUser);

            return userReadDTO;
        }


        public IEnumerable<UserReadDTO> GetAllUsers(GetAllParams options)
        {
            throw new NotImplementedException();
        }

        public UserReadDTO? GetOneUser(Guid userId)
        {
            throw new NotImplementedException();
        }

        public UserReadDTO? Login(string email, string userInputPassword)
        {
            var user = _userRepo.FindByEmail(email);
            if (user != null && _passwordHasher.VerifyPassword(user.Password, userInputPassword))
            {
                return _mapper.Map<User, UserReadDTO>(user);
            }
            return null;
        }
    }
}
