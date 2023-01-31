using RosaryCrusadeAPI.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using RosaryCrusadeAPI.Services;
using RosaryCrusadeAPI.DTOs;
using RosaryCrusadeAPI.Models;

namespace RosaryCrusadeAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _repository;

        public UserController(IUserRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterUser(User user)
        {
            _repository.Register(user);
            return await _repository.SaveChangesAsync()
                    ? Ok("Usuario registrado com sucesso.")
                    : BadRequest("Erro ao registrar usuario.");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var user = await _repository.GetUser(id);
            return user != null
                    ? Ok(user)
                    : NotFound("Usuario não encontrado");
        }

        [HttpDelete("{id}")]
        [Route("delete")]
        public async Task<IActionResult> DeleteUser (Guid id)
        {
            var user = await _repository.GetUser(id);
            if(user == null) return NotFound("Usuário não encontrado");
            _repository.DeleteUser(user);
            return await _repository.SaveChangesAsync()
                    ? Ok("Usuário deletado com sucesso!")
                    : BadRequest("Não foi possível deletar usuário!");
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Authenticate(UserDTO model)
        {
            var userContext = new User
            {
                Email = model.Email,
                Password = model.Password,
            };

            var user = _repository.Get(userContext.Email, userContext.Password);
            if (user == null) return NotFound(new { message = "Usuário ou senha inválidos" });
            var token = TokenService.GenerateToken(user);
            user.Password = "";
            return new
            {
                user = user,
                token = token,
            };
        }

        [HttpGet]
        [Route("anonymous")]
        [AllowAnonymous]
        public string Anonymous() => "Anônimo";

        [HttpGet]
        [Authorize]
        public string Authenticated() => String.Format("Autenticado - {0}", User.Identity.Name);
    }
}