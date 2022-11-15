using AppRosario.Models;
using AppRosario.Repository;
using Microsoft.AspNetCore.Mvc;

namespace AppRosario.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController
    {
        private readonly IUserRepository _repository;

        public UserController(IUserRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public async Task<ActionResult> RegisterUser(User user)
        {
            _repository.Register(user);

            return await _repository.SaveChangesAsync()
                    ? Ok("Usuario registrado com sucesso.")
                    : BadRequest("Erro ao registrar usuario.");
        }
    }
}