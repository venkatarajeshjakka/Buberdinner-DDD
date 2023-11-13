using BuberDinner.Domain.Entities;

namespace BuberDinner.Application.Common.Interfaces.Persistance;

public interface IUserRespository
{
    void Add(User user);

    User? GetUserByEmail(string email);

}