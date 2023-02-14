using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tasks.Models;
using Tasks.Repositories.Interfaces;

namespace Tasks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUser _userRepositorie;
        public UserController(IUser userRepositorie)
        {
            _userRepositorie = userRepositorie;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserModel>>> GetAllUsers()
        {
            List<UserModel> users = await _userRepositorie.SearchAllUsers();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<UserModel>>> GetById(Guid id)
        {
            UserModel user = await _userRepositorie.SearchUserById(id);
            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<List<UserModel>>> CreateNewUser([FromBody] UserModel newUser)
        {
            UserModel user = await _userRepositorie.AddNewUser(newUser);
            return Ok(user);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<UserModel>>> UpdateUserById(Guid id, [FromBody] UserModel newUser)
        {
            UserModel user = await _userRepositorie.UpdateUser(newUser, id);
            return Ok(user);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<UserModel>>> DeleteUserById(Guid id)
        {
            bool response = await _userRepositorie.DeleteUser(id);
            return Ok(response);
        }
    }
}
