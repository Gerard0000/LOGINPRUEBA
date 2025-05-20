using LOGINPRUEBA.web.Data;
using LOGINPRUEBA.web.Data.Entities;
using LOGINPRUEBA.web.Enums;
using LOGINPRUEBA.web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LOGINPRUEBA.web.Helpers;

public class UserHelper(DataContext dataContext, UserManager<User> userManager, RoleManager<IdentityRole> roleManager, SignInManager<User> signInManager) : IUserHelper
{
    private readonly DataContext _dataContext = dataContext;
    private readonly UserManager<User> _userManager = userManager;
    private readonly RoleManager<IdentityRole> _roleManager = roleManager;
    private readonly SignInManager<User> _signInManager = signInManager;

    public async Task<IdentityResult> AddUserAsync(User user, string password)
    {
        return await _userManager!.CreateAsync(user, password);
    }

    public async Task AddUserToRoleAsync(User user, UserType userType)
    {
        await _userManager!.AddToRoleAsync(user, userType.ToString());
    }

    public async Task CheckRoleAsync(string roleName)
    {
        bool roleExists = await _roleManager!.RoleExistsAsync(roleName);
        if (!roleExists)
        {
            await _roleManager.CreateAsync(new IdentityRole
            {
                Name = roleName
            });
        }
    }

    public async Task<User> GetUserAsync(string username)
    {
        var user = await _dataContext.Users.FirstOrDefaultAsync(x => x.UserName == username);
        return user!;
    }

    public async Task<bool> IsUserInRoleAsync(User user, string roleName)
    {
        return await _userManager!.IsInRoleAsync(user, roleName);
    }

    public async Task<SignInResult> LoginAsync(LoginViewModel model)
    {
        return await _signInManager.PasswordSignInAsync(
            model.Username!,
            model.Password!,
            model.RememberMe,
            //TODO: CUANTOS INTENTOS SE BLOQUEA LA CUENTA
            false);
    }

    public async Task LogoutAsync()
    {
        await _signInManager.SignOutAsync();
    }
}