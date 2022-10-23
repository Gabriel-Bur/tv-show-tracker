using Api.DTOs.Request.User;
using Api.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Api.Endpoint
{
    public class UserEndpoint : IEndpoint
    {
        public void DefineEndpoints(WebApplication app)
        {
            app.MapPost("/user/register", Register)
                .AllowAnonymous()
                .Produces(201)
                .Produces(400);
            
            app.MapPost("/user/login", Login)
                .AllowAnonymous()
                .Produces(200)
                .Produces(401);
        }

        public void DefineServices(IServiceCollection services)
        {
        }

        #region Methods
        internal async Task<IResult> Register(
            UserManager<IdentityUser> usrMgr, UserRegistrationRequest userRegistration)
        {
            var usrIdentity = new IdentityUser() { UserName = userRegistration.UserName, Email = userRegistration.Email };
            var result = await usrMgr.CreateAsync(usrIdentity, userRegistration.Password);

            return result.Succeeded ? Results.Created($"/user", result) : Results.BadRequest(result.Errors);
        }
        internal async Task<IResult> Login(
            IConfiguration configuration, UserManager<IdentityUser> usrMgr, UserLoginRequest userLogin)
        {
            var usrIdentity = await usrMgr.FindByEmailAsync(userLogin.Email);
            bool isValidPwd = await usrMgr.CheckPasswordAsync(usrIdentity, userLogin.Password);

            if (usrIdentity is not null && isValidPwd)
            {
                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]));
                var SigningCredentials = new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(signingCredentials: SigningCredentials, expires: DateTime.Now.AddMinutes(10));
                var stringToken = new JwtSecurityTokenHandler().WriteToken(token);

                return Results.Ok(stringToken);
            }
            
            return Results.Unauthorized();
        }

        #endregion

    }
}
