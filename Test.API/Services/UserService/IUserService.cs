namespace Test.API.Services.UserService
{
    public interface IUserService
    {
        Task<List<User>> GetAllUsers();
        Task<User> GetUser(int id);
        Task<List<User>> AddUser(User user);
        Task<List<User>> UpdateUser(User request);
        Task<List<User>> DeleteUser(int id);

    }
}
