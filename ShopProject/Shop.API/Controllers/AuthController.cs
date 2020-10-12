using System.Threading.Tasks;
using AutoMapper;

using Microsoft.AspNetCore.Mvc;
using Shop.API.Domain.Models;
using Shop.API.Domain.Services;
using Shop.API.Resources;

namespace Shop.API.Controllers
{
    [Route("/api/[controller]")]
    public class AuthController : Controller
    {
        
        private readonly IAuthenticationService userService;
        private readonly IMapper mapper;

        public AuthController(IAuthenticationService userService,
                              IMapper mapper)
        {
            this.userService = userService;
            this.mapper = mapper;
        }


        [HttpPost]
        public async Task<IActionResult> Authenticate([FromBody] User user)
        {
            var authenticatedUser = await userService.AuthenticateAsync(user.Login, user.Password);
            var userResource = mapper.Map<User, UserResource>(authenticatedUser.User);
            
            return Ok(userResource);
        }
    }
}