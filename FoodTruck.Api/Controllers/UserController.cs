using FoodTruck.Api.DTOs.Users;
using FoodTruck.Api.Mappers;
using FoodTruck.Bll;
using FoodTruck.Domain;
using Microsoft.AspNetCore.Mvc;

namespace FoodTruck.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserMapper _userMapper;
        private readonly IUserService _userService;

        public UserController(IUserMapper userMapper, IUserService userService)
        {
            _userMapper = userMapper;
            _userService = userService;
        }

        [HttpPost("post")]
        [ProducesResponseType(typeof(User), 200)]
        // Utilisateur tape ses information reçu par le DTO (comme ça on évite d'exposer des donnée qu'il n'a pas a remplir)
        // on appel le mapper pour mapper le DTO en utilisateur
        // on appel le service pour fiare notre logique métier
        public ActionResult<User> Post([FromBody] UserPostDto userDto)
        {
            User user = _userMapper.MapUserPostDto(userDto);
            _userService.Create(user);

            return Ok(user);
        }

        [HttpGet("getAll")]
        [ProducesResponseType(typeof(UserGetAllDto), 200)]
        public ActionResult<UserGetAllDto[]> GetAll()
        {
            User[] users = _userService.GetAll();
            UserGetAllDto[] userGetAllDto = users.Select(_userMapper.MapUserToGetAllDto).ToArray();

            return Ok(userGetAllDto);
        }

    }
}
