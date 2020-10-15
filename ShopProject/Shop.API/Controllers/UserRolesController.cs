using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Shop.API.Domain.Models;
using Shop.API.Domain.Services;
using Shop.API.Extensions;
using Shop.API.Resources;

namespace Shop.API.Controllers
{
    [Route("/api/[controller]")]
    public class UserRolesController : Controller
    {
        private readonly IMapper mapper;
        private readonly IUserRoleService userRoleService;
        public UserRolesController(IUserRoleService userRoleService, IMapper mapper)
        {
            this.mapper = mapper;
            this.userRoleService = userRoleService;
        }

        [HttpPost]
        [Route("setrole")]
        public async Task<IActionResult> SetRole([FromBody]SaveUserRoleResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var userResponse = await userRoleService.SetUserRoleAsync(resource.UserId, resource.RoleId);
           //var userResource = mapper.Map<User, UserResource>(userResponse.User);
            return Ok(userResponse);
        }


        [HttpDelete]
        [Route("deleterole/{id}")]
        public async Task<IActionResult> DeleteRole(int id, [FromBody]SaveUserRoleResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var userResponse = await userRoleService.DeleteRoleAsync(id, resource.RoleId);
           //var userResource = mapper.Map<User, UserResource>(userResponse.User);
            return Ok(userResponse);
        }
    }
}