using LOGINPRUEBA.web.Data.Entities;
using LOGINPRUEBA.web.Enums;
using LOGINPRUEBA.web.Models;
using Microsoft.AspNetCore.Identity;

namespace LOGINPRUEBA.web.Helpers;

public interface IUserHelper
{
    Task<User> GetUserAsync(string username);

    Task<IdentityResult> AddUserAsync(User user, string password);

    Task CheckRoleAsync(string roleName);

    Task AddUserToRoleAsync(User user, UserType userType);

    Task<bool> IsUserInRoleAsync(User user, string roleName);

    Task<SignInResult> LoginAsync(LoginViewModel model);

    Task LogoutAsync();
}