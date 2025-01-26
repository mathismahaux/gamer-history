using Application.UseCases.User;
using Application.UseCases.User.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace GamerHistory.Controllers.Session;

[ApiController]
[Route("sessions")]
public class SessionController : ControllerBase
{
    private readonly UseCaseLogin _useCaseLogin;
    private readonly UseCaseLogout _useCaseLogout;

    public SessionController(UseCaseLogin useCaseLogin, UseCaseLogout useCaseLogout)
    {
        _useCaseLogin = useCaseLogin;
        _useCaseLogout = useCaseLogout;
    }
    
    [HttpPost]
    public ActionResult<Domain.Session> Login([FromBody] DtoInputLogin input)
    {
        try
        {
            var token = _useCaseLogin.Execute(input);
            
            Response.Cookies.Append("jwt_token", token, new CookieOptions
            {
                HttpOnly = true, 
                Secure = true, 
                Path = "/",
                SameSite = SameSiteMode.Strict,
                Expires = DateTime.UtcNow.AddMinutes(30) 
            });
            
            return Ok(new { Token = token });
        }
        catch (UnauthorizedAccessException)
        {
            return Unauthorized("Invalid username or password.");
        }
        catch (InvalidOperationException ex)
        {
            return Conflict(ex.Message);
        }
    }
    
    [HttpDelete]
    public ActionResult Logout()
    {
        try
        {
            if (User.Identity is { IsAuthenticated: true } && int.TryParse(User.FindFirst("id")?.Value, out var userId))
            {
                _useCaseLogout.Execute(userId);

                Response.Cookies.Delete("jwt_token");

                return Ok(new { message = "Successfully logged out" });
            }
            else
            {
                return Unauthorized(new { message = "User is not logged in."});
            }
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}