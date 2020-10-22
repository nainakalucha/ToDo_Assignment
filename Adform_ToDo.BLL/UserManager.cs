using Adform_Todo.Common.Contracts;
using Adform_Todo.Common.Dtos;
using System.Threading.Tasks;

namespace Adform_ToDo.BL
{
    /// <summary>
    /// This class implements Buisness level logic and calls Data access layer for DB Operations.
    /// </summary>
    public class UserManager : IUserManager
    {
        private readonly IUserDal _userDal;

        public UserManager(IUserDal userDbOps)
        {
            _userDal = userDbOps;
        }

        /// <summary>
        /// Returns UserId on successful authentication else returns null.
        /// </summary>
        /// <param name="userName">userName</param>
        /// <param name="password">password</param>
        /// <returns>Returns UserId.</returns>
        public async Task<UserDto> AuthenticateUser(string userName, string password)
        {
            return await _userDal.AuthenticateUser(userName, password);
        }

        /// <summary>
        /// Returns userId of user if found else returns null.
        /// </summary>
        /// <param name="userId">userId</param>
        /// <returns>Returns UserDto.</returns>
        public async Task<UserDto> GetById(long userId)
        {
            return await _userDal.GetById(userId);
        }

        /// <summary>
        /// Registers User. 
        /// </summary>
        /// <param name="userDto">FirstName,LastName,UserName,Password</param>
        /// <returns>true on registration success else false. </returns>
        public async Task<bool> RegisterUser(CreateUserDto userDto)
        {
            return await _userDal.RegisterUser(userDto);
        }
    }
}