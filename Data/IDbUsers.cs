using ApiDevBP.Application.UpdateUser;
using ApiDevBP.Models;

namespace ApiDevBP.Data
{
    public interface IDbUsers
    {
        Task<int> Create(UserModel user);
        Task<List<UserModelUpdate>> GetAll();
        Task<bool> Delete(int id);
        Task<bool> Update(UpdateUserCommand user);

    }
}
