using Adform_Todo.Common.Contracts;
using Adform_Todo.Common.Dtos;
using Adform_Todo.Common.Helpers;
using Adform_Todo.Common.Models;
using Adform_ToDo.Common.Constants;
using Adform_ToDo.DAL.DbContexts;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Adform_ToDo.CommonLib.Contracts.DbOps
{
    /// <summary>
    /// Performs database operations related to User Object.
    /// </summary>
    public class UserDal : IUserDal
    {
        private readonly ToDoDbContext _toDoDbContext;

        private readonly IMapper _mapper;

        public UserDal(ToDoDbContext toDoDbContext, IMapper mapper)
        {
            _mapper = mapper;
            _toDoDbContext = toDoDbContext;
        }

        /// <summary>
        /// Authenticate user.
        /// </summary>
        /// <param name="userName">Username</param>
        /// <param name="password">password</param>
        /// <returns>Returns UserId</returns>
        public async Task<UserDto> AuthenticateUser(string userName, string password)
        {
            password = CommonHelper.EncodePasswordToBase64(password);
            UserEntity user = await _toDoDbContext.Users
                .Where(p => p.UserName.ToLower() == userName.ToLower() && p.Password == password).FirstOrDefaultAsync();
            if (user == null)
            {
                return null;
            }
            return _mapper.Map<UserDto>(user);
        }

        /// <summary>
        /// Get specific user.
        /// </summary>
        /// <param name="userId">userId</param>
        /// <returns>Returns UserDto</returns>
        public async Task<UserDto> GetById(long userId)
        {
            UserEntity user = await _toDoDbContext.Users.Where(p => p.UserId == userId).SingleOrDefaultAsync();
            if (user == null)
            {
                return null;
            }
            return _mapper.Map<UserDto>(user);
        }
        /// <summary>
        /// Register user
        /// </summary>
        /// <param name="userDto"></param>
        /// <returns> Success/Failure result</returns>
        public async Task<bool> RegisterUser(CreateUserDto userDto)
        {
            if (userDto.Password != null)
            {
                userDto.Password = CommonHelper.EncodePasswordToBase64(userDto.Password);
            }

            UserEntity userName = await _toDoDbContext.Users
                .Where(p => p.UserName.ToLower() == userDto.UserName.ToLower()).FirstOrDefaultAsync();

            if (userName != null)
            {
                return false;
            }
            UserEntity user = _mapper.Map<UserEntity>(userDto);
            if (user.UserRole == null)
            {
                user.UserRole = Constants.User;
            }
            _toDoDbContext.Users.Add(user);
            if (await _toDoDbContext.SaveChangesAsync() == 1)
            {
                return true;
            }
            return false;
        }
    }
}
