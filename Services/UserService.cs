using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

public class UserService
{
    private readonly ApplicationDbContext _dbContext;

    public UserService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IEnumerable<User> GetUsers()
    {
        return _dbContext.Users.ToList();
    }

    public User GetUserById(int id)
    {
        return _dbContext.Users.FirstOrDefault(u => u.Id == id);
    }

    public void CreateUser(User user)
    {
        _dbContext.Users.Add(user);
        _dbContext.SaveChanges();
    }

    public void UpdateUser(User user)
    {
        var existingUser = _dbContext.Users.FirstOrDefault(u => u.Id == user.Id);

        if (existingUser != null)
        {
            existingUser.UserName = user.UserName;
            existingUser.Email = user.Email;

            _dbContext.SaveChanges();
        }
    }

    public void DeleteUser(int id)
    {
        var userToDelete = _dbContext.Users.FirstOrDefault(u => u.Id == id);

        if (userToDelete != null)
        {
            _dbContext.Users.Remove(userToDelete);
            _dbContext.SaveChanges();
        }
    }
}
