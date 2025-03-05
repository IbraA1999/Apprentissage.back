using FoodTruck.Api.DTOs.Users;
using FoodTruck.Domain;

namespace FoodTruck.Api.Mappers
{
    public interface IUserMapper
    {
        public User MapUserPostDto(UserPostDto user);
        public UserGetAllDto MapUserToGetAllDto(User user);
    }
    public class UserMapper : IUserMapper
    {

        public UserGetAllDto MapUserToGetAllDto(User user)
        {
            return new UserGetAllDto
            {
                Name = user.Name,
                Email = user.Email,
            };
        }

        public User MapUserPostDto(UserPostDto user)
        {
            return new User
            {
                Name = user.Name,
                Email = user.Email,
                Password = user.Password
            };
        }
    }
}
