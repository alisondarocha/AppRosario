using AppRosario.Models;
using AppRosario.Repository;
using Microsoft.AspNetCore.Mvc;


namespace AppRosario.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
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
        public async Task<IActionResult> GetUser (int id)
        {
            var user = await _repository.Get(id);
            return user != null
                ? Ok(user)
                : NotFound("Usuario não encontrado");
        }
    }
}