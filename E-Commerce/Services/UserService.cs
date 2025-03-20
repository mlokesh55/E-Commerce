using e_comm.Models;
using e_comm.Repository;
using E_Commerce.Repository;
using UserWebAPI.Exceptions;
using UserWebAPI.Exceptions.DemoAPI.Exception;

namespace e_comm.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository repo;
        private readonly IShoppingCartRepository cartrepo;

        public UserService(IUserRepository repo,IShoppingCartRepository cartrepo)
        {
            this.repo = repo;
            this.cartrepo = cartrepo;
        }

        public int AddUser(User user)
        {
            if (repo.GetUser(user.UserId) != null)
            {
                throw new CustomerAlreadyExistsException($"Customer with id {user.UserId} already exists");

            }


            user.ShoppingCart  = new ShoppingCart
            {
                //UserId = userId,
                User = user
            };
            //cartrepo.AddCart(cart);
            //return repo.AddUser(user);
            int userId = repo.AddUser(user);
            return userId;
        }

        public int DeleteUser(int id)
        {
            if (repo.GetUser(id) == null)
            {
                throw new CustomerNotFoundException($"Customer with id {id} not found");
            }

            return repo.DeleteUser(id);
        }
        public User GetUser(int id)
        {
            User user = repo.GetUser(id);
            if (user == null)
            {
                throw new CustomerNotFoundException($"Customer with id {id} not found");
            }
            return user;
        }

        public List<User> GetUsers()
        {
            return repo.GetUsers();
        }

        public int UpdateUser(int id, User user)
        {
            if (repo.GetUser(id) == null)
            {
                throw new CustomerNotFoundException($"Customer with id {id} not found");
            }
            return repo.UpdateUser(id, user);
        }
    }
}
