using FoodTruck.Domain;
using FoodTruck.Infra.Repositories;
using System.Security.Cryptography;
using System.Text;

namespace FoodTruck.Bll
{
    public interface IUserService
    {
        public User Create(User user);

        public User[] GetAll();
    }

    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // on regarde si le petit filou n'a pas mis un password vide ou avec des espace vide
        // on hash le password
        // on modifie la propriété password de l'utilisateur IMPORTANT 
        // on appel notre repository qui va communiquer avec la DB
        public User Create(User user)
        {
            if (string.IsNullOrWhiteSpace(user.Password))
            {
                throw new NullReferenceException("The password provided is null");
            }

            byte[] bytes = Encoding.UTF8.GetBytes(user.Password);

            using (var sha512 = SHA512.Create())
            {
                byte[] hashBytes = sha512.ComputeHash(bytes);

                user.Password = BitConverter.ToString(hashBytes).Replace("-", "").ToLower();

                User newUser = _userRepository.Create(user);

                return newUser;
            }
        }

        public User[] GetAll()
        {
            return _userRepository.GetAll();
        }
    }


}
