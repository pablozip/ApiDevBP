using ApiDevBP.Models;
using MediatR;

namespace ApiDevBP.Application.GetUsers
{
    public class GetUsersQuery() : IRequest<List<UserModelUpdate>>
    {
    }
}
