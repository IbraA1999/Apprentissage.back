using FoodTruck.Domain;

namespace FoodTruck.Infra.Repositories
{
    public interface IUserRepository
    {
        public User Create(User user);

        public User[] GetAll();
    }

    internal class UserRepository : IUserRepository
    {
        private readonly FoodTruckContext _context;

        public UserRepository(FoodTruckContext context)
        {
            _context = context;
        }

        // va demander a la DB De stocker l'utilisateur hashé et renvoyer l'utilisateur 
        // normale repository et bll void card de toute manière on renvoie le DTO (sauf si business logique qui modifie l'netré utilisateur 
        // et qu'on doit renvoyer au client
        public User Create(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();

            return user;
        }

        public User[] GetAll()
        {
            return _context.Users.ToArray();

        }
    }
}
